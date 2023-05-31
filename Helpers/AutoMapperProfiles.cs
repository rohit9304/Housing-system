using AutoMapper;
using Housing_system.BussinessLayer.DTO;
using Housing_system.DataLayer.Models;

namespace Housing_system.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
        }
    }
}
