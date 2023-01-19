using Domain.Entities;
using Hr.Application.Models.StaffModels;

namespace Hr.Application.Services
{
    public interface IStaffService
    {
        Task<List<StaffViewModel>> GetAll();
        Task<StaffViewModel> GetById(Guid id);
        Task<Staff> Create(StaffCreateModel staffCreateModel);
        Task<Staff> Update(StaffUpdateModel staffUpdateModel);
        Task<Staff> Delete(Guid id);

    }
}
