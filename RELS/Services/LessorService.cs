using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface ILessorService
    {
        Task<IEnumerable<Lessor>> GetAllLessorsAsync();
        Task<Lessor> GetLessorByIdAsync(int id);
        Task CreateLessorAsync(Lessor lessor);
        Task UpdateLessorAsync(Lessor lessor);
        Task SoftDeleteLessorAsync(int id);
    }

    public class LessorService : ILessorService
    {
        private readonly ILessorRepository _lessorRepository;

        public LessorService(ILessorRepository lessorRepository)
        {
            _lessorRepository = lessorRepository;
        }

        // Get All Lessors
        public async Task<IEnumerable<Lessor>> GetAllLessorsAsync()
        {
            return await _lessorRepository.GetAllLessorsAsync();
        }

        // Get lessor by Id
        public async Task<Lessor> GetLessorByIdAsync(int id)
        {
            return await _lessorRepository.GetLessorByIdAsync(id);
        }

        // Create a lessor
        public async Task CreateLessorAsync(Lessor lessor)
        {
            await _lessorRepository.CreateLessorAsync(lessor);
        }

        // Update a lessor
        public async Task UpdateLessorAsync(Lessor lessor)
        {
            try
            {
                await _lessorRepository.UpdateLessorAsync(lessor);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a lessor
        public async Task SoftDeleteLessorAsync(int id)
        {
            await _lessorRepository.SoftDeleteLessorAsync(id);
        }
    }
}
