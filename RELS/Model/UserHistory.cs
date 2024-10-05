namespace RELS.Model
{
    public class UserHistory
    {
        public int Id { get; set; }
       
        /// 
        public required string IdUser { get; set; }
        public required string UserType { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
