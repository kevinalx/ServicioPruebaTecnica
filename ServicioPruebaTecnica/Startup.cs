using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ServicioPruebaTecnica
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting(); // Agregar middleware UseRouting

            app.UseAuthentication(); // Agregar middleware UseAuthentication
            app.UseAuthorization(); // Agregar middleware UseAuthorization

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new ConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));

            // Agregar autenticación por token Bearer JWT con IdentityServer4
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001"; // URL del servidor de autorización
                    options.RequireHttpsMetadata = false; // Permitir conexiones HTTP no seguras
                    options.Audience = "api"; // Identificador de audiencia del token JWT
                });

            // Agregar autorización
            services.AddAuthorization();

            // Agregar servicios de MVC
            services.AddControllers();
        }

    }
}
