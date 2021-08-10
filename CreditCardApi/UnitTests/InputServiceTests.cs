using CreditCardApi.Domain.Models;
using CreditCardApi.Repositories;
using CreditCardApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class InputServiceTests
    {
        private Mock<IInputRepository> _inputRepository;
        private Mock<ICreditCardRepository> _creditCardRepository;
        private IInputService _inputService;

        public InputServiceTests()
        {
            _inputRepository = new Mock<IInputRepository>();
            _creditCardRepository = new Mock<ICreditCardRepository>();
            _inputService = new InputService(_inputRepository.Object, _creditCardRepository.Object);
        }

        [Fact]
        public async Task AddNewInput_ThrowsException_WhenInputDoesNotHaveCreditCardNumber()
        {
            // Arrange            

            // Act
            //var result = _orderService.GetOrder(1);
            Func<Task> act = () => _inputService.AddNewInput(It.IsAny<Input>()); 

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async Task AddNewInput_ThrowsException_WhenCreditCardNumberIsNotFound()
        {
            // Arrange
            _creditCardRepository.Setup(o => o.SelectByCardNumber(It.IsAny<string>())).ReturnsAsync((CreditCard)null);
            var newInput = new Input { CardNumber = "1111" };

            // Act
            Func<Task> act = () => _inputService.AddNewInput(newInput);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(act);
        }
    }
}
