using Bank_Management_System.Dtos;
using Bank_Management_System.Services.AccountRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _repo;

        public AccountController(IAccountRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddAll(AllAccountDto account)
        {
            _repo.AddAll(account);
            if(account == null)
            {
                return BadRequest();
            }
            return Ok();
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

        [HttpPut]
        public IActionResult UpdateAll(AllAccountDto dto, int id)
        {
            _repo.UpdateAllAccount(dto, id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAll(int id)
        {
            _repo.DeleteAllAccount(id);
            if(id == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
