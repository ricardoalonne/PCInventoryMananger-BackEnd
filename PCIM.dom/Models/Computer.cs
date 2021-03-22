using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCIM.dom.Models
{
    [Table("Computer", Schema = "dbo")]
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Marker { get; set; }
        
        [ForeignKey("Processor")]
        public int ProcessorId { get; set; }
        [ForeignKey("Memory")]
        public int MemoryId { get; set; }
        [ForeignKey("SolidStateDrive")]
        public int DiskSSDId { get; set; }
        [ForeignKey("HardDriveDisk")]
        public int DiskHDDId { get; set; }
        [ForeignKey("SolidStateHybridDrive")]
        public int DiskSSHDId { get; set; }

        public Processor Processor { get; set; }
        public Memory Memory { get; set; }
        public SolidStateDrive SolidStateDrive { get; set; }
        public HardDriveDisk HardDriveDisk { get; set; }
        public SolidStateHybridDrive SolidStateHybridDrive { get; set; }
       
    }
}
