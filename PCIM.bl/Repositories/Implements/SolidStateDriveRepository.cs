using PCIM.dat;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Repositories.Implements
{
    public class SolidStateDriveRepository : GenericRepository<SolidStateDrive>,ISolidStateDriveRepository
    {
        public SolidStateDriveRepository(PCIMContext pcimContext) : base(pcimContext)
        {

        }

        private readonly PCIMContext pcimContext;
        public Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = pcimContext.Computers.AnyAsync(x => x.DiskSSDId == id);
            return flag;
        }
    }
}
