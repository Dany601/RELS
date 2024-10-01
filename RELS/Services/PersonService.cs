using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task SoftDeletePersonAsync(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // Get All People
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _personRepository.GetAllPeopleAsync();
        }

        // Get person by Id
        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }

        // Create a person
        public async Task CreatePersonAsync(Person person)
        {
            await _personRepository.CreatePersonAsync(person);
        }

        // Update a person
        public async Task UpdatePersonAsync(Person person)
        {
            try
            {
                await _personRepository.UpdatePersonAsync(person);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a person
        public async Task SoftDeletePersonAsync(int id)
        {
            await _personRepository.SoftDeletePersonAsync(id);
        }
    }
}
