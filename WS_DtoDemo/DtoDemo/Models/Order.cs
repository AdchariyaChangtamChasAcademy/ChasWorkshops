namespace DtoDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<int> ProductIds { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public string InternalAdminNote { get; set; } = "Hemlig data";
    }
}
