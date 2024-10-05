using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnerAsync();
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
        public async Task<IEnumerable<Owner>> GetAllOwnerAsync()
        {
            return await _context.Owners
                .Where(o => !o.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            return await _context.Owners
                .FirstOrDefaultAsync(o => o.OwnerId == id && !o.IsDeleted);
        }

        public async Task SoftDeleteOwnerAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                owner.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateOwnerAsync(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOwnerAsync(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
