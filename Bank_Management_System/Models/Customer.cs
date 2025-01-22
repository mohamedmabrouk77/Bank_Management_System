using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmailAddress { get; set; }
        [Phone]
        [MaxLength(15)]
        public string CustomerPhone { get; set; }

        //Relation With BankCard
        public int BankCardId { get; set; }
        [ForeignKey("BankCardId")]
        public BankCard BankCard { get; set; }

        //Relation With Accounts
        public List<Account> Account { get; set; }
    }
}
