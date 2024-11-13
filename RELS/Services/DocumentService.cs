using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task CreateDocumentAsync(string filerute, DateOnly date, int lessor);
        Task UpdateDocumentAsync(Document document);
        Task SoftDeleteDocumentAsync(int id);
    }

    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        // Get All Documents
        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }

        // Get document by Id
        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _documentRepository.GetDocumentByIdAsync(id);
        }

        // Create a document
        public async Task CreateDocumentAsync(string filerute, DateOnly date, int lessor)
        {
            await _documentRepository.CreateDocumentAsync(filerute, date, lessor);
        }

        // Update a document
        public async Task UpdateDocumentAsync(Document document)
        {
            try
            {
                await _documentRepository.UpdateDocumentAsync(document);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a document
        public async Task SoftDeleteDocumentAsync(int id)
        {
            await _documentRepository.SoftDeleteDocumentAsync(id);
        }
    }
}