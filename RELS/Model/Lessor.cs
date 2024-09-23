namespace RELS.Model
{
    public class Lessor
    {
        public int LessorId { get; set; }
        public int PersonId { get; set; }

        public virtual required Person Person { get; set; }
    }
}
