using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPermissionXUserRepository
    {
        Task<IEnumerable<PermissionXUser>> GetAllPermissionXUserAsync();
        Task<PermissionXUser> GetPermissionXUserByIdAsync(int id);
        Task CreatePermissionXUserAsync(PermissionXUser permissionXUser);
        Task UpdatePermissionXUserAsync(PermissionXUser permissionXUser);
        Task SoftDeletePermissionXUserAsync(int id);
    }

    public class PermissionXUserRepository : IPermissionXUserRepository
    {
        private readonly RealEstateDbContext _context;
        public PermissionXUserRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PermissionXUser>> GetAllPermissionXUserAsync()
        {
            return await _context.PermissionsXUser
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<PermissionXUser> GetPermissionXUserByIdAsync(int id)
        {
            return await _context.PermissionsXUser
                .FirstOrDefaultAsync(u => u.PermissionId == id && !u.IsDeleted);
        }

        public async Task SoftDeletePermissionXUserAsync(int id)
        {
            var permissionXUser = await _context.PermissionsXUser.FindAsync(id);
            if (permissionXUser != null)
            {
                permissionXUser.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePermissionXUserAsync(PermissionXUser permissionXUser)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePermissionXUserAsync(PermissionXUser permissionXUser)
        {
            throw new NotImplementedException();
        }
    }
}
