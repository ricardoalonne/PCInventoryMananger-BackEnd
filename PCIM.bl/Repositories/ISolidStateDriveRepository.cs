using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Repositories
{
    public interface ISolidStateDriveRepository : IGenericRepository<SolidStateDrive>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
