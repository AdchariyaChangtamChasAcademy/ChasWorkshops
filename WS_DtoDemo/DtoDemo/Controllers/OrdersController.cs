using DtoDemo.DTOs;
using DtoDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DtoDemo.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // Låtsas-databas för exemplet
        private static readonly List<Order> _orders = new();

        [HttpPost]
        // 1. Vi tar emot en DTO ([FromBody]), INTE en Entity!
        public ActionResult<OrderResponse> CreateOrder([FromBody] CreateOrderRequest request)
        {
            // 2. Mappa inkommande DTO till vår interna databas-Entity
            var newOrder = new Order
            {
                Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1,
                Name = request.Name,
                Address = request.Address,
                ProductIds = request.ProductIds,
                CreatedAt = DateTime.UtcNow,
                InternalAdminNote = "Skapad via API"
            };

            // 3. Spara till "databasen"
            _orders.Add(newOrder);

            // 4. Mappa Entity tillbaka till en säker Response-DTO
            var response = new OrderResponse(
                newOrder.Id,
                newOrder.Name,
                newOrder.Address,
                newOrder.ProductIds,
                newOrder.CreatedAt
            );

            // 5. Returnera 201 Created med URI till den nya resursen, och skicka med DTO:n
            return CreatedAtAction(nameof(GetOrderById), new { id = response.Id }, response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetOrders()
        {
            // Vi använder LINQ för att mappa listan av Entities till en lista av DTO:er
            var responseList = _orders.Select(p => new OrderResponse(
                p.Id,
                p.Name,
                p.Address,
                p.ProductIds,
                p.CreatedAt
            )).ToList();

            return Ok(responseList); // 200 OK
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<ProductResponse> GetOrderById(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            // 404 Not Found
            if (order == null) { return NotFound(); }

            // Mappa till DTO innan vi skickar tillbaka
            var response = new OrderResponse(
                order.Id,
                order.Name,
                order.Address,
                order.ProductIds,
                order.CreatedAt
            );

            return Ok(response); // 200 OK
        }

        [HttpPut("{id}")]
        // Vi tar emot en UpdateProductRequest
        public IActionResult UpdateProduct(int id, [FromBody] UpdateOrderRequest request)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            // 404 Not Found
            if (order == null){ return NotFound(); }

            // Uppdatera Entiteten med värden från vår DTO
            order.Name = request.Name;
            order.Address = request.Address;
            order.ProductIds = request.ProductIds;

            // Vid framgångsrik PUT returnerar man oftast 204 No Content
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Vi tar emot en DeleteProduct
        public IActionResult DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            // 404 Not Found
            if (order == null) { return NotFound(); }

            // Tar bort product från registret
            _orders.Remove(order);

            // Vid framgångsrik PUT returnerar man oftast 204 No Content
            return NoContent();
        }
    }
}
