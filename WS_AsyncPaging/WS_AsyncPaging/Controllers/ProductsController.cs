
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WS_AsyncPaging.DTOs;
using WS_AsyncPaging.Models;
using WS_AsyncPaging.Services;
using static WS_AsyncPaging.DTOs.PaginationDTOs;

namespace WS_AsyncPaging.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Låtsas-databas för exemplet
        private static readonly List<Product> _products = new();

        // En privat variabel för att spara tjänsten vi får in
        private readonly IProductService _productService;

        // Konstukten, det är här dependancy injection sker
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        // 1. Vi tar emot en DTO ([FromBody]), INTE en Entity!
        public ActionResult<ProductResponse> CreateProduct([FromBody] CreateProductRequest request)
        {
            // 2. Mappa inkommande DTO till vår interna databas-Entity
            var newProduct = new Product
            {
                Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1,
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Price = request.Price,
                Stock = request.Stock,
                CreatedAt = DateTime.UtcNow,
                InternalAdminNote = "Skapad via API"
            };

            // 3. Spara till "databasen"
            _products.Add(newProduct);

            // 4. Mappa Entity tillbaka till en säker Response-DTO
            var response = new ProductResponse(
                newProduct.Id,
                newProduct.Name,
                newProduct.Description,
                newProduct.Category,
                newProduct.Price,
                newProduct.Stock,
                newProduct.CreatedAt
            );

            // 5. Returnera 201 Created med URI till den nya resursen, och skicka med DTO:n
            return CreatedAtAction(nameof(GetProductById), new { id = response.Id }, response);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductResponse>> GetProducts()
        {
            throw new Exception("Hjälp, databasen brinner!");

            // Vi använder LINQ för att mappa listan av Entities till en lista av DTO:er
            var responseList = _products.Select(p => new ProductResponse(
                p.Id,
                p.Name,
                p.Description,
                p.Category,
                p.Price,
                p.Stock,
                p.CreatedAt
            )).ToList();

            return Ok(responseList); // 200 OK
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductResponse>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Mappa till DTO innan vi skickar tillbaka
            var response = new ProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Category,
                product.Price,
                product.Stock,
                product.CreatedAt
            );

            return Ok(response); // 200 OK
        }

        [HttpPut("{id}")]
        // Vi tar emot en UpdateProductRequest
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Uppdatera Entiteten med värden från vår DTO
            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Price = request.Price;
            product.Stock = request.Stock;

            // Vid framgångsrik PUT returnerar man oftast 204 No Content
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Vi tar emot en DeleteProduct
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Tar bort product från registret
            _products.Remove(product);

            // Vid framgångsrik PUT returnerar man oftast 204 No Content
            return NoContent();
        }

        [HttpGet]
        // Vi sätter default-värden: Sida 1 med 20 produkter ifall klienten inte anger något.
        public async Task<ActionResult<PagedResponse<ProductResponse>>> GetProductsAsync(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            // Säkerhet: Förhindra att någon begär en miljon produkter och kraschar servern
            pageSize = Math.Clamp(pageSize, 1, 100);

            // Await frigör webbserverns tråd medan servicen jobbar asynkront
            var response = await _productService.GetPagedProductsAsync(page, pageSize);

            return Ok(response);
        }
    }
}
