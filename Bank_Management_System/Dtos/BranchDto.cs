using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Dtos
{
    public class BranchDto
    {
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Location { get; set; }
        
    }
}
