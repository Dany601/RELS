namespace RELS.Model
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public required string Name { get; set; }

        //public required User Users { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
