using Bank_Management_System.Dtos;
using Bank_Management_System.Services.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repo;

        public EmployeeController(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAll(AllEmployeeDto dto)
        {
            _repo.AddAll(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(AllEmployeeDto dto, int id)
        {
            _repo.Updater(dto, id);
            return Ok();
        } 
    }
}
