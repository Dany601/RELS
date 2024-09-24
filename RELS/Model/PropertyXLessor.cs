namespace RELS.Model
{
    public class PropertyXLessor
    {
        public int PropertyId { get; set; }
        public int LessorId { get; set; }

        public virtual required Lessor Lessor { get; set; }
        public virtual required Property Property { get; set; }
        public virtual required Favorite Favorite { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
