namespace RELS.Model
{
    public class Property
    {
        public int Id { get; set; }
        public required string PropertyAddress { get; set; }
        public required string SquareMetersProperty { get; set; }
        public required string Cost { get; set; }
        public required string PropertyDescription { get; set; }
        public required string Latitude { get; set; }
        public required string Altitude { get; set; }

        public virtual required State State { get; set; }
        public virtual required TypeProperty TypesProperties { get; set; }
        public virtual required Sector Sectors { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
