using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task CreatePropertyAsync(string propertyaddress, string squaremetersproperty, string cost, string propertydescription, string latitude,string altitude, int stateid , int typespropertyid, int sectorid);
        Task UpdatePropertyAsync(Property property);
        Task SoftDeletePropertyAsync(int id);
    }

    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // Get All Properties
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetAllPropertiesAsync();
        }

        // Get property by Id
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }

        // Create a property
        public async Task CreatePropertyAsync(string propertyaddress, string squaremetersproperty, string cost, string propertydescription, string latitude, string altitude, int stateid, int typespropertyid, int sectorid)
        {
            await _propertyRepository.CreatePropertyAsync(propertyaddress,squaremetersproperty,cost,propertydescription, latitude, altitude,  stateid, typespropertyid, sectorid);
        }

        // Update a property
        public async Task UpdatePropertyAsync(Property property)
        {
            try
            {
                await _propertyRepository.UpdatePropertyAsync(property);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a property
        public async Task SoftDeletePropertyAsync(int id)
        {
            await _propertyRepository.SoftDeletePropertyAsync(id);
        }
    }
}
