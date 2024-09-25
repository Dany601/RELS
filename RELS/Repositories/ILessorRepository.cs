using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface ILessorRepository
    {
        Task<IEnumerable<Lessor>> GetAllLessorAsync();
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
        public async Task<IEnumerable<Lessor>> GetAllLessorAsync()
        {
            return await _context.Lessors
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Lessor> GetLessorByIdAsync(int id)
        {
            return await _context.Lessors
                .FirstOrDefaultAsync(u => u.LessorId == id && !u.IsDeleted);
        }

        public async Task SoftDeleteLessorAsync(int id)
        {
            var lessor = await _context.Lessors.FindAsync(id);
            if (lessor != null)
            {
                lessor.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateLessorAsync(Lessor lessor)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLessorAsync(Lessor lessor)
        {
            throw new NotImplementedException();
        }
    }
}
