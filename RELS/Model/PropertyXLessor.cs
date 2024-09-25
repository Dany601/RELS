namespace RELS.Model
{
    public class PropertyXLessor
    {

        public virtual required Lessor Lessor { get; set; }
        public virtual required Property Property { get; set; }
        public virtual required Favorite Favorite { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
