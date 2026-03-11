namespace WS_AsyncPaging.Models
{
    // Internal representation of a customer in your "database"
    public class Customer
    {
        public int Id { get; set; }              // Unique identifier
        public string Name { get; set; } = "";   // Full name
        public string Email { get; set; } = "";  // Email address
        public DateTime CreatedAt { get; set; }  // When the customer was created

        // Internal notes or metadata (not exposed via API)
        public string InternalAdminNote { get; set; } = "";
    }
}