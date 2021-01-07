using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iot_platform_administration.Data
{
    public class CustomerService
    {
        public static string apiUrl = "https://iotcoreapitest.azurewebsites.net/customer";
        public static string apiKey = "087143f5-8284-4024-b1ab-c6d6359a2c39";
        public static string customerId = "77bf1dae-1ace-4145-9cbf-69b8cca82c7e";
        public static string clientId = "afajcdecaux";
        public static string token = "Bearer xxxxxxxx";

        public static Models.Api.Customer data;

        public CustomerService()
        {
        }

        public async Task<Models.Ui.Customer> GetAsync()
        {
            if (data == null)
            {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("Authorization", token);
                http.DefaultRequestHeaders.Add("x-apikey", apiKey);
                http.DefaultRequestHeaders.Add("clientId", clientId);
                var response = await http.GetAsync(apiUrl);
                if (response == null || !response.IsSuccessStatusCode) throw new Exception("failed calling api");

                var responseString = await response.Content.ReadAsStringAsync();
                var apiData = JsonConvert.DeserializeObject<Models.Api.Customer>(responseString);
                data = apiData ?? throw new Exception("failed reading employees");
            }

            if (data.ID == customerId)
            {
                return new Models.Ui.Customer()
                {
                    Id = data.ID,
                    Name = data.Name
                };
            };

            return default;
        }

        public async Task<Models.Ui.Customer> UpdateAsync(Models.Ui.Customer employee)
        {
            return await Task.FromResult(employee);
        }
    }
}
