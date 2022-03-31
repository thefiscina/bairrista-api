using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class OrcamentoResposta : Profile
    {
        public OrcamentoResposta()
        {
            CreateMap<Endereco, EnderecoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<EnderecoRequest, Endereco>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
