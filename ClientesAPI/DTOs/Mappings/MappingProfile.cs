using AutoMapper;
using ClientesAPI.Models;

namespace ClientesAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<ClienteModel, ClienteDTO>().ReverseMap();
          CreateMap<ContatoModel, ContatoDTO>().ReverseMap();
          CreateMap<EnderecoModel, EnderecoDTO>().ReverseMap();
        }
    }
}
