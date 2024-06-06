using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Repositories;
using GestaoInvestimentosInfrastructure.Services;

namespace GestaoInvestimentosWebApi
{
    public static class Register
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAtivoService, AtivoService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<ITransacaoService, TransacaoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAtivoRepository, AtivoRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddTransient<ITransacaoRepository, TransacaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
