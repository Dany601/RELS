using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePropertyController : ControllerBase
    {
        private readonly ITypePropertyService _TypePropertyService;

        public TypePropertyController(ITypePropertyService typepropertyService)
        {
            _TypePropertyService = typepropertyService;
        }


        // Get all TypeProperty
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeProperty>>> GetAllTypesProperties()
        {
            var typesProperties = await _TypePropertyService.GetAllTypesPropertiesAsync();
            return Ok(typesProperties);
        }


        // Get typeproperty by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProperty>> GetTypePropertyById(int id)
        {
            var typeproperty = await _TypePropertyService.GetTypePropertyByIdAsync(id);
            if (typeproperty == null) return NotFound();

            return Ok(typeproperty);
        }


        // Create a TypeProperty
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeProperty([FromForm] TypeProperty typeproperty)
        {

            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _TypePropertyService.CreateTypePropertyAsync(typeproperty);
            return CreatedAtAction(nameof(GetTypePropertyById), new { id = typeproperty.Id }, typeproperty);
        }


        // Update a TypeProperty
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateTypeProperty(int id, [FromForm] TypeProperty typeproperty)
        {
            if (id != typeproperty.Id) return BadRequest();

            var existingTypeProperty = await _TypePropertyService.GetTypePropertyByIdAsync(id);
            if (existingTypeProperty == null) return NotFound();

            await _TypePropertyService.UpdateTypePropertyAsync(typeproperty);
            return NoContent();
        }

        // Delete a typeproperty
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteTypeProperty(int id)
        {
            var typeproperty = await _TypePropertyService.GetTypePropertyByIdAsync(id);
            if (typeproperty == null) return NotFound();

            await _TypePropertyService.SoftDeleteTypePropertyAsync(id);
            return NoContent();
        }

    }
}
