﻿namespace RELS.Model
{
    public class UserType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        //public required User Users { get; set; }

    }
}
