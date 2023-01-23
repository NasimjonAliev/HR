using Hr.Application.Models.UserModels;

namespace Hr.Application.Models.StaffModels
{
    public class StaffUpdateModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EducationId { get; set; }
        public Guid PositionId { get; set; }
    }
}
