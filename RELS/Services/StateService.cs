using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllStatesAsync();
        Task<State> GetStateByIdAsync(int id);
        Task CreateStateAsync(State state);
        Task UpdateStateAsync(State state);
        Task SoftDeleteStateAsync(int id);
    }

    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // Get All States
        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _stateRepository.GetAllStatesAsync();
        }

        // Get state by Id
        public async Task<State> GetStateByIdAsync(int id)
        {
            return await _stateRepository.GetStateByIdAsync(id);
        }

        // Create a state
        public async Task CreateStateAsync(State state)
        {
            await _stateRepository.CreateStateAsync(state);
        }

        // Update a state
        public async Task UpdateStateAsync(State state)
        {
            try
            {
                await _stateRepository.UpdateStateAsync(state);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a state
        public async Task SoftDeleteStateAsync(int id)
        {
            await _stateRepository.SoftDeleteStateAsync(id);
        }
    }
}