﻿namespace RELS.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string FirstLastName { get; set; }
        public required string SecondLastName { get; set; }
        public required string DocumentType { get; set; }
        public required string IdentificationNumber { get; set; }
        public required string Email { get; set; }
        public required string CellPhoneNumber { get; set; }
        public required string LandlineTelephone { get; set; }

        public virtual required TypeDocument TypeDocument { get; set; }
        public virtual required Owner Owner { get; set; }
        public virtual required Lessor Lessor { get; set; }
        public virtual required User User { get; set; }
    }
}
