using Bank_Management_System.Dtos;

namespace Bank_Management_System.Services.CustomerRepository
{
    public interface ICustomerRepo
    {
        public List<AllCustomerDto> GetAll();
        public AllCustomerDto GetById(int id);
        public void AddAll(AllCustomerDto dto);
    }
}
