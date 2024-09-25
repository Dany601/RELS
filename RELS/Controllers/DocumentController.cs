using RELS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RELS.Services;


namespace RELS.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _DocumentService;

        public DocumentController(IDocumentService DocumentService)
        {
            _DocumentService = DocumentService;
        }


        // Get all Document
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Document>>> GetAllDocuments()
        {
            var documents = await _DocumentService.GetAllDocumentsAsync();
            return Ok(documents);
        }


        // Get document by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Document>> GetDocumentById(int id)
        {
            var document = await _DocumentService.GetDocumentByIdAsync(id);
            if (document == null) return NotFound();

            return Ok(document);
        }


        // Create a Document
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDocument([FromForm] Document document)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _DocumentService.CreateDocumentAsync(document);
            return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, document);
        }


        // Update a Document
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateDocument(int id, [FromForm] Document document)
        {
            if (id != document.Id) return BadRequest();

            var existingUser = await _DocumentService.GetDocumentByIdAsync(id);
            if (existingUser == null) return NotFound();

            await _DocumentService.UpdateDocumentAsync(document);
            return NoContent();
        }

        // Delete a document
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteDocument(int id)
        {
            var user = await _DocumentService.GetDocumentByIdAsync(id);
            if (user == null) return NotFound();

            await _DocumentService.SoftDeleteDocumentAsync(id);
            return NoContent();
        }

    }
}
