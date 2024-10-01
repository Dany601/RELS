namespace RELS.Model
{
    public class LessorHistory
    {
        public int Id { get; set; }
        public required string IdLessor { get; set; }
        public required string Person { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
