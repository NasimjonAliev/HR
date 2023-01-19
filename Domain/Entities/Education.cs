
using Domain.Entities.Common;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Education : BaseEntity
    {
        public string EducationLevel { get; set; }
        public string UniversityName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public ICollection<Staff> Staffs { get; set; } = new Collection<Staff>();
    }
}
