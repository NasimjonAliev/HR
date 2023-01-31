using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Mappers.StaffMappers
{
    public class StaffViewMapper : Profile 
    {
        public StaffViewMapper()
        {
            CreateMap<Staff, StaffViewModel>()
                .ForMember(c => c.UserName, d => d.MapFrom(scr => $"{scr.User.FirstName} {scr.User.LastName}"))
                .ForMember(c => c.EducationName, d => d.MapFrom(c => c.Education.UniversityName))
                .ForMember(c => c.PositionName, d => d.MapFrom(scr => scr.Position.Name));               
        }
    }
}
