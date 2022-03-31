using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<UsuarioRequest, Usuario>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
