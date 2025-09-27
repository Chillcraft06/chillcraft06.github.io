using ChillsitePortfolio.Components;
using Microsoft.AspNetCore.StaticFiles;
using MudBlazor.Services;

namespace ChillsitePortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MudBlazor services
            builder.Services.AddMudServices();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        [".html"] = "text/html",
                        [".htm"] = "text/html",
                        [".json"] = "application/json",
                        [".woff2"] = "font/woff2",
                        [".woff"] = "font/woff",
                        [".ttf"] = "font/ttf",
                        [".gz"] = "application/gzip",
                        [".br"] = "application/brotli"
                    }
                }
            });

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
