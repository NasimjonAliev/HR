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
                .ForMember(c => c.UserName, d => d.MapFrom(scr => $"{scr.User.FirstName} {scr.User.LastName} {scr.User.FatherName}"))
                .ForMember(c => c.EducationName, d => d.MapFrom(scr => $"{scr.Education.UniversityName} {scr.Education.EducationLevel}"))
                .ForMember(c => c.PositionName, d => d.MapFrom(scr => $"{scr.Position.Name} {scr.Position.Amount}"));               
        }
    }
}
