using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
        Task SoftDeleteUserTypeAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _usertypeRepository;

        public UserTypeService(IUserTypeRepository usertypeRepository)
        {
            _usertypeRepository = usertypeRepository;
        }

        // Get All UserTypes
        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _usertypeRepository.GetAllUserTypesAsync();
        }

        // Get usertype by Id
        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _usertypeRepository.GetUserTypeByIdAsync(id);
        }

        // Create a usertype
        public async Task CreateUserTypeAsync(UserType usertype)
        {
            await _usertypeRepository.CreateUserTypeAsync(usertype);
        }

        // Update a usertype
        public async Task UpdateUserTypeAsync(UserType usertype)
        {
            try
            {
                await _usertypeRepository.UpdateUserTypeAsync(usertype);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a usertype
        public async Task SoftDeleteUserTypeAsync(int id)
        {
            await _usertypeRepository.SoftDeleteUserTypeAsync(id);
        }
    }
}

