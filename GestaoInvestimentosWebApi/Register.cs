using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Repositories;
using GestaoInvestimentosCore.Services;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosWebApi
{
    [ExcludeFromCodeCoverage]
    public static class Register
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAtivoService, AtivoService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<ITransacaoService, TransacaoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ITokenService, TokenService>();
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
