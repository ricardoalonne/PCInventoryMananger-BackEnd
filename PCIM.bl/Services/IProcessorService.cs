using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services
{
    public interface IProcessorService : IGenericService<Processor>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
