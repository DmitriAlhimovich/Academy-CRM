using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcademyCRM.WebApi.IntegrationTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/sync", async context =>
                {
                    await RunRequestsSync();
                });
                endpoints.MapGet("/async", async context =>
                {
                    await RunRequestsAsync();
                });
            });
        }

        const string BaseUrl = "https://localhost:44396";
        const int NumberOfRequests = 500;

        public async Task RunRequestsAsync()
        {
            await RunRequestInternal("courses/async");
        }


        public async Task RunRequestsSync()
        {
            await RunRequestInternal("courses");
        }

        private async Task RunRequestInternal(string endpoint)
        {
            string filePath = "requestsResults.txt";
            await File.WriteAllTextAsync(filePath, "");

            var startTime = DateTime.Now;
            Console.WriteLine($"Start for endpoint {endpoint} at {startTime}");

            for (var i = 0; i < NumberOfRequests; i++)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var result = await client.GetAsync(endpoint);
                }
            }

            Console.WriteLine($"Duration: {(DateTime.Now - startTime).Seconds}, end at " + DateTime.Now);
        }
    }
}
