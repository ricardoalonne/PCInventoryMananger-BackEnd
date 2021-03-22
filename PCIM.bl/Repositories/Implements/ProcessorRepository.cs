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
    public class ProcessorRepository : GenericRepository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(PCIMContext pcimContext) : base(pcimContext)
        {

        }

        private readonly PCIMContext pcimContext;
        public Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = pcimContext.Computers.AnyAsync(x => x.ProcessorId == id);
            return flag;
        }
    }
}
