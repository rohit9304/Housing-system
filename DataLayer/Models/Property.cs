namespace Housing_system.DataLayer.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Bhk { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
