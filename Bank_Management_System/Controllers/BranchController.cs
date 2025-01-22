using Bank_Management_System.Dtos;
using Bank_Management_System.Services.BranchRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo _repo;
        public BranchController(IBranchRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllBranches();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAll(AllBranchDto dto)
        {
            _repo.AddAll(dto);
            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(AllBranchDto dto,int id)
        {
            _repo.DeleteAll(dto,id);
            return Ok();
        }
    }
}
