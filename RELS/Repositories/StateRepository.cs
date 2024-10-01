using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllStatesAsync();
        Task<State> GetStateByIdAsync(int id);
        Task CreateStateAsync(State state);
        Task UpdateStateAsync(State state);
        Task SoftDeleteStateAsync(int id);
    }

    public class StateRepository : IStateRepository
    {
        private readonly RealEstateDbContext _context;

        public StateRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create State
        public async Task CreateStateAsync(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();

        }
        // Get state by Id
        public async Task<State> GetStateByIdAsync(int id)
        {
            return await _context.States.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all state
        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _context.States
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update State
        public async Task UpdateStateAsync(State state)

        {
            try
            {
                _context.States.Update(state);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete state

        public async Task SoftDeleteStateAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state != null)
            {
                state.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}

