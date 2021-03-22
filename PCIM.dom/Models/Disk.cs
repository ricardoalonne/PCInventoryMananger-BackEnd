using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCIM.dom.Models
{
    [Table("Disk", Schema = "dbo")]
    public class Disk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Marker { get; set; }
        public decimal Size { get; set; } //tamanno en GB o TB
        public decimal ReadingSpeed { get; set; }
        public decimal WriteSpeed { get; set; }
        public string DiskFormat { get; set; } //SATA, mSATA, M.2 SATA, M.2 PCIe, PCIe, U.2 | SATA 2.5, SATA 3.5

    }

    [Table("SolidStateDrive", Schema = "dbo")]
    public class SolidStateDrive : Disk
    {
        public int NumberOfMemoriesNandFlash { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }

    }

    [Table("HardDriveDisk", Schema = "dbo")]
    public class HardDriveDisk : Disk
    {
        public int NumberOfSaucers { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }

    [Table("SolidStateHybridDrive", Schema = "dbo")]
    public class SolidStateHybridDrive : Disk
    {
        public int NumberOfSaucers { get; set; }
        public int NumberOfMemoriesNandFlash { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}
