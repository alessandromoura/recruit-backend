using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardApi.Domain.Models
{
    public class Input
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CVC { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CardNumber { get; set; }
    }
}
