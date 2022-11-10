using BlazorAutocomplete.Shared;

namespace BlazorAutocomplete.Server.Services;

public interface ICustomerManager
{
    Task<List<Customer>> GetFilteredCustomerNames(string filter);
}