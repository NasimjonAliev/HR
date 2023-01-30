using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Mappers.StaffMappers
{
    public class StaffUpdateMapper : Profile 
    {
        public StaffUpdateMapper()
        {
            CreateMap<StaffUpdateModel, Staff>();
        }
    }
}
