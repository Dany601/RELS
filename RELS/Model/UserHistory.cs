namespace RELS.Model
{
    public class UserHistory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
        /// 
        public required string UserType { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
