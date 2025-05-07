
using System.Net.Http.Json;
using CustomerUI.DTO;

namespace CustomerUI.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<CustomerDTO>?> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CustomerDTO>>("api/customers");

            //return new List<CustomerDTO>
            //{
            //    new CustomerDTO { CustomerId = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "123-456-7890" },
            //    new CustomerDTO { CustomerId = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987-654-3210" }
            //};
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerDTO>($"api/customers/{id}");
        }

        public async Task CreateCustomerAsync(CustomerDTO customer)
        {
             await _httpClient.PostAsJsonAsync("api/customers", customer);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customer)
        {
             await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerId}", customer);
        }

        public async Task DeleteCustomerAsync(CustomerDTO customer)
        {

            await _httpClient.DeleteAsync($"api/customers/{customer.CustomerId}");
        }
    }   
}

