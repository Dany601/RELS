namespace RELS.Model
{
    public class PermissionXUser

    {
        

            public virtual required Permission Permission { get; set; }

            public virtual required UserType UserType { get; set; }
        

            public bool IsDeleted { get; set; } = false;


    }
}
