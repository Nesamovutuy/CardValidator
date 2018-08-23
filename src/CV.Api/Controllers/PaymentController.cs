using System.Collections.Generic;
using CardValidator.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAppLogger<PaymentController> _logger;

        public PaymentController(IPaymentRepository paymentRepository, IAppLogger<PaymentController> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        // GET api/payment
        [HttpGet]
        public IActionResult Get()
        {
            string num = "2014269757902178";
            return Ok(_paymentRepository.IsCardNumberExists(num));
        }

        // POST api/payment/card
        [HttpPost("card")]
        public void Post([FromBody] string value)
        {
        }
    }
}
