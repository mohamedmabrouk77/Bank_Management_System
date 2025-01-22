using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class AllAccountDto
    {
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public int Balance { get; set; }

        //Relation With CustomerDto
        public CustomerDto CustomerDto { get; set; }

        //Relation With TransactionDto
        public List<TransactionDto> TransactionDto { get; set; }

    }
}
