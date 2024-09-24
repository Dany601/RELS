namespace RELS.Model
{
    public class Document
    {
        public int DocumentId { get; set; }
        public required int LessorId { get; set; }
        public required string FileRoute { get; set; }
        public required string Date { get; set; }

        public virtual required Lessor Lessor { get; set; }

    }
}
