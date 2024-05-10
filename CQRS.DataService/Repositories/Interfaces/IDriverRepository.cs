using CQRS.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataService.Repositories.Interfaces
{
    public interface IDriverRepository: IGenericRepository<Driver>
    {
    }
}
