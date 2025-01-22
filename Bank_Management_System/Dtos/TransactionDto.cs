using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class TransactionDto
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

    }
}
