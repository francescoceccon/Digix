using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Application.Mappers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Family, FamilyDTO>()
                .ForMember(src => src.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.Income, opt => opt.MapFrom(src => src.Income))
                .ForMember(src => src.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
