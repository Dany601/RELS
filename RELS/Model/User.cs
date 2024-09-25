namespace RELS.Model
{
    public class User
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }

        public virtual required UserType UserType { get; set; }
        public virtual required Person Person { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
