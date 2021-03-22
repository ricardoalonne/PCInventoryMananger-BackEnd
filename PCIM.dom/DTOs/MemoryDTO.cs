using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dom.DTOs
{
    public class MemoryDTO
    {
        [Required(ErrorMessage = "El campo ID es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string Description { get; set; }
        public string Marker { get; set; } //fabricante
        public string Model { get; set; }
        public string TypeMemory { get; set; } // SRAM DRAM SDRAM
        public decimal Size { get; set; }
        public int DataTransferSpeeds { get; set; } //Mb/s
    }
}
