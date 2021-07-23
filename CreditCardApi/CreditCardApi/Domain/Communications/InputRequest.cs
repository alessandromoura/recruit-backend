using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCardApi.Domain.Communications
{
    public class InputRequest
    {
        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }

        //[Required]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage ="Card number must be numeric")]
        public string CardNumber { get; set; }

        public int? CVC { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
