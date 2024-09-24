using RELS.Model;
using RELS.Repositories;

namespace RELS.Services
{
    public interface IPermissionXUserService
    {
        Task<IEnumerable<PermissionXUser>> GetAllPermissionXUserAsync();
        Task<PermissionXUser> GetPermissionXUserByIdAsync(int id);
        Task CreatePermissionXUserAsync(PermissionXUser permissionXUser);
        Task UpdatePermissionXUserAsync(PermissionXUser permissionXUser);
        Task SoftDeletePermissionXUserAsync(int id);
    }

    public class PermissionXUserService : IPermissionXUserService
    {
        private readonly IPermissionXUserRepository _permissionXUserRepository;
        public PermissionXUserService(IPermissionXUserRepository permissionXUserRepository)
        {
            _permissionXUserRepository = permissionXUserRepository;
        }

        public async Task<IEnumerable<PermissionXUser>> GetAllPermissionXUserAsync()
        {
            return await _permissionXUserRepository.GetAllPermissionXUserAsync();
        }
        public async Task<PermissionXUser> GetPermissionXUserByIdAsync(int id)
        {
            return await _permissionXUserRepository.GetPermissionXUserByIdAsync(id);
        }
        public Task CreatePermissionXUserAsync(PermissionXUser permissionXUser)
        {
            return _permissionXUserRepository.CreatePermissionXUserAsync(permissionXUser);
        }
        public async Task UpdatePermissionXUserAsync(PermissionXUser permissionXUser)
        {
            await _permissionXUserRepository.UpdatePermissionXUserAsync(permissionXUser);
        }
        public async Task SoftDeletePermissionXUserAsync(int id)
        {
            await _permissionXUserRepository.SoftDeletePermissionXUserAsync(id);
        }

    }
}
