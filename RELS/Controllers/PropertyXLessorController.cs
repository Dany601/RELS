using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Model;
using RELS.Services;

namespace RELS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyXLessorController : ControllerBase
    {
        private readonly IPropertyXLessorService _propertyXLessorService;

        public PropertyXLessorController(IPropertyXLessorService propertyXLessorService)
        {
            _propertyXLessorService = propertyXLessorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<PropertyXLessor>>> GetAllPropertyXLessor()
        {
            var propertyXLessor = await _propertyXLessorService.GetAllPropertyXLessorAsync();
            return Ok(propertyXLessor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PropertyXLessor>> GetPropertyXLessorById(int id)
        {
            var propertyXLessor = await _propertyXLessorService.GetAllPropertyXLessorAsync();
            if (propertyXLessor == null)
                return NotFound();
            return Ok(propertyXLessor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreatePropertyXLessor([FromBody] PropertyXLessor propertyXLessor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _propertyXLessorService.CreatePropertyXLessorAsync(propertyXLessor);
            return CreatedAtAction(nameof(GetPropertyXLessorById), new { id = propertyXLessor.PropertyId }, propertyXLessor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdatePropertyXLessor(int id, [FromBody] PropertyXLessor propertyXLessor)
        {
            if (id != propertyXLessor.PropertyId)
                return BadRequest();

            var existingPropertyXLessor = await _propertyXLessorService.GetPropertyXLessorByIdAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> SoftDeletePropertyXLessor(int id)
        {
            var propertyXLessor = await _propertyXLessorService.GetPropertyXLessorByIdAsync(id);
            if (propertyXLessor == null)
                return NotFound();

            await _propertyXLessorService.SoftDeletePropertyXLessorAsync(id);
            return NoContent();
        }




    }
}
