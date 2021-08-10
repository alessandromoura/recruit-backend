using System;

namespace CreditCardApi.Domain.Communications
{
    public class InputResponse
    {
        public string Id { get; set;
        }
        public string Name { get; set; }

        public string CardNumber { get; set; }

        public int CVC { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
