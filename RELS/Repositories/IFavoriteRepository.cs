using Microsoft.EntityFrameworkCore;
using RELS.Context;
using RELS.Model;

namespace RELS.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllFavoriteAsync();
        Task<Favorite> GetFavoriteByIdAsync(int id);
        Task CreateFavoriteAsync(Favorite favorite);
        Task UpdateFavoriteAsync(Favorite favorite);
        Task SoftDeleteFavoriteAsync(int id);
    }

    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly RealEstateDbContext _context;
        public FavoriteRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Favorite>> GetAllFavoriteAsync()
        {
            return await _context.Favorites
                .Where(u => !u.IsDeleted)    //excluye eliminados
                .ToListAsync();
        }

        public async Task<Favorite> GetFavoriteByIdAsync(int id)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(u => u.FavoriteId == id && !u.IsDeleted);
        }

        public async Task SoftDeleteFavoriteAsync(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                favorite.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateFavoriteAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFavoriteAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }
    }
}
