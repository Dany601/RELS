using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
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

        // Create Person
        public async Task CreatePersonAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

        }
        // Get person by Id
        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.People.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all person
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Person
        public async Task UpdatePersonAsync(Person person)

        {
            try
            {
                _context.People.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete person

        public async Task SoftDeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                person.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
