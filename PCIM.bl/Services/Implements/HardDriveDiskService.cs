using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class HardDriveDiskService : GenericService<HardDriveDisk>, IHardDriveDiskService
    {
        public HardDriveDiskService(IHardDriveDiskRepository hardDriveDiskRepository) : base(hardDriveDiskRepository)
        {

        }

        private readonly IHardDriveDiskRepository hardDriveDiskRepository;
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await hardDriveDiskRepository.DeleteCheckOnEntity(id);
        }
    }
}
