using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> GetAllSectorsAsync();
        Task<Sector> GetSectorByIdAsync(int id);
        Task CreateSectorAsync(Sector sector);
        Task UpdateSectorAsync(Sector sector);
        Task SoftDeleteSectorAsync(int id);
    }

    public class SectorRepository : ISectorRepository
    {
        private readonly RealEstateDbContext _context;

        public SectorRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create Sector
        public async Task CreateSectorAsync(Sector sector)
        {
            await _context.Sectors.AddAsync(sector);
            await _context.SaveChangesAsync();

        }
        // Get sector by Id
        public async Task<Sector> GetSectorByIdAsync(int id)
        {
            return await _context.Sectors.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all sector
        public async Task<IEnumerable<Sector>> GetAllSectorsAsync()
        {
            return await _context.Sectors
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Sector
        public async Task UpdateSectorAsync(Sector sector)

        {
            try
            {
                _context.Sectors.Update(sector);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete sector

        public async Task SoftDeleteSectorAsync(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector != null)
            {
                sector.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
