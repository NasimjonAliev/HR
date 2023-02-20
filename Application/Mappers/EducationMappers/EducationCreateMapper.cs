using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.EducationModels;

namespace Hr.Application.Mappers.EducationMappers
{
    public class EducationCreateMapper : Profile
    {
        public EducationCreateMapper()
        {
            //TODO расмотреть и применить метод ReverseMap()
            CreateMap<EducationCreateModel, Education>();
        }
    }
}
