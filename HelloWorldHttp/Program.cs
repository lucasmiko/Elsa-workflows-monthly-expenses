namespace HelloWorldHttp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Elsa services to the container.
            builder.Services.AddElsa(options => options
                .AddHttpActivities()
                .AddWorkflow<HelloWorldHttp>());

            // Add authorization services.
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Use authorization.
            app.UseAuthorization();

            // Use Elsa HTTP activities.
            app.UseHttpActivities();

            app.Run();
        }
    }
}