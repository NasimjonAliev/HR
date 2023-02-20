using Hr.Application.Models.EducationModels;

namespace Hr.Application.Services
{
    public interface IEducationService
    {
        Task<List<EducationViewModel>> GetAll();
        Task<EducationViewModel> GetById(Guid id);
        Task Create(EducationCreateModel position);
        Task Update(EducationUpdateModel position);
        Task Delete(Guid id);
    }
}
