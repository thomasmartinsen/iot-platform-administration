using System;
using Bluefragments.Utilities.Data.Cosmos;
using Dpx.Iot.Common.Data;
using Dpx.Iot.Common.Factories;
using Dpx.IotPlatformAdministration.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dpx.IotPlatformAdministration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            var storageUrl = Configuration.GetSection("Storage")["Url"] ?? throw new ArgumentNullException("StorageUrl");
            var storageKey = Configuration.GetSection("Storage")["Key"] ?? throw new ArgumentNullException("StorageKey");

            var storageCoreDatabase = Configuration.GetSection("Storage")["CoreDatabase"] ?? throw new ArgumentNullException("StorageCoreDatabase");
            ICosmosClient<DataEntityBase<string>, string> storageCore = new CosmosClient<DataEntityBase<string>, string>(storageCoreDatabase, storageKey, storageUrl);
            services.AddSingleton(storageCore);

            var storageMetricsDatabase = Configuration.GetSection("Storage")["MetricsDatabase"] ?? throw new ArgumentNullException("StorageMetricsDatabase");
            ICosmosClient<DataEntityBase<string>, string> storageMetrics = new CosmosClient<DataEntityBase<string>, string>(storageMetricsDatabase, storageKey, storageUrl);
            services.AddSingleton(storageMetrics);

            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            IIotClientFactory iotClientFactory = new IotClientFactory();
            services.AddSingleton(iotClientFactory);

            IPointRepository pointRepository = new PointRepository(storageMetrics, iotClientFactory);
            services.AddSingleton(pointRepository);

            ICustomerRepository customerRepository = new CustomerRepository(storageCore);
            services.AddSingleton(customerRepository);

            IVerticalRepository verticalRepository = new VerticalRepository(storageCore);
            services.AddSingleton(verticalRepository);

            services.AddSingleton<CustomerService>();
            services.AddSingleton<PointService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
