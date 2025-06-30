using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayStack.Net;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PaymentsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("InitializePayment")]
        public IActionResult InitializePayment([FromBody] PaystackInitRequest request)
        {
            var paystack = new PayStackApi(_config["PayStackSettings:PayStackSecretKey"]);

            var trxRequest = new TransactionInitializeRequest
            {
                AmountInKobo = Convert.ToInt32(request.AmountInKobo * 100),
                Email = request.Email,
                Reference = request.Reference,
                Currency = "GHS"
            };

            var response = paystack.Transactions.Initialize(trxRequest);

            if (response.Status)
                return Ok(new
                {
                    response.Data.AuthorizationUrl
                });
            else
                return BadRequest(response.Message);
        }
    }
}
