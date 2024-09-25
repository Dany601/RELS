using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(int id);
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task SoftDeleteOwnerAsync(int id);
    }

    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // Get All Owners
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllOwnersAsync();
        }

        // Get owner by Id
        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            return await _ownerRepository.GetOwnerByIdAsync(id);
        }

        // Create a owner
        public async Task CreateOwnerAsync(Owner owner)
        {
            await _ownerRepository.CreateOwnerAsync(owner);
        }

        // Update a owner
        public async Task UpdateOwnerAsync(Owner owner)
        {
            try
            {
                await _ownerRepository.UpdateOwnerAsync(owner);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a owner
        public async Task SoftDeleteOwnerAsync(int id)
        {
            await _ownerRepository.SoftDeleteOwnerAsync(id);
        }
    }
}
