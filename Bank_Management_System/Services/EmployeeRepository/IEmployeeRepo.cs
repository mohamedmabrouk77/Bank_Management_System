using Bank_Management_System.Dtos;

namespace Bank_Management_System.Services.EmployeeRepository
{
    public interface IEmployeeRepo
    {
        public List<AllEmployeeDto> GetAll();
        public void AddAll(AllEmployeeDto dto);
        public void Updater(AllEmployeeDto dto, int id);
    }
}
