namespace RELS.Model
{
    public class PermissionHistory
    {
        public int Id { get; set; }
        public required string IdPermission { get; set; }
        public required string Name { get; set; }
        
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }

    }
}
