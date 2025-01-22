using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class CustomerDto
    {
        [Required]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string CustomerEmailAddress { get; set; }
        [Phone]
        [MaxLength(15)]
        public string CustomerPhone { get; set; }
        public BankCardDto BankCardDto { get; set; }

    }
}
