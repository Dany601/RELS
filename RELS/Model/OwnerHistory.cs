namespace RELS.Model
{
    public class OwnerHistory
    {
        public int Id { get; set; }
        public required string IdOwner { get; set; }
        public required string User { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
