namespace RELS.Model
{
    public class Lessor
    {
        public int Id { get; set; }

        public virtual required Person Person { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
