using Microsoft.AspNetCore.Mvc;
using PersonalInformationFormApp.Models;
using PersonalInformationFormApp.Repositories;

namespace PersonalInformationFormApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personRepository.GetAll();
            return Ok(persons);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = _personRepository.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);

        }


        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personRepository.SavePerson(person);
            return CreatedAtAction("GetById", new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personRepository.UpdatePerson(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personRepository.DeletePerson(id);
            return NoContent();
        }
    }
}
