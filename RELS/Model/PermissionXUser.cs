namespace RELS.Model
{
    public class PermissionXUser
    {
        
            public int UserTypeId { get; set; }
            public  int PermissionId { get; set; }

            public virtual required Permission Permission { get; set; }

            public virtual required UserType UserType { get; set; }
            public bool IsDeleted { get; set; } = false;

    }
}
