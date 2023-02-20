using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Mappers.EducationMappers
{
    public class EducationUpdateMapper : Profile
    {
        public EducationUpdateMapper()
        {
            CreateMap<EducationUpdateModel, Education>();
        }
    }
}
