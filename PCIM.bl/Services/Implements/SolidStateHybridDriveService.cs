using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class SolidStateHybridDriveService : GenericService<SolidStateHybridDrive>, ISolidStateHybridDriveService
    {
        public SolidStateHybridDriveService(ISolidStateHybridDriveRepository solidStateHybridDriveRepository) : base(solidStateHybridDriveRepository)
        {

        }

        private readonly ISolidStateHybridDriveRepository solidStateHybridDriveRepository;
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await solidStateHybridDriveRepository.DeleteCheckOnEntity(id);
        }
    }
}
