using Microsoft.Extensions.Caching.Hybrid;
using WS_AsyncPaging.DTOs;
using WS_AsyncPaging.Exeptions;
using WS_AsyncPaging.Models;
using static WS_AsyncPaging.DTOs.PaginationDTOs;

namespace WS_AsyncPaging.Services
{
    public class ProductService : IProductService
    {
        // Variabel för vår cache
        private readonly HybridCache _cache;
        // Vår låtsasdatabas med 1000 produkter
        private static readonly List<Product> _products = Enumerable.Range(1, 1000)
            .Select(i => new Product
            {
                Id = i,
                Name = $"Produkt {i}",
                Description = "Simulerad produkt för paging",
                Price = 100,
                CreatedAt = DateTime.UtcNow,
                InternalAdminNote = "Autogenererad"
            }).ToList();

        private static int _nextId = 1001;

        // Injicera cachen via DI
        public ProductService(HybridCache cache)
        {
            _cache = cache;
        }

        // Vår nya asynkrona pagineringsmetod
        public async Task<PagedResponse<ProductResponse>> GetPagedProductsAsync(int page, int pageSize)
        {

            /*
            var cacheKey = $"product_{id}"; // Unik nyckel för varje specifik produkt

            // GetOrCreateAsync är magin!
            // Den kollar först i minnet. Om datan saknas körs funktionen nedan (och cachas sedan).
            var product = await _cache.GetOrCreateAsync(
                cacheKey,
                async cancel =>
                {
                    await Task.Delay(500, cancel); // Simulerar ett TUNG databasanrop (0.5 sekunder)
                    return _products.FirstOrDefault(p => p.Id == id);
                }
            );

            if (product == null) return null;

            return new ProductResponse(product.Id, product.Name, product.Description, product.Category, product.Price, product.Stock, product.CreatedAt);
            */
            await Task.Delay(50); // Simulera att databasen är lite långsam

            var cacheKey = $"products_page_{page}_size_{pageSize}";

            var result = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                var totalCount = _products.Count;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                // Magin: Skip och Take!
                var items = _products
                    .Skip((page - 1) * pageSize) // Hoppa över tidigare sidor
                    .Take(pageSize) // Ta exakt så många vi ska ha nu
                    .Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Category, p.Price, p.Stock, p.CreatedAt))
                    .ToList();

                var meta = new PaginationMeta(
                    page,
                    pageSize,
                    totalPages,
                    totalCount,
                    page < totalPages,
                    page > 1
                );

                return new PagedResponse<ProductResponse>(items, meta);
            });

            return result;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            await Task.Delay(20);
            return GetAllProducts();
        }

        // --- CACHAD GET BY ID ---
        public async Task<ProductResponse?> GetProductByIdAsync(int id)
        {

            var cacheKey = $"product_{id}"; // Unik nyckel för varje specifik produkt

            // GetOrCreateAsync är magin!
            // Den kollar först i minnet. Om datan saknas körs funktionen nedan (och cachas sedan).
            var product = await _cache.GetOrCreateAsync(
                cacheKey,
                async cancel =>
                {
                    await Task.Delay(500, cancel); // Simulerar ett TUNG databasanrop (0.5 sekunder)
                    return _products.FirstOrDefault(p => p.Id == id);
                }
            );

            if (product == null)
            {
                throw new NotFoundException($"Produkten med ID:{id} finns inte i databasen.");
            }

            return new ProductResponse(product.Id, product.Name, product.Description, product.Category, product.Price, product.Stock, product.CreatedAt);
        }

        public async Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            await Task.Delay(20);
            var newProduct = new Product
            {
                Id = _nextId++,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow,
                InternalAdminNote = "Skapad via DI-Service"
            };

            _products.Add(newProduct);
            return new ProductResponse(newProduct.Id, newProduct.Name, newProduct.Description, newProduct.Category, newProduct.Price, newProduct.Stock, newProduct.CreatedAt);
        }

        public async Task UpdateProductAsync(int id, UpdateProductRequest request)
        {
            await Task.Delay(20);
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"Produkten med ID:{id} finns inte i databasen.");
            }

            // 1. Uppdatera Entiteten med de nya värdena
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            // 2. CACHE INVALIDATION: Rensa cachen så att nästa person som gör GET får den nya datan!
            await _cache.RemoveAsync($"product_{id}");

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"Produkten med ID:{id} finns inte i databasen.");
            }

            _products.Remove(product);

            await _cache.RemoveAsync($"product_{id}");
        }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _products
                .Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Category, p.Price, p.Stock, p.CreatedAt))
                .ToList();
        }

        public ProductResponse? GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;

            return new ProductResponse(product.Id, product.Name, product.Description, product.Category, product.Price, product.Stock, product.CreatedAt);
        }

        public ProductResponse CreateProduct(CreateProductRequest request)
        {
            var newProduct = new Product
            {
                Id = _nextId++, // Denna kommer nu börja på 1001 och räkna uppåt
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow,
                InternalAdminNote = "Skapad via DI-Service"
            };

            _products.Add(newProduct);

            return new ProductResponse(
                newProduct.Id,
                newProduct.Name,
                newProduct.Description,
                newProduct.Category,
                newProduct.Price,
                newProduct.Stock,
                newProduct.CreatedAt
            );
        }

        public void UpdateProduct(int id, UpdateProductRequest request)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            // Uppdatera entiteten med de nya värdena
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
        }

        public void DeleteProduct(int id)
        {
            // Leta i databasen
            var product = _products.FirstOrDefault(p => p.Id == id);

            // Radera produkten
            _products.Remove(product);
        }


    }
}
