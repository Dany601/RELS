using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface ITypeDocumentRepository
    {
        Task<IEnumerable<TypeDocument>> GetAllTypesDocumentsAsync();
        Task<TypeDocument> GetTypeDocumentByIdAsync(int id);
        Task CreateTypeDocumentAsync(TypeDocument typedocument);
        Task UpdateTypeDocumentAsync(TypeDocument typedocument);
        Task SoftDeleteTypeDocumentAsync(int id);
    }

    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private readonly RealEstateDbContext _context;

        public TypeDocumentRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create TypeDocument
        public async Task CreateTypeDocumentAsync(TypeDocument typedocument)
        {
            await _context.TypesDocuments.AddAsync(typedocument);
            await _context.SaveChangesAsync();

        }
        // Get typedocument by Id
        public async Task<TypeDocument> GetTypeDocumentByIdAsync(int id)
        {
            return await _context.TypesDocuments.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all typedocument
        public async Task<IEnumerable<TypeDocument>> GetAllTypesDocumentsAsync()
        {
            return await _context.TypesDocuments
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update TypeDocument
        public async Task UpdateTypeDocumentAsync(TypeDocument typedocument)

        {
            try
            {
                _context.TypesDocuments.Update(typedocument);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete .typedocument

        public async Task SoftDeleteTypeDocumentAsync(int id)
        {
            var typedocument = await _context.TypesDocuments.FindAsync(id);
            if (typedocument != null)
            {
                typedocument.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
