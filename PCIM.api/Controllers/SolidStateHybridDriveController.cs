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
    public class SolidStateHybridDriveController : ApiController
    {
        
        private IMapper mapper;
        private readonly SolidStateHybridDriveService solidStateHybridDriveService = new SolidStateHybridDriveService(new SolidStateHybridDriveRepository(PCIMContext.Create()));

        public SolidStateHybridDriveController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var solidStateHybridDrives = await solidStateHybridDriveService.GetAll();
            var solidStateHybridDriveDTO = solidStateHybridDrives.Select(x => mapper.Map<SolidStateHybridDriveDTO>(x));
            return Ok(solidStateHybridDriveDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var solidStateHybridDrive = await solidStateHybridDriveService.GetById(id);
            if (solidStateHybridDrive == null) return NotFound();

            var solidStateHybridDriveDTO = mapper.Map<SolidStateHybridDriveDTO>(solidStateHybridDrive);
            return Ok(solidStateHybridDriveDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(SolidStateHybridDriveDTO solidStateHybridDriveDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var solidStateHybridDrive = mapper.Map<SolidStateHybridDrive>(solidStateHybridDriveDTO);
                solidStateHybridDrive = await solidStateHybridDriveService.Insert(solidStateHybridDrive);
                return Ok(solidStateHybridDrive);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(SolidStateHybridDriveDTO solidStateHybridDriveDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (solidStateHybridDriveDTO.Id != id) return BadRequest(ModelState);

            var flag = await solidStateHybridDriveService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var solidStateHybridDrive = mapper.Map<SolidStateHybridDrive>(solidStateHybridDriveDTO);
                solidStateHybridDrive = await solidStateHybridDriveService.Insert(solidStateHybridDrive);
                return Ok(solidStateHybridDrive);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await solidStateHybridDriveService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                if (!await solidStateHybridDriveService.DeleteCheckOnEntity(id)) await solidStateHybridDriveService.Delete(id);
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
