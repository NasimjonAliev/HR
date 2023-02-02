using Hr.Application.Models.PositionModels;

namespace Hr.Application.Services
{
    public interface IPositionService
    {
        Task<List<PositionViewModel>> GetAll();
        Task<PositionViewModel> GetById(Guid id);
        Task Create (PositionCreateModel position);
        Task Update(PositionUpdateModel position);
        Task Delete(Guid id);
    }
}
