using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task CreatePropertyAsync(string propertyaddress, string squaremetersproperty, string cost, string propertydescription, string latitude, string altitude, int stateid, int typespropertyid, int sectorid);
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
        public async Task CreatePropertyAsync(string propertyaddress, string squaremetersproperty, string cost, string propertydescription, string latitude, string altitude, int stateid, int typespropertyid, int sectorid)
        {
            var state = await _context.States.FindAsync(stateid) ?? throw new Exception("State not found");
            var typeproperty = await _context.TypesProperties.FindAsync(typespropertyid) ?? throw new Exception("TypesProperty not found");
            var sector = await _context.Sectors.FindAsync(sectorid) ?? throw new Exception("Sector not found");
            
            var property = new Property
            {
                PropertyAddress = propertyaddress,
                SquareMetersProperty = squaremetersproperty,
                Cost = cost,
                PropertyDescription = propertydescription,
                Latitude = latitude,
                Altitude = altitude,
                State = state,
                TypesProperties = typeproperty,
                Sectors = sector,

            };
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