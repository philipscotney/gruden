using Gruden.Data.Models;
using Gruden.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gruden.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Post(Person person)
        {
            try
            {
                var returnPerson = await _personService.SetPersonAsync(person);

                return Ok(returnPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(Person person)
        {
            var foo = new Person() { Name = "weewweww" };
             
            return Ok(foo);
        }
    }
}