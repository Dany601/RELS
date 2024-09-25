﻿namespace RELS.Model
{
    public class State
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
