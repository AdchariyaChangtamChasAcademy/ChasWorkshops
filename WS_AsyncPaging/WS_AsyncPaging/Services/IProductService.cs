using WS_AsyncPaging.DTOs;
using static WS_AsyncPaging.DTOs.PaginationDTOs;

namespace WS_AsyncPaging.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAllProducts();
        ProductResponse? GetProductById(int id);
        ProductResponse CreateProduct(CreateProductRequest request);
        bool UpdateProduct(int id, UpdateProductRequest request);
        bool DeleteProduct(int id);


        // Task betyder: "Jag lovar att ge dig detta... lite senare"
        Task<PagedResponse<ProductResponse>> GetPagedProductsAsync(int page, int pageSize);
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse?> GetProductByIdAsync(int id);
        Task<ProductResponse> CreateProductAsync(CreateProductRequest request);
        Task<bool> UpdateProductAsync(int id, UpdateProductRequest request);
        Task<bool> DeleteProductAsync(int id);
    }
}
