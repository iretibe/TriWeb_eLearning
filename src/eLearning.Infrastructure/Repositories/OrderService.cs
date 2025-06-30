using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Enums;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace eLearning.Infrastructure.Repositories
{
    public class OrderService : IOrderService
    {
        private readonly eLearningContext _context;
        private readonly IEmailService _emailService;

        public OrderService(eLearningContext context, IEmailService emailService) 
        { 
            _context = context; 
            _emailService = emailService;
        }

        public async Task<Guid> CreateOneTimePurchaseOrderAsync(string userId, List<CourseDto> courses, string reference)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID is required.", nameof(userId));

            if (courses == null || !courses.Any())
                throw new ArgumentException("At least one course must be provided.", nameof(courses));

            var total = courses.Sum(c => c.Price);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                TotalAmount = total,
                TransactionReference = reference,
                OrderDate = DateTime.UtcNow,
                Items = courses.Select(c => new OrderItem
                {
                    CourseId = c.Id,
                    CourseTitle = c.Title,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Save to enrollments entity
            foreach (var item in order.Items)
            {
                var alreadyEnrolled = await _context.Enrollments
                    .AnyAsync(e => e.LearnerId == userId && e.CourseId == item.CourseId);

                if (!alreadyEnrolled)
                {
                    _context.Enrollments.Add(new Enrollment
                    {
                        Id = Guid.NewGuid(),
                        LearnerId = userId,
                        CourseId = item.CourseId,
                        EnrolledOn = DateTime.UtcNow
                    });
                }
            }
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<h3>Thank you, {user.UserName}, for your purchase!</h3>");
                emailBody.AppendLine("<p>Here are your course details:</p><ul>");

                foreach (var course in courses)
                {
                    emailBody.AppendLine($"<li>{course.Title} — GHS {course.Price:N2}</li>");
                }

                emailBody.AppendLine("</ul>");
                emailBody.AppendLine($"<p><strong>Total Paid:</strong> GHS {total:N2}</p>");

                // Send email
                await _emailService.SendAsync(user.Email!, "eLearning Purchase Confirmation", emailBody.ToString());

                // Log email
                _context.EmailLogs.Add(new EmailLog
                {
                    RecipientEmail = user.Email!,
                    Subject = "eLearning Purchase Confirmation",
                    Body = emailBody.ToString(),
                    SentAt = DateTime.UtcNow
                });
            }

            // Save Paystack transaction record
            _context.PaystackTransactions.Add(new PaystackTransaction
            {
                Email = user.Email!,
                Reference = reference,
                Amount = total,
                Status = "Success"
            });
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<Guid> CreateOrderAsync(SubscriptionOrder order)
        {
            _context.SubscriptionOrders.Add(order);
            await _context.SaveChangesAsync();

            if (order.Id != Guid.Empty)
            {
                // Parse SubscriptionType from string to enum
                if (!Enum.TryParse<SubscriptionType>(order.SubscriptionType, ignoreCase: true, out var type))
                {
                    throw new InvalidOperationException($"Invalid subscription type: {order.SubscriptionType}");
                }

                // Save to Subscription table
                var now = order.OrderDate;
                var duration = type == SubscriptionType.Monthly
                    ? TimeSpan.FromDays(30)
                    : TimeSpan.FromDays(365);

                var end = now.Add(duration);

                var existing = await _context.Subscriptions
                    .FirstOrDefaultAsync(s => s.UserId == order.UserId);

                if (existing is null)
                {
                    _context.Subscriptions.Add(new Subscription
                    {
                        Id = Guid.NewGuid(),
                        UserId = order.UserId,
                        Type = type,
                        StartDate = now,
                        EndDate = end
                    });
                }
                else
                {
                    existing.Type = type;
                    existing.StartDate = now;
                    existing.EndDate = end;
                }

                await _context.SaveChangesAsync();

                // Save to Enrollment table (if not already enrolled)
                var alreadyEnrolled = await _context.Enrollments
                    .AnyAsync(e => e.LearnerId == order.UserId && e.CourseId == order.CourseId);

                if (!alreadyEnrolled)
                {
                    _context.Enrollments.Add(new Enrollment
                    {
                        Id = Guid.NewGuid(),
                        LearnerId = order.UserId,
                        CourseId = order.CourseId,
                        EnrolledOn = order.OrderDate
                    });

                    await _context.SaveChangesAsync();
                }
            }

            return order.Id;
        }

        public async Task<List<OrderDto>> GetAllOneTimePurchaseOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Course)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    TotalAmount = o.TotalAmount,
                    TransactionReference = o.TransactionReference,
                    OrderDate = o.OrderDate,
                    Items = o.Items.Select(i => new OrderItemDto
                    {
                        CourseId = i.CourseId,
                        CourseTitle = i.Course.Title,
                        Price = i.Price
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<List<OrderDto>> GetOneTimePurchaseOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ThenInclude(i => i.Course)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    TotalAmount = o.TotalAmount,
                    TransactionReference = o.TransactionReference,
                    OrderDate = o.OrderDate,
                    Items = o.Items.Select(i => new OrderItemDto
                    {
                        CourseId = i.CourseId,
                        CourseTitle = i.Course.Title,
                        Price = i.Price
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<Guid> GetOrderIdByReferenceAsync(string reference)
        {
            var query = await _context.Orders.FirstOrDefaultAsync(o => o.TransactionReference == reference);
            if (query == null)
                throw new KeyNotFoundException($"Order with reference '{reference}' not found.");
            return query.Id;
        }

        public async Task MarkOrderAsPaidAsync(Guid orderId, string transactionRef)
        {
            var order = await _context.SubscriptionOrders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = "Paid";
                order.TransactionReference = transactionRef;
                await _context.SaveChangesAsync();
            }
        }
    }
}
