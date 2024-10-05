using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Model;
using RELS.Services;

namespace RELS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionXUserController : ControllerBase
    {
        private readonly IPermissionXUserService _permissionXUserService;

        public PermissionXUserController(IPermissionXUserService permissionXUserService)
        {
            _permissionXUserService = permissionXUserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<PermissionXUser>>> GetAllPermissionXUser()
        {
            var permissionXUser = await _permissionXUserService.GetAllPermissionXUserAsync();
            return Ok(permissionXUser);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PermissionXUser>> GetPermissionXUserById(int id)
        {
            var permissionXUser = await _permissionXUserService.GetAllPermissionXUserAsync();
            if(permissionXUser == null)
                return NotFound();
            return Ok(permissionXUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreatePermissionXUser([FromBody] PermissionXUser permissionXUser)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _permissionXUserService.CreatePermissionXUserAsync(permissionXUser);
            return CreatedAtAction(nameof(GetPermissionXUserById), new { id = permissionXUser.PermissionId }, permissionXUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdatePermissionXUser(int id, [FromBody] PermissionXUser permissionXUser)
        {
            if(id != permissionXUser.PermissionId)
                return BadRequest();

            var existingPermissionXUser = await _permissionXUserService.GetPermissionXUserByIdAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> SoftDeletePermissionXUser(int id)
        {
            var permissionXUser = await _permissionXUserService.GetPermissionXUserByIdAsync(id);
            if(permissionXUser == null)
                return NotFound();

            await _permissionXUserService.SoftDeletePermissionXUserAsync(id);
            return NoContent();
        }




    }
}
