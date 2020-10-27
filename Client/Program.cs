using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RiverviewTimeTracker.Client.Core.Interfaces;
using RiverviewTimeTracker.Client.Core.HttpClients;
using RiverviewTimeTracker.Client.Core.Services;

namespace RiverviewTimeTracker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddHttpClient("RiverviewTimeTracker.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<ITimeTrackerClient, TimeTrackerClient>(client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            })
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>(); 

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("RiverviewTimeTracker.ServerAPI"));

            builder.Services.AddTransient<ITimeTrackerService, TimeTrackerService>();
            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
