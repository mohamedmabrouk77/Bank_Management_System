using Bank_Management_System.Dtos;

namespace Bank_Management_System.Services.BranchRepository
{
    public interface IBranchRepo
    {
        public List<AllBranchDto> GetAllBranches();
        public void AddAll(AllBranchDto dto);
        public void DeleteAll(AllBranchDto dto, int id);
    }
}
