using PCIM.dat;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Repositories.Implements
{
    public class ComputerRepository :GenericRepository<Computer>, IComputerRepository
    {
        
        public ComputerRepository(PCIMContext pcimContext) : base(pcimContext)
        {

        }
    }
}
