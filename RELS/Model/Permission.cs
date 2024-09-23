namespace RELS.Model
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
