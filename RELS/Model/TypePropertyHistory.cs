namespace RELS.Model
{
    public class TypePropertyHistory
    {
        public int Id { get; set; }
        public required string IdTypeProperty { get; set; }
        public required string NameTypeProperty { get; set; }
        /// 
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
