using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.PositionModels;

namespace Hr.Application.Mappers.PositionMappers
{
    public class PositionUpdateMapper : Profile
    {
        public PositionUpdateMapper()
        {
            CreateMap<PositionUpdateModel, Position>();
        }
    }
}
