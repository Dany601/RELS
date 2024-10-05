using RELS.Model;
using RELS.Repositories;

namespace RELS.Services
{
    public interface IPropertyXOwnerService
    {
        
        Task<IEnumerable<PropertyXOwner>> GetAllPropertyXOwnerAsync();
        Task<PropertyXOwner> GetPropertyXOwnerByIdAsync(int id);
        Task CreatePropertyXOwnerAsync(PropertyXOwner propertyXOwner);
        Task UpdatePropertyXOwnerAsync(PropertyXOwner propertyXOwner);
        Task SoftDeletePropertyXOwnerAsync(int id);
    }

    public class PropertyXOwnerService : IPropertyXOwnerService
    { 
        private readonly IPropertyXOwnerRepository _propertyXOwnerRepository;
        public PropertyXOwnerService(IPropertyXOwnerRepository propertyXOwnerRepository)
        {
            _propertyXOwnerRepository = propertyXOwnerRepository;
        }

        public async Task<IEnumerable<PropertyXOwner>> GetAllPropertyXOwnerAsync()
        {
            return await _propertyXOwnerRepository.GetAllPropertyXOwnerAsync();
        }
        public async Task<PropertyXOwner> GetPropertyXOwnerByIdAsync(int id)
        {
            return await _propertyXOwnerRepository.GetPropertyXOwnerByIdAsync(id);
        }
        public Task CreatePropertyXOwnerAsync(PropertyXOwner propertyXOwner)
        {
            return _propertyXOwnerRepository.CreatePropertyXOwnerAsync(propertyXOwner);
        }
        public async Task UpdatePropertyXOwnerAsync(PropertyXOwner propertyXOwner)
        {
            await _propertyXOwnerRepository.UpdatePropertyXOwnerAsync(propertyXOwner);
        }
        public async Task SoftDeletePropertyXOwnerAsync(int id)
        {
            await _propertyXOwnerRepository.SoftDeletePropertyXOwnerAsync(id);
        }

    }
}
