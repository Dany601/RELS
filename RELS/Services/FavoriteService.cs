using RELS.Model;
using RELS.Repositories;


namespace RELS.Services
{
    public interface IFavoriteService
    {
        Task<IEnumerable<Favorite>> GetAllFavoritesAsync();
        Task<Favorite> GetFavoriteByIdAsync(int id);
        Task CreateFavoriteAsync(Favorite favorite);
        Task UpdateFavoriteAsync(Favorite favorite);
        Task SoftDeleteFavoriteAsync(int id);
    }

    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        // Get All Favorites
        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync()
        {
            return await _favoriteRepository.GetAllFavoritesAsync();
        }

        // Get favorite by Id
        public async Task<Favorite> GetFavoriteByIdAsync(int id)
        {
            return await _favoriteRepository.GetFavoriteByIdAsync(id);
        }

        // Create a favorite
        public async Task CreateFavoriteAsync(Favorite favorite)
        {
            await _favoriteRepository.CreateFavoriteAsync(favorite);
        }

        // Update a favorite
        public async Task UpdateFavoriteAsync(Favorite favorite)
        {
            try
            {
                await _favoriteRepository.UpdateFavoriteAsync(favorite);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a favorite
        public async Task SoftDeleteFavoriteAsync(int id)
        {
            await _favoriteRepository.SoftDeleteFavoriteAsync(id);
        }
    }
}
