using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Mappers.StaffMappers
{
    public class StaffCreateMapper : Profile
    {
        public StaffCreateMapper()
        {
            CreateMap<StaffCreateModel, Staff>(); 
        }
    }
}
