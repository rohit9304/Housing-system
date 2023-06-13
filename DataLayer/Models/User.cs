﻿namespace Housing_system.DataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public ICollection<Property> Properties { get; set; } = null!;
    }
}
