﻿namespace Housing_system.DataLayer.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation properties
        public ICollection<Property> Properties { get; set; } = null!;
    }
}
