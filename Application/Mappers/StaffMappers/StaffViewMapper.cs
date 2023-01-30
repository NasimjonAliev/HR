using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Mappers.StaffMappers
{
    public class StaffViewMapper : Profile 
    {
        public StaffViewMapper()
        {
            CreateMap<Staff, StaffViewModel>();
        }
    }
}
