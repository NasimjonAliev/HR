using AutoMapper;
using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Mappers.UserMappers
{
    public class UserCreateMapper : Profile
    {
        public UserCreateMapper()
        {
            CreateMap<UserCreateModel, User>()
                .ForMember(c=>c.FirstName, d=>d.MapFrom(r=>r.FirstName));
        }
    }
}
