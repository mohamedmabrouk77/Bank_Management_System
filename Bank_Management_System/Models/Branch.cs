using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Location { get; set; }

        //Relation With Employee
        public List<Employee> Employee { get; set; }
    }
}
