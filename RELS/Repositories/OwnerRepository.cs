using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(int id);
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task SoftDeleteOwnerAsync(int id);
    }

    public class OwnerRepository : IOwnerRepository
    {
        private readonly RealEstateDbContext _context;

        public OwnerRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        // Create Owner
        public async Task CreateOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();

        }
        // Get owner by Id
        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            return await _context.Owners.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all owner
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _context.Owners
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Owner
        public async Task UpdateOwnerAsync(Owner owner)

        {
            try
            {
                _context.Owners.Update(owner);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete owner

        public async Task SoftDeleteOwnerAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                owner.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
