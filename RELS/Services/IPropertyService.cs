using RELS.Model;
using RELS.Repositories;

namespace RELS.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllPropertyAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task CreatePropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task SoftDeletePropertyAsync(int id);
    }

    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAllPropertyAsync()
        {
            return await _propertyRepository.GetAllPropertyAsync();
        }
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }
        public Task CreatePropertyAsync(Property property)
        {
            return _propertyRepository.CreatePropertyAsync(property);
        }
        public async Task UpdatePropertyAsync(Property property)
        {
            await _propertyRepository.UpdatePropertyAsync(property);
        }
        public async Task SoftDeletePropertyAsync(int id)
        {
            await _propertyRepository.SoftDeletePropertyAsync(id);
        }

    }
}
