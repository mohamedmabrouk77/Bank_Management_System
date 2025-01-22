using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class AccountDto
    {
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public int Balance { get; set; }
        public List<TransactionDto> TransactionDto { get; set; }

    }
}
