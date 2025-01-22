using Bank_Management_System.Dtos;
using Bank_Management_System.Services.CustomerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repo;

        public CustomerController(ICustomerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAll();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Get By Id")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAllCustomer(AllCustomerDto dto)
        {
            _repo.AddAll(dto);
            return Ok();
        }
    }
}
