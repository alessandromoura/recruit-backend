using CreditCardApi.Domain.Communications;
using CreditCardApi.Domain.Models;

namespace CreditCardApi.Extensions
{
    public static class CustomMappers
    {
        public static Input ToInputModel(this InputRequest inputReq)
        {
            var response = new Input
            {
                Name = inputReq.Name,                
                CVC = inputReq.CVC.GetValueOrDefault(),
                ExpiryDate = inputReq.ExpiryDate.GetValueOrDefault(),
                CardNumber = inputReq.CardNumber
            };

            return response;
        }

        public static InputResponse ToInputResponse(this Input inputModel)
        {
            var response = new InputResponse { 
                Id = inputModel.Id.ToString(),
                Name = inputModel.Name,
                CardNumber = inputModel.CardNumber,
                CVC = inputModel.CVC,
                ExpiryDate = inputModel.ExpiryDate
            };
            
            return response;
        }

        public static CreditCardResponse ToCreditCardResponse(this CreditCard creditCardModel)
        {
            var response = new CreditCardResponse
            {
                CardNumber = creditCardModel.CardNumber,
            };

            return response;
        }
    }

}
