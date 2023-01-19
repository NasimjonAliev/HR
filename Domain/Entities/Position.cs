
using Domain.Entities.Common;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public ICollection<Staff> Staffs { get; set; } = new Collection<Staff>();
    }
}
