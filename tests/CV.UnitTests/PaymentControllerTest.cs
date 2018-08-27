using CardValidator.Domain.Interfaces;
using CV.Api.Controllers;
using Moq;
using Xunit;

namespace CV.UnitTests
{
    public class PaymentControllerTest
    {
        //private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        //private readonly Mock<IAppLogger<PaymentController>> _appLoggerMock;

        public PaymentControllerTest()
        {
            //_paymentRepositoryMock = new Mock<IPaymentRepository>();
            //_appLoggerMock = new Mock<IAppLogger<PaymentController>>();
        }

        [Fact]
        public void Visa_card_number_invalid()
        {
            //Arrange
            //string cardNumber = "1111-1111-1111-1111";
            //_paymentRepositoryMock.Setup(x => x.IsCardNumberExists(cardNumber)).Returns(true);

            ////Act
            //var paymentController = new PaymentController(_paymentRepositoryMock.Object);
            //var actionResult = paymentController.Card(new CardViewModel() { }) as BadRequestResult;

            //Assert
            //Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
        }
    }
}
