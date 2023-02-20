using AutoMapper;
using Domain.Entities;
using Hr.Application.Models.PositionModels;

namespace Hr.Application.Mappers.PositionMappers
{
    public class PositionCreateMapper : Profile
    {
        public PositionCreateMapper()
        {
            CreateMap<PositionCreateModel, Position>();
        }
    }
}
