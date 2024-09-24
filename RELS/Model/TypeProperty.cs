namespace RELS.Model
{
    public class TypeProperty
    {
        public int TypePropertyId { get; set; }
        public required string NameTypeProperty { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
