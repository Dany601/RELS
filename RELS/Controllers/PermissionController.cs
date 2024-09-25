using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _PermissionService;

        public PermissionController(IPermissionService PermissionService)
        {
            _PermissionService = PermissionService;
        }


        // Get all Permission
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permission>>> GetAllPermissions()
        {
            var permissions = await _PermissionService.GetAllPermissionsAsync();
            return Ok(permissions);
        }


        // Get permission by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permission>> GetPermissionById(int id)
        {
            var permission = await _PermissionService.GetPermissionByIdAsync(id);
            if (permission == null) return NotFound();

            return Ok(permission);
        }


        // Create a Permission
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermission([FromForm] Permission permission)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _PermissionService.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Id }, permission);
        }


        // Update a Permission
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdatePermission(int id, [FromForm] Permission permission)
        {
            if (id != permission.Id) return BadRequest();

            var existingUser = await _PermissionService.GetPermissionByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _PermissionService.UpdatePermissionAsync(permission);
            return NoContent();
        }

        // Delete a permission
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeletePermission(int id)
        {
            var user = await _PermissionService.GetPermissionByIdAsync(id);
            if (user == null) return NotFound();

            await _PermissionService.SoftDeletePermissionAsync(id);
            return NoContent();
        }

    }
}
