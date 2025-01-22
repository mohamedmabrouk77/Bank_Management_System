using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        [MaxLength(20)]
        public int AccountNumber { get; set; }
        [Required]
        public int Balance { get; set; }

        //Relation With Customer
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        //Relation With Transaction
        public List<Transaction> Transaction { get; set; }
    }
}
