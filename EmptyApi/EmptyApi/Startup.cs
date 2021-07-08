using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmptyApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Instalar o Pacote Microsoft.AspNetCore.Mvc.NewtonsoftJson
            // Por padrão na Web Api, temos que registrar o serviço para habilitar os controladores.
            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware para habilitar o roteamento
            app.UseRouting();

            // As rotas são definidas a partir da Middleware UseEndpoints
            // O Endpoint é o endereço, onde iremos acessar a Api
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
