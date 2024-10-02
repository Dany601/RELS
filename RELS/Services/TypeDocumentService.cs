using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface ITypeDocumentService
    {
        Task<IEnumerable<TypeDocument>> GetAllTypesDocumentsAsync();
        Task<TypeDocument> GetTypeDocumentByIdAsync(int id);
        Task CreateTypeDocumentAsync(TypeDocument typedocument);
        Task UpdateTypeDocumentAsync(TypeDocument typedocument);
        Task SoftDeleteTypeDocumentAsync(int id);
    }

    public class TypeDocumentService : ITypeDocumentService
    {
        private readonly ITypeDocumentRepository _typedocumentRepository;

        public TypeDocumentService(ITypeDocumentRepository typedocumentRepository)
        {
            _typedocumentRepository = typedocumentRepository;
        }

        // Get All TypesDocuments
        public async Task<IEnumerable<TypeDocument>> GetAllTypesDocumentsAsync()
        {
            return await _typedocumentRepository.GetAllTypesDocumentsAsync();
        }

        // Get typedocument by Id
        public async Task<TypeDocument> GetTypeDocumentByIdAsync(int id)
        {
            return await _typedocumentRepository.GetTypeDocumentByIdAsync(id);
        }

        // Create a typedocument
        public async Task CreateTypeDocumentAsync(TypeDocument typedocument)
        {
            await _typedocumentRepository.CreateTypeDocumentAsync(typedocument);
        }

        // Update a typedocument
        public async Task UpdateTypeDocumentAsync(TypeDocument typedocument)
        {
            try
            {
                await _typedocumentRepository.UpdateTypeDocumentAsync(typedocument);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a typedocument
        public async Task SoftDeleteTypeDocumentAsync(int id)
        {
            await _typedocumentRepository.SoftDeleteTypeDocumentAsync(id);
        }
    }
}

