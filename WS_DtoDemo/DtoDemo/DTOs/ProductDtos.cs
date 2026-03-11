using System.ComponentModel.DataAnnotations;

namespace DtoDemo.DTOs
{
    // 1. Response: Vad klienten får se när de hämtar en produkt
    public record ProductResponse(
        int Id,
        string Name,
        string Description,
        string Category,
        decimal Price,
        decimal Stock,
        DateTime CreatedAt
    );

    // 2. Request: Vad klienten får skicka in för att skapa en produkt
    public record CreateProductRequest(

        [Required(ErrorMessage = "Product name is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must include between 2 to 100 characters.")]
        string Name,

        [Required]
        string Description,
        [Required(ErrorMessage = "Product category is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Category name must include between 2 to 100 characters.")]
        string Category,

        [Range(0.01, 1000000, ErrorMessage = "Price must be larger than zero.")]
        decimal Price,
        [Range(0, 1000000, ErrorMessage = "Stock must be a positive number.")]
        decimal Stock
    );

    // 3. Request: Vad klienten får skicka in för att uppdatera en produkt
    public record UpdateProductRequest(
       string Name,
       string Description,
       string Category,
       decimal Price,
       decimal Stock
    );
}
