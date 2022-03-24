using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ANDERSONDFM.Infra.IoC.AutoMapper;
using ANDERSONDFM.Infra.Contextos;

namespace ANDERSONDFM.Infra.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection InjectionIoC(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddScoped<HeaderRequest>();

            return services;
        }

        public static void AddSemaDbContext(this IServiceCollection services, string connectionString)
        {
            #region Conexão SQL

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(connectionString)
                 .EnableSensitiveDataLogging());

            #endregion Conexão SQL
        }
    }
}