using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _SectorService;

        public SectorController(ISectorService sectorService) 
        {
            _SectorService = sectorService;
        }


        // Get all Sector
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Sector>>> GetAllSectors()
        {
            var sectors = await _SectorService.GetAllSectorsAsync();
            return Ok(sectors);
        }


        // Get sector by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sector>> GetSectorById(int id)
        {
            var sector = await _SectorService.GetSectorByIdAsync(id);
            if (sector == null) return NotFound();

            return Ok(sector);
        }


        // Create a Sector
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSector([FromForm] Sector sector)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _SectorService.CreateSectorAsync(sector);
            return CreatedAtAction(nameof(GetSectorById), new { id = sector.Id }, sector);
        }


        // Update a Sector
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateSector(int id, [FromForm] Sector sector)
        {
            if (id != sector.Id) return BadRequest();

            var existingUser = await _SectorService.GetSectorByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _SectorService.UpdateSectorAsync(sector);
            return NoContent();
        }

        // Delete a sector
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteSector(int id)
        {
            var user = await _SectorService.GetSectorByIdAsync(id);
            if (user == null) return NotFound();

            await _SectorService.SoftDeleteSectorAsync(id);
            return NoContent();
        }

    }
}
