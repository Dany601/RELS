using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;
namespace RELS.Repositories
{
    public interface ITypePropertyRepository
    {
        Task<IEnumerable<TypeProperty>> GetAllTypesPropertiesAsync();
        Task<TypeProperty> GetTypePropertyByIdAsync(int id);
        Task CreateTypePropertyAsync(TypeProperty typeproperty);
        Task UpdateTypePropertyAsync(TypeProperty typeproperty);
        Task SoftDeleteTypePropertyAsync(int id);
    }
  public class TypePropertyRepository : ITypePropertyRepository
    {
        private readonly RealEstateDbContext _context;

        public TypePropertyRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create TypeProperty
        public async Task CreateTypePropertyAsync(TypeProperty typeproperty)
        {
            await _context.TypesProperties.AddAsync(typeproperty);
            await _context.SaveChangesAsync();

        }
        // Get typeproperty by Id
        public async Task<TypeProperty> GetTypePropertyByIdAsync(int id)
        {
            return await _context.TypesProperties.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all typeproperty
        public async Task<IEnumerable<TypeProperty>> GetAllTypesPropertiesAsync()
        {
            return await _context.TypesProperties
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update TypeProperty
        public async Task UpdateTypePropertyAsync(TypeProperty typeproperty)

        {
            try
            {
                _context.TypesProperties.Update(typeproperty);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete TypeProperty

        public async Task SoftDeleteTypePropertyAsync(int id)
        {
            var typeproperty = await _context.TypesProperties.FindAsync(id);
            if (typeproperty != null)
            {
                typeproperty.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}