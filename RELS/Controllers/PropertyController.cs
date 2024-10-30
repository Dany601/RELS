using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyService _PropertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _PropertyService = propertyService;
        }


        // Get all Property
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperties()
        {
            var properties = await _PropertyService.GetAllPropertiesAsync();
            return Ok(properties);
        }


        // Get property by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Property>> GetPropertyById(int id)
        {
            var property = await _PropertyService.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            return Ok(property);
        }


        // Create a Property
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProperty([FromForm] string propertyaddress, [FromForm] string squaremetersproperty, [FromForm] string cost, [FromForm] string propertydescription, [FromForm] string latitude, [FromForm] string altitude, [FromForm] int stateid, [FromForm] int typespropertyid, [FromForm] int sectorid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _PropertyService.CreatePropertyAsync(propertyaddress, squaremetersproperty, cost, propertydescription, latitude, altitude, stateid, typespropertyid, sectorid);
            return StatusCode(StatusCodes.Status201Created, "Property Created");
        }


        // Update a Property

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<IActionResult> UpdateProperty(int id, [FromForm] Property property)
        {
            if (id != property.Id) return BadRequest();

            var existingProperty = await _PropertyService.GetPropertyByIdAsync(id);
            if (existingProperty == null) return NotFound();

            await _PropertyService.UpdatePropertyAsync(property);
            return NoContent();
        }

        // Delete a property

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<IActionResult> SoftDeleteProperty(int id)
        {
            var property = await _PropertyService.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            await _PropertyService.SoftDeletePropertyAsync(id);
            return NoContent();
        }

    }
}