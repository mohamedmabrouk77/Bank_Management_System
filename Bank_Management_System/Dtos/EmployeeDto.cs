using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
