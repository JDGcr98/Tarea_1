using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_1.Enums;

namespace Tarea_1.Interface
{
    internal class Empleados
    {
      
        
        private static readonly List<Empleado> _empleados = new List<Empleado> {
           
       new Empleado { Nombre = "Dr. Andres López", Rol = "Veterinario" },
        new Empleado { Nombre = "Dra. Ana García", Rol = "Veterinario" },
        new Empleado { Nombre = "Dr. Pedro Martínez", Rol = "Veterinario" },
        new Empleado { Nombre = "Dra. Dayana Rodríguez", Rol = "Veterinario" },
        new Empleado { Nombre = "Dr. David Pérez", Rol = "Veterinario" },

        new Empleado { Nombre = "María", Rol = "Asistente" },
        new Empleado { Nombre = "Pedro", Rol = "Asistente" },
        new Empleado { Nombre = "Luisa", Rol = "Asistente" },
        new Empleado { Nombre = "Juan", Rol = "Asistente" },
        new Empleado { Nombre = "Ana", Rol = "Asistente" },
        new Empleado { Nombre = "Carlos", Rol = "Asistente" },
        new Empleado { Nombre = "Sofía", Rol = "Asistente" }
    };

        public static List<Empleado> ObtenerTodos() => _empleados;

        public static List<Empleado> ObtenerDisponibles(bool disponible = true)
       => _empleados.Where(e => e.Disponible == disponible).ToList();

        public static void AsignarEmpleado(string nombre)
        {
            var empleado = _empleados.FirstOrDefault(e => e.Nombre == nombre);
            if (empleado != null) empleado.Disponible = false;
        }

    }
}

