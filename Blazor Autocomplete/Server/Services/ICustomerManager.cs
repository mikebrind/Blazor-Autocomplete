using Blazor_Autocomplete.Shared;

namespace Blazor_Autocomplete.Server.Services;

public interface ICustomerManager
{
    Task<List<Customer>> GetFilteredCustomerNames(string filter);
}