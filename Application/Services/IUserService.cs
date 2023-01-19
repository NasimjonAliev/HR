using Domain.Entities.Common;
using Hr.Application.Models.UserModels;

namespace Hr.Application.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(Guid id);
        Task<User> Create(UserCreateModel userCreateModel);
        Task<User> Update(UserUpdateModel userUpdateModel);
        Task<User> Delete(Guid id);
    }
}
