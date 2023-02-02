using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(Guid id);
        Task<UserUpdateModelById> GetByIdUpdate(Guid id);
        Task Create(UserCreateModel userCreateModel);
        Task Update(UserUpdateModel userUpdateModel);
        Task Delete(Guid id);
    }
}
