namespace RELS.Model
{
    public class FavoriteHistory
    {
        public int Id { get; set; }
        public required string IdFavorite { get; set; }
        public required string Name { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
