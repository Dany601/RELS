namespace RELS.Model
{
    public class TypeDocumentHistory
    {
        public int Id { get; set; }
        public required string IdTypeDocument { get; set; }
        public required string Name { get; set; }
        /// 
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
