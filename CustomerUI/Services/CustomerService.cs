
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CustomerUI.DTO;
using Newtonsoft.Json;

namespace CustomerUI.Services
{
    public class CustomerService
    {
        //private readonly HttpClient _httpClient;
        //public CustomerService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        private static List<CustomerDTO> _customers = new List<CustomerDTO>
        {
            new CustomerDTO { CustomerId = 1, FullName = "Alice Smith", Email = "alice@example.com", PhoneNumber = "1234567890" },
            new CustomerDTO { CustomerId = 2, FullName = "Bob Johnson", Email = "bob@example.com", PhoneNumber = "0987654321" }
        };


        public async Task<ICollection<CustomerDTO>?> GetCustomersAsync()
        {
            //return await _httpClient.GetFromJsonAsync<List<CustomerDTO>>("api/customers");
            await Task.Delay(200);

            return _customers;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            //return await _httpClient.GetFromJsonAsync<CustomerDTO>($"api/customers/{id}");
            await Task.Delay(200);

            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        public async Task CreateCustomerAsync(CustomerDTO customer)
        {
            //await _httpClient.PostAsJsonAsync("api/customers", customer);
            await Task.Delay(200);
            customer.CustomerId = _customers.Max(c => c.CustomerId) + 1;
            _customers.Add(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customer)
        {
            //await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerId}", customer);

            await Task.Delay(200);
            var exist = _customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (exist is not null)
            {
                exist.FullName = customer.FullName;
                exist.Email = customer.Email;
                exist.PhoneNumber = customer.PhoneNumber;
            }
        }

        public async Task DeleteCustomerAsync(CustomerDTO customer)
        {
            //await _httpClient.DeleteAsync($"api/customers/{customer.CustomerId}");

            await Task.Delay(200);

            var exist = _customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (exist is not null)
            {
                _customers.Remove(customer);
            }

        }
    }   
}

