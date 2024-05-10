using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Entities.Dtos.Requests
{
    public class UpdateDriverRequest
    {
        public Guid DriverId { get; set; }  
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DriversNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
