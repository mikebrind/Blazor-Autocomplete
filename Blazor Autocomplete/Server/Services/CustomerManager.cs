using BlazorAutocomplete.Server.Data;
using BlazorAutocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorAutocomplete.Server.Services;

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
