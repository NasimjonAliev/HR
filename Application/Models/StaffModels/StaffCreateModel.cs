using Hr.Application.Models.UserModels;

namespace Hr.Application.Models.StaffModels
{
    public class StaffCreateModel
    {
        public Guid UserId { get; set; }
        public Guid EducationId { get; set; }
        public Guid PositionId { get; set; }
    }
}
