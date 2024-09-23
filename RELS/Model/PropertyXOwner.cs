namespace RELS.Model
{
    public class PropertyXOwner
    {
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }

        public virtual required Owner Owner { get; set; }
        public virtual required Property Property { get; set; }
    }
}
