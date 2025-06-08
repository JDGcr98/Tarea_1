using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1.Enums
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }  // "Veterinario" o "Asistente"
        public bool Disponible { get; set; } = true;
    }
}
