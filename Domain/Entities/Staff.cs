
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Staff : User
    {
        public Guid UserId { get; set; }
        public Guid EducationId { get; set; }
        public Guid PositionId { get; set; }

        public User User { get; set; }
        public Education Education { get; set; } 
        public Position Position { get; set; }
    }
}
