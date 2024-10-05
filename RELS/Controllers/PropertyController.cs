using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Model;
using RELS.Services;

namespace RELS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperty()
        {
            var property = await _propertyService.GetAllPropertyAsync();
            return Ok(property);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Property>> GetPropertyById(int id)
        {
            var property = await _propertyService.GetAllPropertyAsync();
            if (property == null)
                return NotFound();
            return Ok(property);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _propertyService.CreatePropertyAsync(property);
            return CreatedAtAction(nameof(GetPropertyById), new { id = property.PropertyId }, property);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.PropertyId)
                return BadRequest();

            var existingProperty = await _propertyService.GetPropertyByIdAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> SoftDeleteProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
                return NotFound();

            await _propertyService.SoftDeletePropertyAsync(id);
            return NoContent();
        }




    }
}
