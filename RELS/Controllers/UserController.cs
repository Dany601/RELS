using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }


        // Get all User
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _UserService.GetAllUsersAsync();
            return Ok(users);
        }


        // Get user by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _UserService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }


        // Create a User
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromForm] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _UserService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }


        // Update a User
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUser(int id, [FromForm] User user)
        {
            if (id != user.Id) return BadRequest();

            var existingUser = await _UserService.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _UserService.UpdateUserAsync(user);
            return NoContent();
        }

        // Delete a user
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _UserService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            await _UserService.SoftDeleteUserAsync(id);
            return NoContent();
        }

    }
}
