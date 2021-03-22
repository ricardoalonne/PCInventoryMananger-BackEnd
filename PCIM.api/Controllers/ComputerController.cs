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
    public class ComputerController : ApiController
    {
        private IMapper mapper;
        private readonly ComputerService computerService = new ComputerService(new ComputerRepository(PCIMContext.Create()));

        public ComputerController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll() {
            var computers = await computerService.GetAll();
            var computerDTO = computers.Select(x => mapper.Map<ComputerDTO>(x));
            return Ok(computerDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var computer = await computerService.GetById(id);
            if (computer == null) return NotFound();

            var computerDTO = mapper.Map<ComputerDTO>(computer);
            return Ok(computerDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(ComputerDTO computerDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try 
            {
                var computer = mapper.Map<Computer>(computerDTO);
                computer = await computerService.Insert(computer);
                return Ok(computer);
            } catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(ComputerDTO computerDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (computerDTO.Id != id) return BadRequest(ModelState);

            var flag = await computerService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var computer = mapper.Map<Computer>(computerDTO);
                computer = await computerService.Insert(computer);
                return Ok(computer);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await computerService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                await computerService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}
