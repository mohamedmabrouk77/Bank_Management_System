using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class BankCard
    {
        [Key]
        public int BankCardId { get; set; }
        [Required]
        [MaxLength(16)]
        public string BankCardName { get; set; }
        [Required]
        public DateTime ExpiryDate {  get; set; }

        //Relation With Customer
        public Customer Customer { get; set; }
    }
}
