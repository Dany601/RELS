using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task SoftDeletePersonAsync(int id);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly RealEstateDbContext _context;
        public PersonRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await _context.People
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.People
                .FirstOrDefaultAsync(u => u.PersonId == id && !u.IsDeleted);
        }

        public async Task SoftDeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                person.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
