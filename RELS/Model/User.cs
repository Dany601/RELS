namespace RELS.Model
{
    public class User
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Identification { get; set; }
        public required string CellPhoneNumber { get; set; }

        public virtual required TypeDocument TypeDocument { get; set; }
        public virtual required UserType UserType { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
