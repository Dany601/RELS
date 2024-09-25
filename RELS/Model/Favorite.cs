namespace RELS.Model
{
    public class Favorite
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
