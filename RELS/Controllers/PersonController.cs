using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _PersonService;

        public PersonController(IPersonService personService)
        {
            _PersonService = personService;
        }


        // Get all Person
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPeople()
        {
            var people = await _PersonService.GetAllPeopleAsync();
            return Ok(people);
        }


        // Get person by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _PersonService.GetPersonByIdAsync(id);
            if (person == null) return NotFound();

            return Ok(person);
        }


        // Create a Person
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePerson([FromForm] Person person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _PersonService.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }


        // Update a Person
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdatePerson(int id, [FromForm] Person person)
        {
            if (id != person.Id) return BadRequest();

            var existingPerson = await _PersonService.GetPersonByIdAsync(id);
            if (existingPerson == null) return NotFound();

            await _PersonService.UpdatePersonAsync(person);
            return NoContent();
        }

        // Delete a person
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeletePerson(int id)
        {
            var person = await _PersonService.GetPersonByIdAsync(id);
            if (person == null) return NotFound();

            await _PersonService.SoftDeletePersonAsync(id);
            return NoContent();
        }

    }
}


