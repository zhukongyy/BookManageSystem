using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp4
{
    public class GlobalState
    {
        public string UserName { get; set; } = "";
        public int Role = -1; //-1-Î´µÇÂ¼ 0-user 1-admin 2-super_admin
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:8000") });
            builder.Services.AddSingleton<GlobalState>();
            builder.Services.AddAntDesign();
            await builder.Build().RunAsync();
        }
    }
}
