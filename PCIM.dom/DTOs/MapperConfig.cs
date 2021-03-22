using AutoMapper;
using PCIM.dom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dom.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Computer, ComputerDTO>(); //GET
                cfg.CreateMap<ComputerDTO, Computer>(); //POST-PUT

                cfg.CreateMap<Processor, ProcessorDTO>(); //GET
                cfg.CreateMap<ProcessorDTO, Processor>(); //POST-PUT

                cfg.CreateMap<Memory, MemoryDTO>(); //GET
                cfg.CreateMap<MemoryDTO, Memory>(); //POST-PUT

                cfg.CreateMap<SolidStateDrive, SolidStateDriveDTO>(); //GET
                cfg.CreateMap<SolidStateDriveDTO, SolidStateDrive>(); //POST-PUT

                cfg.CreateMap<HardDriveDisk, HardDriveDiskDTO>(); //GET
                cfg.CreateMap<HardDriveDiskDTO, HardDriveDisk>(); //POST-PUT

                cfg.CreateMap<SolidStateHybridDrive, SolidStateHybridDriveDTO>(); //GET
                cfg.CreateMap<SolidStateHybridDriveDTO, SolidStateHybridDrive>(); //POST-PUT

            }); 
        }
    }
}
