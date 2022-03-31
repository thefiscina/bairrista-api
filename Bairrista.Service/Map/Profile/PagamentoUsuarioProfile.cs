using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class PagamentoUsuarioProfile : Profile
    {
        public PagamentoUsuarioProfile()
        {
            CreateMap<PagamentoUsuario, PagamentoUsuarioResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PagamentoUsuarioRequest, PagamentoUsuario>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
