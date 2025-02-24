using desafio.api.Context;
using desafio.api.Core;
using desafio.api.Repositories;
using desafio.api.Repositories.Interfaces;
using desafio.api.Services;
using desafio.api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace desafio.api.Configuration
{
    public static  class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioPicPayDbContext>((sp, options) => options
               .UseSqlServer(configuration.GetConnectionString("PicPayConnection")));

            services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            services.AddScoped<ICarteiraService, CarteiraService>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            
            services.AddHttpClient<IAutorizadorService, AutorizadorService>();
            services.AddScoped<INotificacaoService, NotificationService>();

            return services;
        }
    }
}
