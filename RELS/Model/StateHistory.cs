﻿namespace RELS.Model
{
    public class StateHistory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        ///       
        public required string UserType { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
