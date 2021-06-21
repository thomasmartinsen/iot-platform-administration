using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bluefragments.Utilities.Extensions;
using Dpx.Iot.Common.Data;
using Dpx.Iot.Common.Entities;

namespace Dpx.IotPlatformAdministration.Data
{
    public class CustomerService
    {
        private static IEnumerable<Customer> data;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            if (data == null)
            {
                data = await customerRepository.GetAsync();
            }

            return data
                .OrderBy(x => x.Name)
                .ToList();
        }

        public async Task<Customer> GetFromClientIdAsync(string clientId)
        {
            clientId.ThrowIfParameterIsNullOrWhiteSpace(nameof(clientId));

            if (data == null)
            {
                data = await customerRepository.GetAsync();
            }

            return data.SingleOrDefault(x => x.ClientId.ToLower() == clientId.ToLower());
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            customer.ThrowIfParameterIsNull(nameof(customer));

            await customerRepository.UpsertAsync(customer);
            data = null;

            return await Task.FromResult(customer);
        }
    }
}
