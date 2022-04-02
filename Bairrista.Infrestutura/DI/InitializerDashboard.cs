using Bairrista.Dominio;
using Bairrista.Dominio.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Bairrista.Infraestrutura
{
    public class InitializerDashboard
    {
        IServiceCollection _services;
        IConfiguration _configuration;
        public InitializerDashboard(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }
        public virtual void DataBaseContext()
        {
            var server = _configuration["database:postgresql:server"];
            var port = _configuration["database:postgresql:port"];
            var database = _configuration["database:postgresql:database"];
            var username = _configuration["database:postgresql:username"];
            var password = _configuration["database:postgresql:password"];
            var ssl = _configuration["database:postgresql:ssl"];
            var certificate = _configuration["database:postgresql:certificate"];


            _services.AddDbContext<DashboardContext>(options =>
            {
                options.UseNpgsql($"Server={server}; Database={database}; User Id={username}; Password={password};SSL Mode={ssl}; Trust Server Certificate={certificate};", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });
        }

        public virtual void Services()
        {
            _services.AddScoped<IEnderecoService, EnderecoService>();
            _services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            _services.AddScoped<IOrcamentoService, OrcamentoService>();
            _services.AddScoped<IOrcamentoRespostaService, OrcamentoRespostaService>();
            _services.AddScoped<IPagamentoUsuarioService, PagamentoUsuarioService>();
            _services.AddScoped<IProfissaoService, ProfissaoService>();
            _services.AddScoped<IEstadoService, EstadoService>();
            _services.AddScoped<IMunicipioService, MunicipioService>();            
            _services.AddScoped<IUsuarioService, UsuarioService>();
            _services.AddScoped<IAuthService, AuthService>();          
            _services.AddScoped<AppSetting>();
        }

        public virtual void Settings()
        {
            IConfigurationSection tokenSettingsSection = _configuration.GetSection("TokenSettings");
            _services.Configure<TokenSettings>(tokenSettingsSection);

            //Acessando o AppSetting
            IConfigurationSection appSettingsSection = _configuration.GetSection("AppSettings");
            _services.Configure<AppSetting>(appSettingsSection);
        }
    }
}
