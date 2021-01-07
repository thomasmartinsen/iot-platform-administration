using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace iot_platform_administration.Data
{
    public class PointService
    {
        public static string apiUrl = "https://iotcoreapitest.azurewebsites.net/point";
        public static string apiKey = "087143f5-8284-4024-b1ab-c6d6359a2c39";
        public static string customerId = "77bf1dae-1ace-4145-9cbf-69b8cca82c7e";
        public static string clientId = "afajcdecaux";
        public static string token = "Bearer xxxxxxxxxxxxx";

        public static IEnumerable<Models.Api.Point> data;

        public PointService()
        {
        }

        public async Task<List<Models.Ui.Point>> GetAsync()
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
                var apiData = JsonConvert.DeserializeObject<IEnumerable<Models.Api.Point>>(responseString);
                data = apiData ?? throw new Exception("failed reading employees");
            }

            return data
                .OrderBy(x => x.Name)
                .Select(x => new Models.Ui.Point()
                {
                    Name = x.Name,
                    CustomerId = x.CustomerId,
                    VerticalId = x.VerticalId,
                })
                .ToList();
        }
    }
}