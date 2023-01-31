using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Mappers.EducationMappers
{
    public class EducationViewMapper : Profile
    {
        public EducationViewMapper()
        {
            CreateMap<Education, EducationViewModel>();
        }
    }
}
