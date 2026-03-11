namespace WS_AsyncPaging.DTOs
{
    // API sent to the client
    public record CustomerResponse(
        int Id,
        string Name,
        string Email,
        DateTime CreatedAt
    );

    // Creating a new customer
    public record CreateCustomerRequest(
        string Name,
        string Email
    );

    // Updating an existing customer
    public record UpdateCustomerRequest(
        string Name,
        string Email
    );
}