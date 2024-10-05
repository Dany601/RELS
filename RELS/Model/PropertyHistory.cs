namespace RELS.Model
{
    public class PropertyHistory
    {
        public int Id { get; set; }
        public required string IdProperty { get; set; }
        public required string PropertyAddress { get; set; }
        public required string SquareMetersProperty { get; set; }
        public required string Cost { get; set; }
        public required string PropertyDescription { get; set; }
        public required string Latitude { get; set; }
        public required string Altitude { get; set; }
        /// 
        public required string UserType { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
