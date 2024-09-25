using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }

    public class PermissionRepository : IPermissionRepository
    {
        private readonly RealEstateDbContext _context;

        public PermissionRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create Permission
        public async Task CreatePermissionAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();

        }
        // Get permission by Id
        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all permission
        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Permission
        public async Task UpdatePermissionAsync(Permission permission)

        {
            try
            {
                _context.Permissions.Update(permission);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete permission

        public async Task SoftDeletePermissionAsync(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission != null)
            {
                permission.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}

