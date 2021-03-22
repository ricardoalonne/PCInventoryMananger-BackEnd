using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dom.DTOs
{
    public class ComputerDTO
    {
        [Required(ErrorMessage = "El campo ID es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }
        public string Marker { get; set; }

        
        public int ProcessorId { get; set; }
        public int MemoryId { get; set; }
        public int DiskSSDId { get; set; }
        public int DiskHDDId { get; set; }
        public int DiskSSHDId { get; set; }
        
        public ProcessorDTO Processor { get; set; }
        public MemoryDTO Memory { get; set; }
        public SolidStateDriveDTO SolidStateDrive { get; set; }
        public HardDriveDiskDTO HardDriveDisk { get; set; }
        public SolidStateHybridDriveDTO SolidStateHybridDrive { get; set; }

        /*
        public string GetProcessor
        {
            get { return Processor.Description; }
        }

        public string GetMemory
        {
            get { return Memory.Description; }
        }

        public string GetSSD
        {
            get { return SolidStateDrive.Description; }
        }

        public string GetHDD
        {
            get { return HardDriveDisk.Description; }
        }

        public string GetSSHD
        {
            get { return SolidStateHybridDrive.Description; }
        }
        */
    }
}
