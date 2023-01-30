using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Services
{
    public interface IStaffService
    {
        Task<List<StaffViewModel>> GetAll();
        Task<StaffViewModel> GetById(Guid id);
        Task Create(StaffCreateModel staffCreateModel);
        Task Update(StaffUpdateModel staffUpdateModel);
        Task Delete(Guid id);

    }
}
