using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Position {  get; set; }

        //Relation With Branch 
        public List<Branch> Branche { get; set; }
    }
}
