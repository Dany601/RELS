﻿namespace RELS.Model
{
    public class UserTypeHistory
    {
        public int Id { get; set; }
        public required string IdUserType { get; set; }
        public required string Name { get; set; }
        /// 
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }

    }
}
