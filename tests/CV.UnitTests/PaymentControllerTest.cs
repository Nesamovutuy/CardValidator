using CardValidator.Domain.Interfaces;
using CV.Api.Controllers;
using CV.Api.ViewModels;
using CV.Infrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CV.UnitTests
{
    public class PaymentControllerTest
    {
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        private readonly Mock<IAppLogger<PaymentController>> _appLoggerMock;

        private readonly PaymentController _controller;

        public PaymentControllerTest()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _appLoggerMock = new Mock<IAppLogger<PaymentController>>();

            _controller = new PaymentController(_paymentRepositoryMock.Object, _appLoggerMock.Object);
        }

        [Fact]
        public void Visa_card_number_invalid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "4123123412341234",
                Month = 12,
                Year = 2018
            };
            _controller.ModelState.AddModelError("Card", "Invalid");

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;
            var modelState = objectResult.Value as dynamic;

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.True(modelState?.ContainsKey("Card"));
        }

        [Fact]
        public void Visa_card_number_valid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "4123123412341234",
                Month = 12,
                Year = 2020
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(true);

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.Equal(new { CardType = CardType.Visa.ToString() }.GetHashCode(), objectResult?.Value.GetHashCode());
        }

        [Fact]
        public void MasterCard_card_number_invalid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "5123123412341234",
                Month = 12,
                Year = 2018
            };
            _controller.ModelState.AddModelError("Card", "Invalid");

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;
            var modelState = objectResult.Value as dynamic;

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.True(modelState?.ContainsKey("Card"));
        }

        [Fact]
        public void MasterCard_card_number_valid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "5123123412341234",
                Month = 12,
                Year = 2027
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(true);

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.Equal(new { CardType = CardType.MasterCard.ToString() }.GetHashCode(), objectResult?.Value.GetHashCode());
        }

        [Fact]
        public void Amex_card_number_invalid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "312312341234123",
                Month = 12,
                Year = 2010
            };
            _controller.ModelState.AddModelError("Card", "Invalid");

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;
            var modelState = objectResult.Value as dynamic;

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.True(modelState?.ContainsKey("Card"));
        }

        [Fact]
        public void Amex_card_number_valid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "312312341234123",
                Month = 12,
                Year = 2019
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(true);

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.Equal(new { CardType = CardType.Amex.ToString() }.GetHashCode(), objectResult?.Value.GetHashCode());
        }

        [Fact]
        public void JCB_card_number_invalid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "3123123412341234",
                Month = 12,
                Year = 2010
            };
            _controller.ModelState.AddModelError("Card", "Invalid");

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;
            var modelState = objectResult.Value as dynamic;

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.True(modelState?.ContainsKey("Card"));
        }

        [Fact]
        public void JCB_card_number_valid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "3123123412341234",
                Month = 12,
                Year = 2021
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(true);

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.Equal(new { CardType = CardType.JCB.ToString() }.GetHashCode(), objectResult?.Value.GetHashCode());
        }

        [Fact]
        public void Unknown_card_number_invalid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "9123129412341239",
                Month = 12,
                Year = 2008
            };
            _controller.ModelState.AddModelError("Card", "Invalid");

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;
            var modelState = objectResult.Value as dynamic;

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.True(modelState?.ContainsKey("Card"));
        }

        [Fact]
        public void Unknown_card_number_valid()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "9123129412341239",
                Month = 12,
                Year = 2019
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(true);

            //Act
            var actionResult = _controller.Card(fakeModel);

            var objectResult = actionResult as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(objectResult?.Value);
            Assert.Equal(new { CardType = CardType.Unknown.ToString() }.GetHashCode(), objectResult?.Value.GetHashCode());
        }

        [Fact]
        public void Return_not_found_when_number_doesnt_exists()
        {
            //Arrange
            CardViewModel fakeModel = new CardViewModel()
            {
                Number = "4123123412341234",
                Month = 12,
                Year = 2018
            };
            _paymentRepositoryMock.Setup(x => x.IsCardNumberExists(fakeModel.Number)).Returns(false);

            //Act
            var actionResult = _controller.Card(fakeModel);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}
