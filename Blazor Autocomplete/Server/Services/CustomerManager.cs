using Blazor_Autocomplete.Server.Data;
using Blazor_Autocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Autocomplete.Server.Services;

public class CustomerManager : ICustomerManager
{
	private readonly NorthwindContext context;

	public CustomerManager(NorthwindContext context) => this.context = context;

	public async Task<List<Customer>> GetFilteredCustomerNames(string filter) =>
		await context.Customers
		.Where(c => c.CompanyName.ToLower().Contains(filter.ToLower()))
		.OrderBy(c => c)
		.ToListAsync();
}
