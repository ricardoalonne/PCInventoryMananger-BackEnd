using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class SolidStateDriveService : GenericService<SolidStateDrive>, ISolidStateDriveService
    {
        public SolidStateDriveService(ISolidStateDriveRepository solidStateDriveRepository) : base(solidStateDriveRepository)
        {

        }

        private readonly ISolidStateDriveRepository solidStateDriveRepository;
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await solidStateDriveRepository.DeleteCheckOnEntity(id);
        }
    }
}
