using Bank_Management_System.AppDbContext;
using Bank_Management_System.Dtos;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services.EmployeeRepository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly dbcontext _context;

        public EmployeeRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAll(AllEmployeeDto dto)
        {
            var result = new Employee
            {
                EmployeeName = dto.EmployeeName,
                Position = dto.Position,
                Branche = dto.BranchDto.Select(x=> new Branch
                {
                    BranchName = x.BranchName,
                    Location = x.Location,
                }).ToList(),
            };
            _context.Employeess.Add(result);
            _context.SaveChanges();
        }

        public List<AllEmployeeDto> GetAll()
        {
            var result = _context.Employeess.
                Include(x => x.Branche).
                Select(i => new AllEmployeeDto
                {
                    EmployeeName=i.EmployeeName,
                    Position = i.Position,
                    BranchDto = i.Branche.Select(t => new BranchDto
                    {
                        BranchName=t.BranchName,
                        Location = t.Location,
                    }).ToList(),
                }).ToList();
            return result;
        }

        public void Updater(AllEmployeeDto dto, int id)
        {
            var result = _context.Employeess.
                Include(x => x.Branche).
                FirstOrDefault(x => x.EmployeeId == id);

            if(result != null)
            {
                result.EmployeeName = dto.EmployeeName;
                result.Position = dto.Position;
                result.Branche = dto.BranchDto.Select(i => new Branch
                {
                    BranchName = i.BranchName,
                    Location = i.Location,
                }).ToList();
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Employeess.Update(result);
            _context.SaveChanges();
        }
    }
}
