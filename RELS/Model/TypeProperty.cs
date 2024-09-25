namespace RELS.Model
{
    public class TypeProperty
    {
        public int Id { get; set; }
        public required string NameTypeProperty { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
