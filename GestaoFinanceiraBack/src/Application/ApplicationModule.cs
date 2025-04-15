using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddSingleton(configuration!);
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IDespesaServices, DespesaServices>();
            services.AddScoped<IReceitaServices, ReceitaServices>();
            return services;
        }
    }
}