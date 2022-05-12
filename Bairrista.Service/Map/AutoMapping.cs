using AutoMapper;

namespace Bairrista.Service.Map
{
    public static class AutoMapping
    {
        public static IMapper mapper;
        public static void Initializer()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();                
                cfg.AddProfile<UsuarioProfile>();
                cfg.AddProfile<EnderecoProfile>();
                cfg.AddProfile<OrcamentoProfile>();
                cfg.AddProfile<OrcamentoRespostaProfile>();
                cfg.AddProfile<AvaliacaoProfile>();
                cfg.AddProfile<PagamentoUsuarioProfile>();
                cfg.AddProfile<ProfissaoProfile>();
                cfg.AddProfile<EstadoProfile>();
                cfg.AddProfile<MunicipioProfile>();
            });

            mapper = configuration.CreateMapper();
        }
    }
}
