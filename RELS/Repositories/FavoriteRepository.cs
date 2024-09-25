using RELS.Context;
using RELS.Model;
using Microsoft.EntityFrameworkCore;

namespace RELS.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllFavoritesAsync();
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

        // Create Favorite
        public async Task CreateFavoriteAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();

        }
        // Get favorite by Id
        public async Task<Favorite> GetFavoriteByIdAsync(int id)
        {
            return await _context.Favorites.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

        }
        // Get all favorite
        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync()
        {
            return await _context.Favorites
           .Where(s => !s.IsDeleted) // Avoid deleted items
           .ToListAsync();

        }
        // Update Favorite
        public async Task UpdateFavoriteAsync(Favorite favorite)

        {
            try
            {
                _context.Favorites.Update(favorite);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }

        }

        // Delete favorite

        public async Task SoftDeleteFavoriteAsync(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                favorite.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}

