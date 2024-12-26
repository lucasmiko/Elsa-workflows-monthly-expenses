using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.Sqlite;

namespace DashboardAndServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Access configuration and environment.
            var configuration = builder.Configuration;
            var environment = builder.Environment;

            var elsaSection = configuration.GetSection("Elsa");

            // Add Elsa services to the container.
            builder.Services.AddElsa(elsa => elsa
                .UseEntityFrameworkPersistence(ef => ef.UseSqlite())
                .AddConsoleActivities()
                .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                .AddQuartzTemporalActivities()
                .AddWorkflowsFrom<Program>());

            // Add Elsa API endpoints.
            builder.Services.AddElsaApiEndpoints();

            // For Dashboard.
            builder.Services.AddRazorPages();

            // Add authorization services.
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // For Dashboard.
            app.UseRouting();

            // Use authorization.
            app.UseAuthorization();

            // Use Elsa HTTP activities.
            app.UseHttpActivities();

            // Register endpoints directly on the WebApplication.
            app.MapControllers(); // Elsa API Endpoints are implemented as regular ASP.NET Core API controllers.
            app.MapFallbackToPage("/_Host"); // For Dashboard.

            app.Run();
        }
    }
}
