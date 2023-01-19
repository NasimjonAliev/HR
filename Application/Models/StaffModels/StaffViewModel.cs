using Hr.Application.Models.UserModels;

namespace Hr.Application.Models.StaffModels
{
    public class StaffViewModel : UserViewModel
    {
        public string PassportNumber { get; set; }
        public string EducationLevel { get; set; }
        public string Position { get; set; }
        public double Amount { get; set; }

    }

}
