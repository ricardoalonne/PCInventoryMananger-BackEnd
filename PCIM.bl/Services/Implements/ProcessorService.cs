using PCIM.bl.Repositories;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.bl.Services.Implements
{
    public class ProcessorService : GenericService<Processor>, IProcessorService
    {
        public ProcessorService(IProcessorRepository  processorRepository) : base(processorRepository)
        {

        }

        private readonly IProcessorRepository processorRepository;
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await processorRepository.DeleteCheckOnEntity(id);
        }
    }
}
