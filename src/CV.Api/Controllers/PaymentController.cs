using CardValidator.Domain.Interfaces;
using CV.Api.ViewModels;
using CV.Infrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

        // POST api/payment/card
        [HttpPost("[action]")]
        public IActionResult Card([FromBody] CardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(ModelState.ToString());
                return BadRequest(ModelState);
            }

            if (!_paymentRepository.IsCardNumberExists(model.Number))
            {
                return NotFound();
            }

            string type = GetCardType(model.Number).ToString();

            return Ok(new { CardType = type });
        }

        // TODO: Move from controller
        private CardType GetCardType(string cardNumber)
        {
            CardTypeInfo[] _cardTypeInfo =
            {
                new CardTypeInfo("^(5)", 16, CardType.MasterCard),
                new CardTypeInfo("^(4)", 16, CardType.Visa),
                new CardTypeInfo("^(3)", 15, CardType.Amex),
                new CardTypeInfo("^(3)", 16, CardType.JCB)
            };

            foreach (CardTypeInfo info in _cardTypeInfo)
            {
                if (cardNumber.Length == info.Length &&
                    Regex.IsMatch(cardNumber, info.RegEx))
                    return info.Type;
            }

            return CardType.Unknown;
        }
    }
}
