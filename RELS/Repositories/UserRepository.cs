using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;

namespace RELS.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string name, string lastname, string email, string password, string identification, string cellphonenumber, int typedocument, int usertypeid);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly RealEstateDbContext _context;

        public UserRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create User
        public async Task CreateUserAsync(string name, string lastname, string email, string password, string identification, string cellphonenumber,int typedocument, int usertypeid)
        {
            // Fetch the UserType
            var userType = await _context.UserTypes.FindAsync(usertypeid) ?? throw new Exception("UserType not found");
            var typeDocument = await _context.TypesDocuments.FindAsync(typedocument) ?? throw new Exception("TypeDocument not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, password);

            var user = new User
            {
                Name = name,
                LastName = lastname,
                Email = email,
                Password = hashedPassword,
                Identification = identification,
                CellPhoneNumber = cellphonenumber,
                TypeDocument = typeDocument,
                UserType = userType,

            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


        }
        // Get user by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all user
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update User
        public async Task UpdateUserAsync(User user)

        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete .user

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

        // Check user password and email
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            // Fetch the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");

            // User does not exist
            if (user == null) return false;

            // Initialize PasswordHasher
            var passwordHasher = new PasswordHasher<User>();

            // Verify the password
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            // Check if password is correct
            if (userVerification == PasswordVerificationResult.Success) return true;

            // Password is invalid
            return false;
        }

    }
}