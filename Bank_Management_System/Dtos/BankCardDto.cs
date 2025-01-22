using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class BankCardDto
    {
        [Required]
        public string BankCardName { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
