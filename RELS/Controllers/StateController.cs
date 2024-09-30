using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _StateService;

        public StateController(IStateService stateService)
        {
            _StateService = stateService;
        }


        // Get all State
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<State>>> GetAllStates()
        {
            var states = await _StateService.GetAllStatesAsync();
            return Ok(states);
        }


        // Get state by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<State>> GetStateById(int id)
        {
            var state = await _StateService.GetStateByIdAsync(id);
            if (state == null) return NotFound();

            return Ok(state);
        }


        // Create a State
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateState([FromForm] State state)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _StateService.CreateStateAsync(state);
            return CreatedAtAction(nameof(GetStateById), new { id = state.Id }, state);
        }


        // Update a State
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateState(int id, [FromForm] State state)
        {
            if (id != state.Id) return BadRequest();

            var existingUser = await _StateService.GetStateByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _StateService.UpdateStateAsync(state);
            return NoContent();
        }

        // Delete a state
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteState(int id)
        {
            var user = await _StateService.GetStateByIdAsync(id);
            if (user == null) return NotFound();

            await _StateService.SoftDeleteStateAsync(id);
            return NoContent();
        }

    }
}
