namespace RELS.Model
{
    public class Favorite
    {
        public int Id { get; set; } 
        public required string Title { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
