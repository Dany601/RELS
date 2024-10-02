using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
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

        // Create Property
        public async Task CreatePropertyAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();

        }
        // Get property by Id
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all property
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _context.Properties
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Property
        public async Task UpdatePropertyAsync(Property property)

        {
            try
            {
                _context.Properties.Update(property);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete .property

        public async Task SoftDeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                property.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}