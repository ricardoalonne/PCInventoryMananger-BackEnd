using AutoMapper;
using PCIM.bl.Repositories.Implements;
using PCIM.bl.Services.Implements;
using PCIM.dat;
using PCIM.dom.DTOs;
using PCIM.dom.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace PCIM.api.Controllers
{
    public class MemoryController : ApiController
    {
        private IMapper mapper;
        private readonly MemoryService memoryService = new MemoryService(new MemoryRepository(PCIMContext.Create()));

        public MemoryController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var memories = await memoryService.GetAll();
            var memoryDTO = memories.Select(x => mapper.Map<MemoryDTO>(x));
            return Ok(memoryDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var memory = await memoryService.GetById(id);
            if (memory == null) return NotFound();

            var memoryDTO = mapper.Map<MemoryDTO>(memory);
            return Ok(memoryDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(MemoryDTO memoryDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var memory = mapper.Map<Memory>(memoryDTO);
                memory = await memoryService.Insert(memory);
                return Ok(memory);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(MemoryDTO memoryDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (memoryDTO.Id != id) return BadRequest(ModelState);

            var flag = await memoryService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var memory = mapper.Map<Memory>(memoryDTO);
                memory = await memoryService.Insert(memory);
                return Ok(memory);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await memoryService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                if (!await memoryService.DeleteCheckOnEntity(id)) await memoryService.Delete(id);
                else throw new Exception("Exist ForeingKeys");
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}
