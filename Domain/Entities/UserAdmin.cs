using Domain.Entities.Common;

namespace Domain.Entities
{
    public class UserAdmin : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
