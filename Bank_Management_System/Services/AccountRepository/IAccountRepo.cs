using Bank_Management_System.Dtos;

namespace Bank_Management_System.Services.AccountRepository
{
    public interface IAccountRepo
    {
        public List<AllAccountDto> GetAll();
        public void AddAll(AllAccountDto dto);
        public void UpdateAllAccount(AllAccountDto dto, int id);
        public void DeleteAllAccount(int id);
    }
}
