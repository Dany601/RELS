namespace RELS.Model
{
    public class OwnerHistory
    {
        public int Id { get; set; }
        public required string IdOwner { get; set; }
        public required string Person { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
