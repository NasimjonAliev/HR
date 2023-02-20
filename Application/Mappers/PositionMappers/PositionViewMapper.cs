using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.PositionModels;

namespace Hr.Application.Mappers.PositionMappers
{
    public class PositionViewMapper : Profile
    {
        public PositionViewMapper()
        {
            CreateMap<Position, PositionViewModel>();
        }
    }
}
