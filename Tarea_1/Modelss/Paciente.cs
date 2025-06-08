using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1.Enums
{
    internal class Paciente
    {
        public string NombreDueno { get; set; }
        public string NombreAnimal { get; set; }
        public string TipoAnimal { get; set; } 
        public string EspecificacionTipo { get; set; } 
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; } 
        public int NivelSangrado { get; set; }
        public string SignosVitales { get; set; }
        public TipoIngreso TipoRegistro { get; set; }
        public string Medicamentos { get; set; } 
        public string Observaciones { get; set; }




        public enum TipoIngreso
    {
        Emergencia,
        Cita
    }


    }

}
