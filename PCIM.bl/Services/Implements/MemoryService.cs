using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class MemoryService : GenericService<Memory>, IMemoryService
    {
       
        public MemoryService(IMemoryRepository memoryRepository) : base(memoryRepository)
        {
            this.memoryRepository = memoryRepository;
        }
        private readonly IMemoryRepository memoryRepository;
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await memoryRepository.DeleteCheckOnEntity(id);
        }
    }
}
