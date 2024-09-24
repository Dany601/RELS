using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly ILessorService _LessorService;

        public LessorController(ILessorService LessorService)
        {
            _LessorService = LessorService;
        }


        // Get all Lessor
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Lessor>>> GetAllLessors()
        {
            var lessor = await _LessorService.GetAllLessorsAsync();
            return Ok(lessor);
        }


        // Get lessor by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Lessor>> GetLessorById(int id)
        {
            var lessor = await _LessorService.GetLessorByIdAsync(id);
            if (lessor == null) return NotFound();

            return Ok(lessor);
        }


        // Create a Lessor
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateLessor([FromForm] Lessor lessor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _LessorService.CreateLessorAsync(lessor);
            return CreatedAtAction(nameof(GetLessorById), new { id = lessor.LessorId }, lessor);
        }


        // Update a Lessor
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateLessor(int id, [FromForm] Lessor lessor)
        {
            if (id != lessor.LessorId) return BadRequest();

            var existingUser = await _LessorService.GetLessorByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _LessorService.UpdateLessorAsync(lessor);
            return NoContent();
        }

        // Delete a lessor
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteLessor(int id)
        {
            var user = await _LessorService.GetLessorByIdAsync(id);
            if (user == null) return NotFound();

            await _LessorService.SoftDeleteLessorAsync(id);
            return NoContent();
        }

    }
}

