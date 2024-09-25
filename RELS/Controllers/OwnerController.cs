using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _OwnerService;

        public OwnerController(IOwnerService OwnerService)
        {
            _OwnerService = OwnerService;
        }


        // Get all Owner
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Owner>>> GetAllOwners()
        {
            var owners = await _OwnerService.GetAllOwnersAsync();
            return Ok(owners);
        }


        // Get owner by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Owner>> GetOwnerById(int id)
        {
            var owner = await _OwnerService.GetOwnerByIdAsync(id);
            if (owner == null) return NotFound();

            return Ok(owner);
        }


        // Create a Owner
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOwner([FromForm] Owner owner)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _OwnerService.CreateOwnerAsync(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, owner);
        }


        // Update a Owner
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateOwner(int id, [FromForm] Owner owner)
        {
            if (id != owner.Id) return BadRequest();

            var existingUser = await _OwnerService.GetOwnerByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _OwnerService.UpdateOwnerAsync(owner);
            return NoContent();
        }

        // Delete a owner
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteOwner(int id)
        {
            var user = await _OwnerService.GetOwnerByIdAsync(id);
            if (user == null) return NotFound();

            await _OwnerService.SoftDeleteOwnerAsync(id);
            return NoContent();
        }

    }
}

