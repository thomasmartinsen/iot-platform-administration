using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Customer> UpdateAsync(Customer employee)
        {
            return await Task.FromResult(employee);
        }
    }
}
