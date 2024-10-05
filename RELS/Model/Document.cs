namespace RELS.Model
{
    public class Document
    {
        public int Id { get; set; }
        public required string FileRoute { get; set; }
        public required string Date { get; set; }

        public virtual required Lessor Lessor { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
