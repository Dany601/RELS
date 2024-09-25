namespace RELS.Model
{
    public class Sector
    {
        public int Id { get; set; }
        public required string SerctorName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
