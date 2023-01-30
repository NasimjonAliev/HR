using AutoMapper;
using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Mappers.UserMappers
{
    public class UserViewMapper : Profile
    {
        public UserViewMapper()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}