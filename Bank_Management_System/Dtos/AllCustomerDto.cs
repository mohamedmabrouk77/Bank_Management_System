using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class AllCustomerDto
    {
        [Required]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string CustomerEmailAddress { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }

        //Relation With BankCardDto
        public BankCardDto BankCardDto { get; set; }

        //Relation With AccountsDto
        public List<AccountDto> AccountDto { get; set; }
    }
}
