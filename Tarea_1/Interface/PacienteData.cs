using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_1.Enums;

namespace Tarea_1.Interface
{
    internal class PacienteData
    {
        // Lista de todos los pacientes registrados (privada y readonly para seguridad)
        private static readonly List<Paciente> _pacientes = new List<Paciente>();

        // Método para agregar pacientes con validaciones
        public static void AgregarPaciente(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente), "El paciente no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(paciente.NombreAnimal))
                throw new ArgumentException("El nombre del animal no puede estar vacío.", nameof(paciente.NombreAnimal));

            if (string.IsNullOrWhiteSpace(paciente.NombreDueno))
                throw new ArgumentException("El nombre del dueño no puede estar vacío.", nameof(paciente.NombreDueno));

            _pacientes.Add(paciente);
        }



        // Método para buscar pacientes por nombre (coincidencia exacta)
        public static List<Paciente> BuscarPorNombreAnimal(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return new List<Paciente>();

            return _pacientes
                .Where(p => p.NombreAnimal.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Método para obtener todos los pacientes (devuelve copia para seguridad)
        public static List<Paciente> ObtenerTodos() => new List<Paciente>(_pacientes);

        // Método para filtrar pacientes por tipo (emergencia/cita)
        public static List<Paciente> FiltrarPorTipo(Paciente.TipoIngreso tipo)
        {
            return _pacientes
                .Where(p => p.TipoRegistro == tipo)
                .ToList();
        }

        // Método para eliminar paciente por nombre exacto
        public static bool EliminarPaciente(string nombreAnimal)
        {
            if (string.IsNullOrWhiteSpace(nombreAnimal))
                return false;

            var paciente = _pacientes.FirstOrDefault(p =>
                p.NombreAnimal.Equals(nombreAnimal, StringComparison.OrdinalIgnoreCase));

            if (paciente != null)
            {
                _pacientes.Remove(paciente);
                return true;
            }
            return false;
        }

        // Nuevo método para buscar coincidencias parciales
        public static List<Paciente> BuscarParcialmentePorNombre(string nombreParcial)
        {
            if (string.IsNullOrWhiteSpace(nombreParcial))
                return new List<Paciente>();

            return _pacientes
                .Where(p => p.NombreAnimal.IndexOf(nombreParcial, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
