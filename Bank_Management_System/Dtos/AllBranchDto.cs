using Bank_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class AllBranchDto
    {
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Location { get; set; }

        //Relation With EmployeeDto
        public List<EmployeeDto> EmployeeDto { get; set; }
    }
}
