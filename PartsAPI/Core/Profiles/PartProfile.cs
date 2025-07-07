using PartsAPI.Core.Entities;
using AutoMapper;
using PartsAPI.API.Dtos;

namespace PartsAPI.Core.Profiles
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<Part, PartDto>();
        }
    }
}
