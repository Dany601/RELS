namespace RELS.Model
{
    public class Lessor
    {
        public int Id { get; set; }

        public virtual required User User { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
