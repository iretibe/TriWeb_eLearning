using eLearning.Application.Commands;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("VerifyPayment/{reference}")]
        public async Task<IActionResult> VerifyPayment(string reference)
        {
            var cleanReference = reference.Split(',')[0]; //To take first occurrence
            var isValid = await _mediator.Send(new VerifyPaystackTransactionQuery(cleanReference));

            //var isValid = await _mediator.Send(new VerifyPaystackTransactionQuery(reference));

            if (isValid)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false, message = "Payment not successful" });
        }

        [HttpPost("InitializePayment")]
        public async Task<IActionResult> InitializePayment([FromBody] InitializePaymentRequestDto request)
        {
            var url = await _mediator.Send(new InitializePaystackCommand(
                request.Email, request.Amount, request.Reference, request.CallbackUrl));

            return Ok(new { authorizationUrl = url });
        }


        //[HttpPost("InitializePayment")]
        //public IActionResult InitializePayment([FromBody] PaystackInitRequest request)
        //{
        //    var paystack = new PayStackApi(_config["PayStackSettings:PayStackSecretKey"]);

        //    var trxRequest = new TransactionInitializeRequest
        //    {
        //        AmountInKobo = Convert.ToInt32(request.AmountInKobo * 100),
        //        Email = request.Email,
        //        Reference = request.Reference,
        //        Currency = "GHS"
        //    };

        //    var response = paystack.Transactions.Initialize(trxRequest);

        //    if (response.Status)
        //        return Ok(new
        //        {
        //            response.Data.AuthorizationUrl
        //        });
        //    else
        //        return BadRequest(response.Message);
        //}
    }
}
