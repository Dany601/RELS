using RELS.Model;
using RELS.Repositories;

namespace RELS.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
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

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await _personRepository.GetAllPersonAsync();
        }
        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }
        public Task CreatePersonAsync(Person person)
        {
            return _personRepository.CreatePersonAsync(person);
        }
        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdatePersonAsync(person);
        }
        public async Task SoftDeletePersonAsync(int id)
        {
            await _personRepository.SoftDeletePersonAsync(id);
        }

    }
}
