namespace RELS.Model
{
    public class DocumentHistory
    {
        public int Id { get; set; }
        public required string IdDocument { get; set; }
        public required string FileRoute { get; set; }
        public required string Date { get; set; }

        public required string Lessor { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}

