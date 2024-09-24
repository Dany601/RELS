using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task CreateDocumentAsync(Document document);
        Task UpdateDocumentAsync(Document document);
        Task SoftDeleteDocumentAsync(int id);
    }

    public class DocumentRepository : IDocumentRepository
    {
        private readonly RealEstateDbContext _context;

        public DocumentRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        
        // Create Document
        public async Task CreateDocumentAsync(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();

        }
        // Get document by Id
        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _context.Documents
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all document
        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _context.Documents.AsNoTracking()
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Document
        public async Task UpdateDocumentAsync(Document document)

        {
            try
            {
                _context.Documents.Update(document);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete document

        public async Task SoftDeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                document.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
