using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Model;
using RELS.Services;

namespace RELS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Person>>> GetAllPerson()
        {
            var person = await _personService.GetAllPersonAsync();
            return Ok(person);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personService.GetAllPersonAsync();
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreatePerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personService.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.PersonId }, person);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
                return BadRequest();

            var existingPerson = await _personService.GetPersonByIdAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> SoftDeletePerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            await _personService.SoftDeletePersonAsync(id);
            return NoContent();
        }




    }
}
