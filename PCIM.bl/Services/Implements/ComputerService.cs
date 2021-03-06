using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class ComputerService : GenericService<Computer>, IComputerService
    {
        public ComputerService(IComputerRepository computerRepository) : base(computerRepository)
        {

        }
    }
}
