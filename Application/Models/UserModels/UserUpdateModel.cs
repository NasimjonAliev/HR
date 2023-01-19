namespace Hr.Application.Models.UserModels
{
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
    }
}
