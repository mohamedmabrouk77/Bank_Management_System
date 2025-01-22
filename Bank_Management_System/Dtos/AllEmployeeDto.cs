using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class AllEmployeeDto
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Position { get; set; }

        //Relation With Branch 
        public List<BranchDto> BranchDto { get; set; }
    }
}
