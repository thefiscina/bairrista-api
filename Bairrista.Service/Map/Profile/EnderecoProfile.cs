using AutoMapper;
using Bairrista.Dominio;
using Bairrista.Service.Model;

namespace Bairrista.Service.Map
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoResponse>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<EnderecoRequest, Endereco>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
