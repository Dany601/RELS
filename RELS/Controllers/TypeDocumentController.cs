using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocumentService _TypeDocumentService;

        public TypeDocumentController(ITypeDocumentService typedocumentService)
        {
            _TypeDocumentService = typedocumentService;
        }


        // Get all TypeDocument
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeDocument>>> GetAllTypesDocuments()
        {
            var typedocuments = await _TypeDocumentService.GetAllTypesDocumentsAsync();
            return Ok(typedocuments);
        }


        // Get typedocument by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeDocument>> GetTypeDocumentById(int id)
        {
            var typedocument = await _TypeDocumentService.GetTypeDocumentByIdAsync(id);
            if (typedocument == null) return NotFound();

            return Ok(typedocument);
        }


        // Create a TypeDocument
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeDocument([FromForm] TypeDocument typedocument)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _TypeDocumentService.CreateTypeDocumentAsync(typedocument);
            return CreatedAtAction(nameof(GetTypeDocumentById), new { id = typedocument.Id }, typedocument);
        }


        // Update a TypeDocument
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateTypeDocument(int id, [FromForm] TypeDocument typedocument)
        {
            if (id != typedocument.Id) return BadRequest();

            var existingTypeDocument = await _TypeDocumentService.GetTypeDocumentByIdAsync(id);
            if (existingTypeDocument == null) return NotFound();

            await _TypeDocumentService.UpdateTypeDocumentAsync(typedocument);
            return NoContent();
        }

        // Delete a typedocument
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteTypeDocument(int id)
        {
            var typedocument = await _TypeDocumentService.GetTypeDocumentByIdAsync(id);
            if (typedocument == null) return NotFound();

            await _TypeDocumentService.SoftDeleteTypeDocumentAsync(id);
            return NoContent();
        }

    }
}
