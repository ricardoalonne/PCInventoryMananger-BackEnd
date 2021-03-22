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
    public class HardDriveDiskController : ApiController
    {
        
        private IMapper mapper;
        private readonly HardDriveDiskService hardDriveDiskService = new HardDriveDiskService(new HardDriveDiskRepository(PCIMContext.Create()));

        public HardDriveDiskController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var hardDriveDisks = await hardDriveDiskService.GetAll();
            var hardDriveDiskDTO = hardDriveDisks.Select(x => mapper.Map<HardDriveDiskDTO>(x));
            return Ok(hardDriveDiskDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var hardDriveDisk = await hardDriveDiskService.GetById(id);
            if (hardDriveDisk == null) return NotFound();

            var hardDriveDiskDTO = mapper.Map<HardDriveDiskDTO>(hardDriveDisk);
            return Ok(hardDriveDiskDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(HardDriveDiskDTO hardDriveDiskDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var hardDriveDisk = mapper.Map<HardDriveDisk>(hardDriveDiskDTO);
                hardDriveDisk = await hardDriveDiskService.Insert(hardDriveDisk);
                return Ok(hardDriveDisk);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(HardDriveDiskDTO hardDriveDiskDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (hardDriveDiskDTO.Id != id) return BadRequest(ModelState);

            var flag = await hardDriveDiskService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var hardDriveDisk = mapper.Map<HardDriveDisk>(hardDriveDiskDTO);
                hardDriveDisk = await hardDriveDiskService.Insert(hardDriveDisk);
                return Ok(hardDriveDisk);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await hardDriveDiskService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                if (!await hardDriveDiskService.DeleteCheckOnEntity(id)) await hardDriveDiskService.Delete(id);
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
