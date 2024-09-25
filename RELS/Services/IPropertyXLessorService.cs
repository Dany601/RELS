using RELS.Model;
using RELS.Repositories;

namespace RELS.Services
{
    public interface IPropertyXLessorService
    {
        Task<IEnumerable<PropertyXLessor>> GetAllPropertyXLessorAsync();
        Task<PropertyXLessor> GetPropertyXLessorByIdAsync(int id);
        Task CreatePropertyXLessorAsync(PropertyXLessor propertyXLessor);
        Task UpdatePropertyXLessorAsync(PropertyXLessor propertyXLessor);
        Task SoftDeletePropertyXLessorAsync(int id);
    }

    public class PropertyXLessorService : IPropertyXLessorService
    {
        private readonly IPropertyXLessorRepository _propertyXLessorRepository;
        public PropertyXLessorService(IPropertyXLessorRepository propertyXLessorRepository)
        {
            _propertyXLessorRepository = propertyXLessorRepository;
        }

        public async Task<IEnumerable<PropertyXLessor>> GetAllPropertyXLessorAsync()
        {
            return await _propertyXLessorRepository.GetAllPropertyXLessorAsync();
        }
        public async Task<PropertyXLessor> GetPropertyXLessorByIdAsync(int id)
        {
            return await _propertyXLessorRepository.GetPropertyXLessorByIdAsync(id);
        }
        public Task CreatePropertyXLessorAsync(PropertyXLessor propertyXLessor)
        {
            return _propertyXLessorRepository.CreatePropertyXLessorAsync(propertyXLessor);
        }
        public async Task UpdatePropertyXLessorAsync(PropertyXLessor propertyXLessor)
        {
            await _propertyXLessorRepository.UpdatePropertyXLessorAsync(propertyXLessor);
        }
        public async Task SoftDeletePropertyXLessorAsync(int id)
        {
            await _propertyXLessorRepository.SoftDeletePropertyXLessorAsync(id);
        }

    }
}
