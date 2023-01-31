namespace Hr.Application.Models.EducationModels
{
    public class EducationCreateModel
    {
        public string EducationLevel { get; set; }
        public string UniversityName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
