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

            var url = Configuration.GetSection("Storage")["Url"] ?? throw new ArgumentNullException("StorageUrl");
            var key = Configuration.GetSection("Storage")["Key"] ?? throw new ArgumentNullException("StorageKey");
            var database = Configuration.GetSection("Storage")["Database"] ?? throw new ArgumentNullException("StorageDatabase");
            ICosmosClient<DataEntityBase<string>, string> storage = new CosmosClient<DataEntityBase<string>, string>(database, key, url);
            services.AddSingleton(storage);

            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<IIotClientFactory, IotClientFactory>();
            services.AddSingleton<IPointRepository, PointRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IVerticalRepository, VerticalRepository>();

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
