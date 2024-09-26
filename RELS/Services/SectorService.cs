using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface ISectorService
    {
        Task<IEnumerable<Sector>> GetAllSectorsAsync();
        Task<Sector> GetSectorByIdAsync(int id);
        Task CreateSectorAsync(Sector sector);
        Task UpdateSectorAsync(Sector sector);
        Task SoftDeleteSectorAsync(int id);
    }

    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        // Get All Sectors
        public async Task<IEnumerable<Sector>> GetAllSectorsAsync()
        {
            return await _sectorRepository.GetAllSectorsAsync();
        }

        // Get sector by Id
        public async Task<Sector> GetSectorByIdAsync(int id)
        {
            return await _sectorRepository.GetSectorByIdAsync(id);
        }

        // Create a sector
        public async Task CreateSectorAsync(Sector sector)
        {
            await _sectorRepository.CreateSectorAsync(sector);
        }

        // Update a sector
        public async Task UpdateSectorAsync(Sector sector)
        {
            try
            {
                await _sectorRepository.UpdateSectorAsync(sector);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a sector
        public async Task SoftDeleteSectorAsync(int id)
        {
            await _sectorRepository.SoftDeleteSectorAsync(id);
        }
    }
}
