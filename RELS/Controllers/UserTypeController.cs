using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _UserTypeService;

        public UserTypeController(IUserTypeService usertypeService)
        {
            _UserTypeService = usertypeService;
        }


        // Get all UserType
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUserTypes()
        {
            var usertypes = await _UserTypeService.GetAllUserTypesAsync();
            return Ok(usertypes);
        }


        // Get usertype by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserType>> GetUserTypeById(int id)
        {
            var usertype = await _UserTypeService.GetUserTypeByIdAsync(id);
            if (usertype == null) return NotFound();

            return Ok(usertype);
        }


        // Create a UserType
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserType([FromForm] UserType usertype)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _UserTypeService.CreateUserTypeAsync(usertype);
            return CreatedAtAction(nameof(GetUserTypeById), new { id = usertype.Id }, usertype);
        }


        // Update a UserType
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUserType(int id, [FromForm] UserType usertype)
        {
            if (id != usertype.Id) return BadRequest();

            var existingUserType = await _UserTypeService.GetUserTypeByIdAsync(id);
            if (existingUserType == null) return NotFound();

            await _UserTypeService.UpdateUserTypeAsync(usertype);
            return NoContent();
        }

        // Delete a usertype
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUserType(int id)
        {
            var usertype = await _UserTypeService.GetUserTypeByIdAsync(id);
            if (usertype == null) return NotFound();

            await _UserTypeService.SoftDeleteUserTypeAsync(id);
            return NoContent();
        }

    }
}
