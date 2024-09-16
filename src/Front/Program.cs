using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Front;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseAddress = new Uri("http://localhost:5222"); // Remplace par l'URL correcte de ton backend
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = apiBaseAddress });

await builder.Build().RunAsync();