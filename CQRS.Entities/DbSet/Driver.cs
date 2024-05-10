using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Entities.DbSet
{
    public class Driver : BaseEntity
    {
        public Driver() 
        {
            Achievements = new HashSet<Achievement>();
        } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DriversNumber { get; set; }
        public DateTime DateOfBirth {  get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
