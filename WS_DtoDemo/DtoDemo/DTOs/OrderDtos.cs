using System.ComponentModel.DataAnnotations;

namespace DtoDemo.DTOs
{
    // 1. Response: Vad klienten får se när de hämtar en produkt
    public record OrderResponse(
        int Id,
        string Name,
        string Address,
        List<int> ProductIds,
        DateTime CreatedAt
    );

    // 2. Request: Vad klienten får skicka in för att skapa en produkt
    public record CreateOrderRequest(

        [Required(ErrorMessage = "Order name is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must include between 2 to 100 characters.")]
        string Name,

        [Required(ErrorMessage = "Address is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address name must include between 2 to 100 characters.")]
        string Address,

        [Required(ErrorMessage = "At least one product id is required.")]
        [MinLength(1, ErrorMessage = "Order must contain at least one product id.")]
        List<int> ProductIds
    );

    // 3. Request: Vad klienten får skicka in för att uppdatera en produkt
    public record UpdateOrderRequest(
       string Name,
       string Address,
       List<int> ProductIds
    );
}
