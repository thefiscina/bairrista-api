using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class ProfissaoProfile : Profile
    {
        public ProfissaoProfile()
        {
            CreateMap<Profissao, ProfissaoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ProfissaoRequest, Profissao>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
