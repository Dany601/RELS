namespace RELS.Model
{
    public class User
    {

        public int Id { get; set; }
        public virtual required UserType UserType { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
