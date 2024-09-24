using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface ILessorRepository
    {
        Task<IEnumerable<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync(int id);
        Task CreateLessorAsync(Lessor lessor);
        Task UpdateLessorAsync(Lessor lessor);
        Task SoftDeleteLessorAsync(int id);
    }

    public class LessorRepository : ILessorRepository
    {
        private readonly RealEstateDbContext _context;

        public LessorRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create Lessor
        public async Task CreateLessorAsync(Lessor lessor)
        {
            await _context.Lessors.AddAsync(lessor);
            await _context.SaveChangesAsync();

        }
        // Get lessor by Id
        public async Task<Lessor> GetLessorByIdAsync(int id)
        {
            return await _context.Lessors
            .FirstOrDefaultAsync(s => s.LessorId == id && !s.IsDeleted);

        }
        // Get all lessor
        public async Task<IEnumerable<Lessor>> GetAllLessorsAsync()
        {
            return await _context.Lessors.AsNoTracking()
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Lessor
        public async Task UpdateLessorAsync(Lessor lessor)

        {
            try
            {
                _context.Lessors.Update(lessor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete lessor

        public async Task SoftDeleteLessorAsync(int id)
        {
            var lessor = await _context.Lessors.FindAsync(id);
            if (lessor != null)
            {
                lessor.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
