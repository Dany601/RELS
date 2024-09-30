using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface ITypePropertyService
    {
        Task<IEnumerable<TypeProperty>> GetAllTypesPropertiesAsync();
        Task<TypeProperty> GetTypePropertyByIdAsync(int id);
        Task CreateTypePropertyAsync(TypeProperty typeproperty);
        Task UpdateTypePropertyAsync(TypeProperty typeproperty);
        Task SoftDeleteTypePropertyAsync(int id);
    }

    public class TypePropertyService : ITypePropertyService
    {
        private readonly ITypePropertyRepository _typepropertyRepository;

        public TypePropertyService(ITypePropertyRepository typepropertyRepository)
        {
            _typepropertyRepository = typepropertyRepository;
        }

        // Get All TypesProperties
        public async Task<IEnumerable<TypeProperty>> GetAllTypesPropertiesAsync()
        {
            return await _typepropertyRepository.GetAllTypesPropertiesAsync();
        }

        // Get typeproperty by Id
        public async Task<TypeProperty> GetTypePropertyByIdAsync(int id)
        {
            return await _typepropertyRepository.GetTypePropertyByIdAsync(id);
        }

        // Create a typeproperty
        public async Task CreateTypePropertyAsync(TypeProperty typeproperty)
        {
            await _typepropertyRepository.CreateTypePropertyAsync(typeproperty);
        }

        // Update a typeproperty
        public async Task UpdateTypePropertyAsync(TypeProperty typeproperty)
        {
            try
            {
                await _typepropertyRepository.UpdateTypePropertyAsync(typeproperty);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a typeproperty
        public async Task SoftDeleteTypePropertyAsync(int id)
        {
            await _typepropertyRepository.SoftDeleteTypePropertyAsync(id);
        }
    }
}
