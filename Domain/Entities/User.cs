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
    }
}
