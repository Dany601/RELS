using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string name,string lastname,string email,string password, string identification, string cellphonenumber, int typedocument,int usertypeid);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Get user by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Create a user
        public async Task CreateUserAsync(string name, string lastname, string email, string password, string identification, string cellphonenumber, int typedocument, int usertypeid)
        {
            await _userRepository.CreateUserAsync(name, lastname,  email,  password, identification, cellphonenumber, typedocument, usertypeid);
        }

        // Update a user
        public async Task UpdateUserAsync(User user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a user
        public async Task SoftDeleteUserAsync(int id)
        {
            await _userRepository.SoftDeleteUserAsync(id);
        }
    }
}
