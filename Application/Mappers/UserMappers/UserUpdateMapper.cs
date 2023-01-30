using AutoMapper;
using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Mappers.UserMappers
{
    public class UserUpdateMapper : Profile
    {
        public UserUpdateMapper()
        {
            CreateMap<UserUpdateModel, User>();
        }
    }
}