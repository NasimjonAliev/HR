using AutoMapper;
using Domain.Entities;
using Domain.Entities.Common;

namespace Hr.Application.Mappers.UserMappers
{
    public class UserAdminMapper : Profile
    {
        public UserAdminMapper()
        {
            CreateMap<UserAdmin, User>();
        }
    }
}

