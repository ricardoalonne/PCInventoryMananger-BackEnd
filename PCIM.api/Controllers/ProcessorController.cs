using AutoMapper;
using PCIM.bl.Repositories.Implements;
using PCIM.bl.Services.Implements;
using PCIM.dat;
using PCIM.dom.DTOs;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PCIM.api.Controllers
{
    public class ProcessorController : ApiController
    {
        private IMapper mapper;
        private readonly ProcessorService processorService = new ProcessorService(new ProcessorRepository(PCIMContext.Create()));

        public ProcessorController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var processors = await processorService.GetAll();
            var processorDTO = processors.Select(x => mapper.Map<ProcessorDTO>(x));
            return Ok(processorDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var processor = await processorService.GetById(id);
            if (processor == null) return NotFound();

            var processorDTO = mapper.Map<ProcessorDTO>(processor);
            return Ok(processorDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(ProcessorDTO processorDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var processor = mapper.Map<Processor>(processorDTO);
                processor = await processorService.Insert(processor);
                return Ok(processor);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(ProcessorDTO processorDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (processorDTO.Id != id) return BadRequest(ModelState);

            var flag = await processorService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var processor = mapper.Map<Processor>(processorDTO);
                processor = await processorService.Insert(processor);
                return Ok(processor);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await processorService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                if (!await processorService.DeleteCheckOnEntity(id)) await processorService.Delete(id);
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
