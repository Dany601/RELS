namespace RELS.Model
{
    public class PersonHistory
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string FirstLastName { get; set; }
        public required string SecondLastName { get; set; }
        public required string DocumentType { get; set; }
        public required string IdentificationNumber { get; set; }
        public required string Email { get; set; }
        public required string CellPhoneNumber { get; set; }
        public required string LandlineTelephone { get; set; }
        public required string Pasword { get; set; }
        /// 
        public required string UserType { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }

    }
}
