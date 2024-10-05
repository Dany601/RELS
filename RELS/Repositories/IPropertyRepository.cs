using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertyAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task CreatePropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task SoftDeletePropertyAsync(int id);
    }

    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext _context;
        public PropertyRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Property>> GetAllPropertyAsync()
        {
            return await _context.Properties
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                .FirstOrDefaultAsync(u => u.PropertyId == id && !u.IsDeleted);
        }

        public async Task SoftDeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                property.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
