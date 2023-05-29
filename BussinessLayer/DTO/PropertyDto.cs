namespace Housing_system.BussinessLayer.DTO
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Bhk { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
    }
}
