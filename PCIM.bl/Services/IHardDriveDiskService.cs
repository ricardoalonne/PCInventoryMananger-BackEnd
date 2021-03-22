using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services
{
    interface IHardDriveDiskService : IGenericService<HardDriveDisk>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
