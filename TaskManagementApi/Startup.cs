using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagementApi.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext to the DI container
        services.AddDbContext<TaskDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TaskDb")));

        // Add API controllers to services
        services.AddControllers();

        // Add Swagger for API documentation
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) // Ensures this is only applied in development
        {
            app.UseDeveloperExceptionPage(); // Detailed exception page for debugging in development
            app.UseSwagger(); // Enables Swagger for development environment
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagementApi v1")); // Correct Swagger endpoint
        }
        else
        {
            // If not in development, use custom error handling for production
            app.UseExceptionHandler("/Home/Error"); // Custom error handling route (make sure this route exists)
            app.UseHsts();  // HTTP Strict Transport Security for secure connections
        }

        // Redirect HTTP requests to HTTPS (security feature)
        app.UseHttpsRedirection();

        // Add routing for API controllers
        app.UseRouting();

        // Add Authorization middleware (for future authentication/authorization)
        app.UseAuthorization();

        // Map controller routes to endpoints
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
