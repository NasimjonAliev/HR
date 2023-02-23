using System.Collections.ObjectModel;

namespace Domain.Entities.Common
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int  Age { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public ICollection<Staff> Staffs { get; set; } = new Collection<Staff>();
    }
}
