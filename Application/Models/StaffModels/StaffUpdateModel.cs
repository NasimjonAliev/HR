using Hr.Application.Models.UserModels;

namespace Hr.Application.Models.StaffModels
{
    public class StaffUpdateModel : UserUpdateModel
    {
        public string EducationLevel { get; set; }
        public string Position { get; set; }
        public double Amount { get; set; }
    }

}
