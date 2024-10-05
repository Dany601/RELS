namespace RELS.Model
{
    public class TypeDocument
    {
        public int Id { get; set; }
        public required string Name { get; set; }



        public bool IsDeleted { get; set; } = false;
    }
}
