using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllOneTimePurchaseOrders")]
        public async Task<IActionResult> GetAllOneTimePurchaseOrders()
        {
            var result = await _mediator.Send(new GetAllOneTimePurchaseOrdersQuery());
            return Ok(result);
        }

        [HttpGet("GetOneTimePurchaseOrdersByUserId/{userId}")]
        public async Task<IActionResult> GetOneTimePurchaseOrdersByUserId(string userId)
        {
            var result = await _mediator.Send(new GetOneTimePurchaseOrdersByUserIdQuery(userId));
            return Ok(result);
        }

        [HttpGet("GetOrderIdByReference/{reference}")]
        public async Task<IActionResult> GetOrderIdByReference(string reference)
        {
            var result = await _mediator.Send(new GetOrderIdByReferenceQuery(reference));
            return Ok(result);
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return BadRequest($"Model validation failed: {errors}");
            }
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }

        [HttpPost("MarkOrderAsPaid")]
        public async Task<IActionResult> MarkOrderAsPaid([FromBody] MarkOrderAsPaidCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order marked as paid.");
        }

        [HttpPost("CreateOneTimePurchaseOrder")]
        public async Task<IActionResult> CreateOneTimePurchaseOrder(CreateOneTimePurchaseOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
