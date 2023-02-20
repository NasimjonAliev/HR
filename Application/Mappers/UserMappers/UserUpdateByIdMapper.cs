using AutoMapper;
using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Mappers.UserMappers
{
    public class UserUpdateByIdMapper : Profile
    {
        public UserUpdateByIdMapper()
        {
            CreateMap<User, UserUpdateModelById>();
        }
    }
}