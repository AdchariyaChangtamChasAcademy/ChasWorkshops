using WS_AsyncPaging.DTOs;

namespace WS_AsyncPaging.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();
        Task<CustomerResponse?> GetCustomerByIdAsync(int id);
        Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);
        Task<bool> UpdateCustomerAsync(int id, UpdateCustomerRequest request);
        Task<bool> DeleteCustomerAsync(int id);
    }
}