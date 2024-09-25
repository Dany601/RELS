using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPropertyXOwnerRepository
    {
        Task<IEnumerable<PropertyXOwner>> GetAllPropertyXOwnerAsync();
        Task<PropertyXOwner> GetPropertyXOwnerByIdAsync(int id);
        Task CreatePropertyXOwnerAsync(PropertyXOwner propertyXOwner);
        Task UpdatePropertyXOwnerAsync(PropertyXOwner propertyXOwner);
        Task SoftDeletePropertyXOwnerAsync(int id);
    }

    public class PropertyXOwnerRepository : IPropertyXOwnerRepository
    {
        private readonly RealEstateDbContext _context;
        public PropertyXOwnerRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyXOwner>> GetAllPropertyXOwnerAsync()
        {
            return await _context.PropertiesXOwners
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<PropertyXOwner> GetPropertyXOwnerByIdAsync(int id)
        {
            return await _context.PropertiesXOwners
                .FirstOrDefaultAsync(u => u.OwnerId == id && !u.IsDeleted);
            
        }

        public async Task SoftDeletePropertyXOwnerAsync(int id)
        {
            var propertyXOwner = await _context.PropertiesXOwners.FindAsync(id);
            if (propertyXOwner != null)
            {
                propertyXOwner.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePropertyXOwnerAsync(PropertyXOwner propertyXOwner)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyXOwnerAsync(PropertyXOwner propertyXOwner)
        {
            throw new NotImplementedException();
        }
    }
}
