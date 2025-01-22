using Bank_Management_System.AppDbContext;
using Bank_Management_System.Dtos;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services.BranchRepository
{
    public class BranchRepo : IBranchRepo
    {
        private readonly dbcontext _context;

        public BranchRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAll(AllBranchDto dto)
        {
            var result = new Branch
            {
                BranchName = dto.BranchName,
                Location = dto.Location,
                Employee = dto.EmployeeDto.Select(x => new Employee
                {
                    EmployeeName = x.EmployeeName,
                    Position = x.Position,
                }).ToList(),
            };
            _context.Branchess.Add(result);
            _context.SaveChanges();
        }

        public void DeleteAll(AllBranchDto dto, int id)
        {
            var result = _context.Branchess.
                Include(x => x.Employee).
                FirstOrDefault(x=>x.BranchId == id);

            if (result != null)
            {
                _context.Branchess.Remove(result);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<AllBranchDto> GetAllBranches()
        {
            var result = _context.Branchess.
                Include(x=>x.Employee).
                Select(x=> new AllBranchDto
                {
                    BranchName= x.BranchName,
                    Location= x.Location,
                    EmployeeDto = x.Employee.Select(i => new EmployeeDto
                    {
                        EmployeeName= i.EmployeeName,
                        Position = i.Position,
                    }).ToList(),
                }).ToList();
            return result;
        }
    }
}
