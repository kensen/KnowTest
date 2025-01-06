using KnowTest.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Config.HostUrl = builder.HostEnvironment.BaseAddress;
builder.Services.AddAppClient();
await builder.Build().RunAsync();