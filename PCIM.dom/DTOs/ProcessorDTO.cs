using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIM.dom.DTOs
{
    public class ProcessorDTO
    {
        [Required(ErrorMessage = "El campo ID es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string Description { get; set; }
        public string Marker { get; set; } //INTEL O AMD
        public string Model { get; set; }
        public decimal ClockFrequency { get; set; } //GHZ frecuencia de reloj
        public decimal EnergyConsumption { get; set; } // consumo de energía en Watts
        public int NumberOfCores { get; set; } //numero de nucleos
        public string Socket { get; set; } //zócalo intel (socket 1151) y AMD (AM4)
        public int NumberOfthreads { get; set; } //numero de hilos
        public decimal Cache { get; set; } //memoria cache


    }
}
