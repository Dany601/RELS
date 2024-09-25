namespace RELS.Model
{
    public class PropertyXOwner
    {

        public virtual required Owner Owner { get; set; }
        public virtual required Property Property { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
