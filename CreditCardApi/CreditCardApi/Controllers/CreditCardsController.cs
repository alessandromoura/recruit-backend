using CreditCardApi.Domain.Communications;
using CreditCardApi.Extensions;
using CreditCardApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Controllers
{
    [ApiController]
    [Route("api/creditcards")]
    public class CreditCardsController : ControllerBase
    {
        private readonly ILogger<CreditCardsController> _logger;
        private readonly IInputService _inputService;

        public CreditCardsController(IInputService inputService, ILogger<CreditCardsController> logger)
        {
            _inputService = inputService;
            _logger = logger;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CreditCardResponse>> Get()
        {
            //not refactored to use mediatr yet
            var result = await _inputService.GetAllCreditCards();
            var response = result.Select(x => x.ToCreditCardResponse()).ToList();
            return response;
        }
    }
}
