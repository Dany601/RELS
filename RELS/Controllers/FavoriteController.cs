using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _FavoriteService;

        public FavoriteController(IFavoriteService FavoriteService)
        {
            _FavoriteService = FavoriteService;
        }


        // Get all Favorite
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetAllFavorites()
        {
            var favorite = await _FavoriteService.GetAllFavoritesAsync();
            return Ok(favorite);
        }


        // Get favorite by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Favorite>> GetFavoriteById(int id)
        {
            var favorite = await _FavoriteService.GetFavoriteByIdAsync(id);
            if (favorite == null) return NotFound();

            return Ok(favorite);
        }


        // Create a Favorite
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateFavorite([FromForm] Favorite favorite)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _FavoriteService.CreateFavoriteAsync(favorite);
            return CreatedAtAction(nameof(GetFavoriteById), new { id = favorite.Id }, favorite);
        }


        // Update a Favorite
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateFavorite(int id, [FromForm] Favorite favorite)
        {
            if (id != favorite.Id) return BadRequest();

            var existingUser = await _FavoriteService.GetFavoriteByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _FavoriteService.UpdateFavoriteAsync(favorite);
            return NoContent();
        }

        // Delete a favorite
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteFavorite(int id)
        {
            var user = await _FavoriteService.GetFavoriteByIdAsync(id);
            if (user == null) return NotFound();

            await _FavoriteService.SoftDeleteFavoriteAsync(id);
            return NoContent();
        }

    }
}
