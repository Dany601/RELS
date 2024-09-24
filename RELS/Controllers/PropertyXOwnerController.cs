using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Model;
using RELS.Services;

namespace RELS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyXOwnerController : ControllerBase
    {
        private readonly IPropertyXOwnerService _propertyXOwnerService;

        public PropertyXOwnerController(IPropertyXOwnerService propertyXOwnerService)
        {
            _propertyXOwnerService = propertyXOwnerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<PropertyXOwner>>> GetAllPropertyXOwner()
        {
            var propertyXOwner = await _propertyXOwnerService.GetAllPropertyXOwnerAsync();
            return Ok(propertyXOwner);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PropertyXOwner>> GetPropertyXOwnerById(int id)
        {
            var propertyXOwner = await _propertyXOwnerService.GetAllPropertyXOwnerAsync();
            if (propertyXOwner == null)
                return NotFound();
            return Ok(propertyXOwner);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreatePropertyXOwner([FromBody] PropertyXOwner propertyXOwner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _propertyXOwnerService.CreatePropertyXOwnerAsync(propertyXOwner);
            return CreatedAtAction(nameof(GetPropertyXOwnerById), new { id = propertyXOwner.PropertyId }, propertyXOwner);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdatePropertyXOwner(int id, [FromBody] PropertyXOwner propertyXOwner)
        {
            if (id != propertyXOwner.PropertyId)
                return BadRequest();

            var existingPropertyXOwner = await _propertyXOwnerService.GetPropertyXOwnerByIdAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> SoftDeletePropertyXOwner(int id)
        {
            var propertyXOwner = await _propertyXOwnerService.GetPropertyXOwnerByIdAsync(id);
            if (propertyXOwner == null)
                return NotFound();

            await _propertyXOwnerService.SoftDeletePropertyXOwnerAsync(id);
            return NoContent();
        }




    }
}
