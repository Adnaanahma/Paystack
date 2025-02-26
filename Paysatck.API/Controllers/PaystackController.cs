using Microsoft.AspNetCore.Mvc;
using Paystack.Model.ViewModel;
using Paystack.Service.Interfaces;

namespace Paysatck.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaystackController : ControllerBase
    {
        private readonly IPaystackService _paystackService;
        public PaystackController(IPaystackService paystackService)
        {
            _paystackService = paystackService;
        }
        /// <summary>
        /// "This method initiate payment to paystack"
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("initialize")]
        public async Task<IActionResult> InitializePayment([FromBody] PaymentRequest request)
        {
            try
            {
                var (authorizationUrl, reference) = await _paystackService.InitializePayment(request);
                return Ok(new
                {
                    Status = true,
                    Message = "Authorization URL created",
                    Data = new
                    {
                        AuthorizationUrl = authorizationUrl,
                        Reference = reference
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
        /// <summary>
        /// "This method verify the payment by reference"
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        [HttpGet("verify")]
        public async Task<IActionResult> VerifyPayment([FromQuery] string reference)
        {
           var response = await _paystackService.VerifyPayment(reference);
           if (response)
           {
               return (new
               {
                   Status = true,
                   Message = "Payment verified successful",
               });
           }
           else return BadRequest(response);
        }
    }
}
