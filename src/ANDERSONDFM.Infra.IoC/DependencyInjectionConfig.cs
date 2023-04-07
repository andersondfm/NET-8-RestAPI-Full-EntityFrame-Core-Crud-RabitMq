using ANDERSONDFM.Aplicacao.Interfaces;
using ANDERSONDFM.Aplicacao.Interfaces.auth;
using ANDERSONDFM.Aplicacao.Servicos;
using ANDERSONDFM.Aplicacao.Servicos.auth;
using ANDERSONDFM.Dominio.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ANDERSONDFM.Infra.IoC.AutoMapper;
using ANDERSONDFM.Infra.Contextos;
using ANDERSONDFM.Infra.Repositorio.Negocio;
using ANDERSONDFM.Integracao;

namespace ANDERSONDFM.Infra.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void InjectionIoC(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IRabitMQProducer, RabitMQProducer>();
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            #region Conexão SQL

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(connectionString)
                 .EnableSensitiveDataLogging());

            #endregion Conexão SQL
        }
    }
}