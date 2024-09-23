using Microsoft.EntityFrameworkCore;
using RELS.Context;
using RELS.Model;

namespace RELS.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocumentAsync();
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
        public async Task<IEnumerable<Document>> GetAllDocumentAsync()
        {
            return await _context.Documents
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _context.Documents
                .FirstOrDefaultAsync(u => u.DocumentId == id && !u.IsDeleted);
        }

        public async Task SoftDeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                document.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateDocumentAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocumentAsync(Document document)
        {
            throw new NotImplementedException();
        }
    }
}

