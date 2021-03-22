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
    public class SolidStateDriveController : ApiController
    {
        
        private IMapper mapper;
        private readonly SolidStateDriveService solidStateDriveService = new SolidStateDriveService(new SolidStateDriveRepository(PCIMContext.Create()));

        public SolidStateDriveController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var solidStateDrives = await solidStateDriveService.GetAll();
            var solidStateDriveDTO = solidStateDrives.Select(x => mapper.Map<SolidStateDriveDTO>(x));
            return Ok(solidStateDriveDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var solidStateDrive = await solidStateDriveService.GetById(id);
            if (solidStateDrive == null) return NotFound();

            var solidStateDriveDTO = mapper.Map<SolidStateDriveDTO>(solidStateDrive);
            return Ok(solidStateDriveDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(SolidStateDriveDTO solidStateDriveDTO)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var solidStateDrive = mapper.Map<SolidStateDrive>(solidStateDriveDTO);
                solidStateDrive = await solidStateDriveService.Insert(solidStateDrive);
                return Ok(solidStateDrive);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(SolidStateDriveDTO solidStateDriveDTO, int id)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);

            if (solidStateDriveDTO.Id != id) return BadRequest(ModelState);

            var flag = await solidStateDriveService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                var solidStateDrive = mapper.Map<SolidStateDrive>(solidStateDriveDTO);
                solidStateDrive = await solidStateDriveService.Insert(solidStateDrive);
                return Ok(solidStateDrive);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await solidStateDriveService.GetById(id);

            if (flag == null) return NotFound();

            try
            {
                if (!await solidStateDriveService.DeleteCheckOnEntity(id)) await solidStateDriveService.Delete(id);
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
