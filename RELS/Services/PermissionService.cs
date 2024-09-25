using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        // Get All Permissions
        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _permissionRepository.GetAllPermissionsAsync();
        }

        // Get permission by Id
        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _permissionRepository.GetPermissionByIdAsync(id);
        }

        // Create a permission
        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.CreatePermissionAsync(permission);
        }

        // Update a permission
        public async Task UpdatePermissionAsync(Permission permission)
        {
            try
            {
                await _permissionRepository.UpdatePermissionAsync(permission);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a permission
        public async Task SoftDeletePermissionAsync(int id)
        {
            await _permissionRepository.SoftDeletePermissionAsync(id);
        }
    }
}
