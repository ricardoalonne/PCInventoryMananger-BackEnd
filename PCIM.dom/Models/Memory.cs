using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCIM.dom.Models
{
    [Table("Memory", Schema = "dbo")]
    public class Memory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Marker { get; set; } //fabricante
        public string Model { get; set; }
        public string TypeMemory { get; set; } // SRAM DRAM SDRAM
        public decimal Size { get; set; }
        public int DataTransferSpeeds { get; set; } //Mb/s

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
