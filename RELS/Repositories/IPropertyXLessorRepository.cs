using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPropertyXLessorRepository
    {
        Task<IEnumerable<PropertyXLessor>> GetAllPropertyXLessorAsync();
        Task<PropertyXLessor> GetPropertyXLessorByIdAsync(int id);
        Task CreatePropertyXLessorAsync(PropertyXLessor propertyXLessor);
        Task UpdatePropertyXLessorAsync(PropertyXLessor propertyXLessor);
        Task SoftDeletePropertyXLessorAsync(int id);
    }

    public class PropertyXLessorRepository : IPropertyXLessorRepository
    {
        private readonly RealEstateDbContext _context;
        public PropertyXLessorRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyXLessor>> GetAllPropertyXLessorAsync()
        {
            return await _context.PropertiesXLessors
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<PropertyXLessor> GetPropertyXLessorByIdAsync(int id)
        {
            return await _context.PropertiesXLessors
                .FirstOrDefaultAsync(u => u.PropertyId == id && !u.IsDeleted);
        }

        public async Task SoftDeletePropertyXLessorAsync(int id)
        {
            var propertyXLessor = await _context.PropertiesXLessors.FindAsync(id);
            if (propertyXLessor != null)
            {
                propertyXLessor.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePropertyXLessorAsync(PropertyXLessor propertyXLessor)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyXLessorAsync(PropertyXLessor propertyXLessor)
        {
            throw new NotImplementedException();
        }
    }
}
