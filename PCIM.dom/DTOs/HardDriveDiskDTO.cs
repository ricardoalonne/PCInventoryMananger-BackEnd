using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dom.DTOs
{
    public class HardDriveDiskDTO
    {
        [Required(ErrorMessage = "El campo ID es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string Description { get; set; }
        public string Model { get; set; }
        public string Marker { get; set; }
        public decimal Size { get; set; } //tamanno en GB o TB
        public decimal ReadingSpeed { get; set; }
        public decimal WriteSpeed { get; set; }
        public string DiskFormat { get; set; }

        public int NumberOfSaucers { get; set; }
    }
}
