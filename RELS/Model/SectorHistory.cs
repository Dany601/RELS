namespace RELS.Model
{
    public class SectorHistory
    {
        public int Id { get; set; }
        public required string IdSector { get; set; }
        public required string SerctorName { get; set; }
        /// 
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
