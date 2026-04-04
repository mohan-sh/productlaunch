
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Entity;
using ProductLaunch.Model;
using ProductLaunch.Model.Initializers;
using ProductLaunch.Web.Components;
using ProductLaunch.Web.Components.Pages.SignUp;

namespace ProductLaunch.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ---------------------------------------------------------------------------
            // Service registrations
            // Migrated from: Global.asax Application_Start, App_Start/RouteConfig.cs,
            //                App_Start/BundleConfig.cs, and EF6 database initializer.
            // ---------------------------------------------------------------------------

            // Add Razor Components with Interactive Server Components
            // Replaces RouteConfig.RegisterRoutes (WebForms FriendlyUrls) — Blazor Server
            // uses component-based routing via @page directives instead.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Add HttpContextAccessor (available throughout the DI container)
            builder.Services.AddHttpContextAccessor();

            // Add Distributed Memory Cache (required before AddSession)
            builder.Services.AddDistributedMemoryCache();

            // Add Session support
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Register ProductLaunchContext as a scoped service using the connection
            // string from appsettings.json (migrated from Web.config <connectionStrings>).
            // The EF6 DbContext constructor accepts a connection string directly.
            builder.Services.AddScoped(_ =>
                new ProductLaunchContext());

            // Register the EF6 database initializer (migrated from
            // Database.SetInitializer<ProductLaunchContext>(new StaticDataInitializer())
            // in Global.asax Application_Start).
            builder.Services.AddScoped<IDatabaseInitializer<ProductLaunchContext>, StaticDataInitializer>();

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // ---------------------------------------------------------------------------
            // Build the application
            // ---------------------------------------------------------------------------
            var app = builder.Build();

            // ---------------------------------------------------------------------------
            // Startup hooks — run once at application start
            // Migrated from: Global.asax Application_Start
            // ---------------------------------------------------------------------------

            // Apply the EF6 database initializer and preload static data cache.
            // This replaces:
            //   Database.SetInitializer<ProductLaunchContext>(new StaticDataInitializer());
            //   SignUp.PreloadStaticDataCache();
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider
                    .GetRequiredService<IDatabaseInitializer<ProductLaunchContext>>();

                // Register the initializer with EF6 so it runs on first context use.
                Database.SetInitializer(initializer);

                // Force database initialization immediately so the seed data is present
                // before the static data cache is loaded.
                var context = scope.ServiceProvider.GetRequiredService<ProductLaunchContext>();
                context.Database.Initialize(force: false);

                // Preload the in-memory country/role cache used by the SignUp page.
                // Migrated from SignUp.PreloadStaticDataCache() in Application_Start.
                ProductLaunch.Web.Components.Pages.SignUp.SignUp.PreloadStaticDataCache();
            }

            // ---------------------------------------------------------------------------
            // Middleware pipeline
            // Ordering follows ASP.NET Core conventions:
            //   Exception handling → HTTPS → Static files → Routing → Session →
            //   Antiforgery → Endpoints
            // ---------------------------------------------------------------------------

            // 1. Exception / error handling
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // 2. HTTPS redirection
            app.UseHttpsRedirection();

            // 3. Static files — replaces BundleConfig.RegisterBundles (WebForms bundling
            //    and ScriptManager mappings).  Static assets (CSS, JS, fonts) are served
            //    directly from wwwroot/ using ASP.NET Core's built-in static file
            //    middleware instead of System.Web.Optimization bundles.
            app.UseStaticFiles();

            // 4. Routing — replaces RouteConfig.RegisterRoutes with FriendlyUrls.
            //    Blazor Server routing is handled by component @page directives.
            app.UseRouting();

            // 5. Session
            app.UseSession();

            // 6. Antiforgery (required for Blazor interactive forms)
            app.UseAntiforgery();

            // 7. Map Blazor Server components — the top-level App component acts as the
            //    application shell, with Routes.razor handling client-side navigation.
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
