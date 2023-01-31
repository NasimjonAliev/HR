using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Mappers.EducationMappers
{
    public class EducationCreateMapper : Profile
    {
        public EducationCreateMapper()
        {
            CreateMap<EducationCreateModel, Education>();
        }
    }
}
