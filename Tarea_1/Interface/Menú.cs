using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_1.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tarea_1.Interface
{
    public class Menú
    {

        public void MostrarMenu()
        {

            bool opcionMenu = false;
            Console.WriteLine(" / \\__               /\\_ /\\ ");
            Console.WriteLine("(    @ \\____        ( >.< )");
            Console.WriteLine(" /        O  Veterinaria            ");
            Console.WriteLine("/  (____/       Mundo            ");
            Console.WriteLine("/ ___/ U        Animal         ");
          
            Console.WriteLine("         ");
            Console.WriteLine("       ");
            do

            {
                try
                {

                    Console.WriteLine(" ");
                    Console.WriteLine("****Menu de control de clientes****");
                    Console.WriteLine("\n1 - Emergencia y Atención");
                    Console.WriteLine("2 - Cita");
                    Console.WriteLine("3 - Seguimiento de paciente");
                    Console.WriteLine("4 - Actualizacion de estado de paciente");
                    Console.WriteLine("5 - Historial de paciente");
                    Console.WriteLine("6 - Mostar roll empleados");
                    Console.WriteLine("7 - Salir");
                    Console.WriteLine("\nSeleccione una opcion");
                    

                    string opcion = Console.ReadLine();
                   
        switch (opcion)

                    {
                        case "1":

                            Console.Clear(); //Borrar al entrar al case
                            Console.WriteLine("=== EMERGENCIA Y ATENCIÓN ===");

                            // Fecha de ingreso (automática)
                            DateTime fechaIngreso = DateTime.Now;
                            Console.WriteLine($"Fecha de ingreso: {fechaIngreso}");

                            // Información general (dueño y animal)
                            string nombreDueno = validar.LeerSoloTexto("Nombre del dueño: ");
                            string nombreAnimal = validar.LeerSoloTexto("Nombre del animal: ");
                            

                            // Tipo de animal (Común o Exótico)
                            Console.WriteLine("\nSeleccione el tipo de animal:");
                            Console.WriteLine("1 - Común (Perro, Gato, etc.)");
                            Console.WriteLine("\n2 - Exótico (Reptiles, Aves, etc.)");
                            string opcionTipo = Console.ReadLine();

                            string tipoAnimal = "";
                            string especificacionTipo = "";

                            switch (opcionTipo)
                            {
                                case "1":
                                    tipoAnimal = "Común";
                                    especificacionTipo = validar.LeerSoloTexto("Especifique (Perro, Gato, etc.): ");
                        
                                    break;
                                case "2":
                                    tipoAnimal = "Exótico";
                                    especificacionTipo = validar.LeerSoloTexto("Especifique (Serpiente, Tortuga, etc.): ");
                                    
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida, se asignará como 'Común'.");
                                    tipoAnimal = "Común";
                                    break;
                            }

                            // Clasificación de emergencia
                            Console.WriteLine("\n=== CLASIFICACIÓN DE EMERGENCIA ===");

                            // Sangrado (0%, 50%, 80%+)
                            Console.WriteLine("Nivel de sangrado:");
                            Console.WriteLine("0 - Sin sangrado");
                            Console.WriteLine("1 - Sangrado moderado (50%)");
                            Console.WriteLine("2 - Sangrado grave (80% o más)");
                            int nivelSangrado = int.Parse(Console.ReadLine()) * 50; // Convierte 0→0, 1→50, 2→80+
                            if (nivelSangrado > 80) nivelSangrado = 80; // Asegura que sea 80+ si eligió 2

                            // Signos vitales
                            Console.WriteLine("\nSignos vitales:");
                            Console.WriteLine("1 - Normales");
                            Console.WriteLine("2 - Altos");
                            Console.WriteLine("3 - Emergencia");
                            string[] signosVitalesOpciones = { "Normales", "Altos", "Emergencia" };
                            string signosVitales = signosVitalesOpciones[int.Parse(Console.ReadLine()) - 1];

                            // Asignación de estado
                            string estado;
                            if (nivelSangrado >= 80 || signosVitales == "Emergencia")
                            {
                                estado = "Peligro";
                            }
                            else if (nivelSangrado == 50 || signosVitales == "Altos")
                            {
                                estado = "Hospitalizado";
                            }
                            else
                            {
                                estado = "Estable";
                            }

                            var pacienteEmergencia = new Paciente
                            {
                                NombreDueno = nombreDueno,
                                NombreAnimal = nombreAnimal,
                                TipoAnimal = tipoAnimal,
                                EspecificacionTipo = especificacionTipo,
                                FechaIngreso = fechaIngreso,
                                Estado = estado,
                                NivelSangrado = nivelSangrado,
                                SignosVitales = signosVitales,
                                TipoRegistro = Paciente.TipoIngreso.Emergencia
                            };

                            PacienteData.AgregarPaciente(pacienteEmergencia);

                            // Asignación de veterinario o asistente (según gravedad)
                            List<Empleado> empleados = new List<Empleado>
                           
                            {
                                new Empleado { Nombre = "Dr. López", Rol = "Veterinario" },
                                new Empleado { Nombre = "Dr. García", Rol = "Veterinario" },
                                new Empleado { Nombre = "Asistente María", Rol = "Asistente" },
                                new Empleado { Nombre = "Asistente Pedro", Rol = "Asistente" }
                            };

                            var veterinariosDisponibles = Empleados.ObtenerDisponibles().Where(e => e.Rol == "Veterinario").ToList();

                            // Selección aleatoria
                            if (veterinariosDisponibles.Count > 0)
                            {
                                // Uso de Random (mejor práctica: instancia única)
                                Random rnd = new Random(Guid.NewGuid().GetHashCode()); // Semilla única
                                Empleado veterinarioAsignado = veterinariosDisponibles[rnd.Next(0, veterinariosDisponibles.Count)];

                                // Marcar como no disponible y mostrar info
                                veterinarioAsignado.Disponible = false;
                                Console.WriteLine($"=== RESULTADO DE CLASIFICACIÓN ===");
                                Console.WriteLine($"\nVeterinario asignado: {veterinarioAsignado.Nombre}");

                            }
                            else
                            {
                                Console.WriteLine("\n No hay veterinarios disponibles. El paciente será puesto en lista de espera.");
                            }
                            
                                Console.WriteLine($"Paciente: {nombreAnimal}");
                                Console.WriteLine($"Estado: {estado}");
                                
                            

                            Console.WriteLine("\n Regresando a menú principal...");
                            Console.ReadKey();
                            break;
                        
                        case "2":

                            Console.Clear();
                            Console.WriteLine("=== REGISTRO DE CITA ===");

                            // Datos básicos del paciente
                            string nombredueno = validar.LeerSoloTexto("Nombre del dueño: ");

                            string nombreanimal = validar.LeerSoloTexto("Nombre del animal: ");

                            // Tipo de animal (similar al case 1, pero con lógica de cita)
                             Console.WriteLine("\nTipo de animal: 1-Común / 2-Exótico");
                            string tipo = Console.ReadLine();
                            string tipoanimal = tipo == "1" ? "Común" : "Exótico";


                            // Fecha de la cita (validación básica)
                            Console.Write("Fecha de la cita (dd/MM/yyyy HH:mm): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaCita))
                            {
                                Console.WriteLine("¡Formato de fecha inválido! Use dd/MM/yyyy HH:mm.");
                                break;
                            }

                            // Crear y guardar el paciente
                            try
                            {
                                var pacienteCita = new Paciente
                                {
                                    NombreDueno = nombredueno,
                                    NombreAnimal = nombreanimal,
                                    TipoAnimal = tipoanimal,
                                    FechaIngreso = fechaCita,
                                    TipoRegistro = Paciente.TipoIngreso.Cita,
                                    Estado = "Pendiente" // Estado inicial
                                };

                                PacienteData.AgregarPaciente(pacienteCita);
                                Console.WriteLine("¡Cita registrada exitosamente!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }

                            Console.WriteLine("\n Regresando a menú principal...");
                            Console.ReadKey();




                            break;
                        
                        case "3":

                            Console.Clear();
                            Console.WriteLine("=== BUSCAR PACIENTE ===");

                            // 1. Verificar si hay pacientes
                            var todosPacientes = PacienteData.ObtenerTodos();
                            if (todosPacientes.Count == 0)
                            {
                                Console.WriteLine("\nAVISO: No hay pacientes registrados aún.");
                                Console.WriteLine("Por favor, registre pacientes en las opciones 1 o 2 primero.");
                                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            }

                            // Pedir nombre a buscar
                            Console.Write("\nIngrese nombre del animal: ");
                            string nombre = Console.ReadLine();

                            // Buscar (con sugerencias si no encuentra)
                            var encontrados = PacienteData.BuscarPorNombreAnimal(nombre);

                            if (encontrados.Count == 0)
                            {
                                Console.WriteLine($"\nNo se encontró '{nombre}'.");

                                // Mostrar primeros 3 nombres similares
                                var sugerencias = todosPacientes
                                    .Where(p => p.NombreAnimal.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                                    .Take(3);

                                foreach (var p in sugerencias)
                                {
                                    Console.WriteLine($"- {p.NombreAnimal}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nRESULTADOS:");
                                foreach (var p in encontrados)
                                {
                                    Console.WriteLine("\nINFORMACION DEL PACIENTE:");
                                   // Console.WriteLine("ID: " + p.GetHashCode()); // Identificador temporal
                                    Console.WriteLine("Dueño: " + p.NombreDueno);
                                    Console.WriteLine("Animal: " + p.NombreAnimal + " (" + p.TipoAnimal + " - " + p.EspecificacionTipo + ")");
                                    Console.WriteLine("Fecha: " + p.FechaIngreso.ToString("dd/MM/yyyy HH:mm"));
                                    Console.WriteLine("Tipo: " + p.TipoRegistro);
                                    Console.WriteLine("Estado: " + p.Estado);
                                    Console.WriteLine("Signos vitales: " + p.SignosVitales);
                                    Console.WriteLine("----------------------------------------");

                                }
                            }


                            Console.WriteLine("\n Regresando a menú principal...");
                            Console.ReadKey();
                            break;
                        
                        case "4":

                            Console.Clear();
                            Console.WriteLine("=== ACTUALIZACIÓN DE ESTADO ===");

                            // Verificar si hay pacientes registrados
                            if (!PacienteData.ObtenerTodos().Any())
                            {
                                Console.WriteLine("\n No hay pacientes registrados en el sistema.");
                                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            }

                            // Mostrar lista de pacientes (solo nombres) para referencia
                            Console.WriteLine("\nPacientes registrados:");
                            foreach (var p in PacienteData.ObtenerTodos().Take(2))
                            {
                                Console.WriteLine($"- {p.NombreAnimal} (Estado actual: {p.Estado})");
                            }

                            // Solicitar nombre del paciente a actualizar
                            string nombreBuscado = validar.LeerSoloTexto("\nIngrese el nombre del animal a actualizar: ");
                             

                            // Buscar paciente (usando tu método existente)
                            var paciente = PacienteData.BuscarPorNombreAnimal(nombreBuscado).FirstOrDefault();

                            if (paciente == null)
                            {
                                Console.WriteLine($"\n No se encontró paciente con nombre '{nombreBuscado}'");

                               
                                var sugerencias = PacienteData.BuscarParcialmentePorNombre(nombreBuscado);
                                if (sugerencias.Any())
                                {
                                    Console.WriteLine("\n¿Quizás quisiste decir?");
                                    foreach (var s in sugerencias.Take(3))
                                    {
                                        Console.WriteLine($"- {s.NombreAnimal}");
                                    }
                                }
                            }
                            else
                            {
                                // 5. Mostrar datos actuales, no editables
                                Console.WriteLine("\n Datos actuales:");
                                Console.WriteLine($"Dueño: {paciente.NombreDueno}");
                                Console.WriteLine($"Animal: {paciente.NombreAnimal}");
                                Console.WriteLine($"Estado actual: {paciente.Estado}");
                                Console.WriteLine($"Última actualización: {paciente.FechaIngreso:dd/MM/yyyy HH:mm}");

                                // 6. Menú de estados disponibles
                                Console.WriteLine("\n Seleccione nuevo estado:");
                                Console.WriteLine("1 - Estable");
                                Console.WriteLine("2 - Hospitalizado");
                                
                                Console.WriteLine("3 - Cirugía programada");
                                Console.WriteLine("4 - Alta médica");
                                Console.Write("Opción: ");

                                // 7. Procesar actualización
                                if (int.TryParse(Console.ReadLine(), out int opcioN))
                                {
                                    string nuevoEstado = opcioN switch
                                    {
                                        1 => "Estable",
                                        2 => "Hospitalizado",
                                        3 => "Cirugía programada",
                                        4 => "Alta médica",
                                        _ => null
                                    };


                                    Console.Write("\n Medicamentos utilizados: ");
                                    string medicamentos = Console.ReadLine();

                                    Console.Write("\n Observaciones adicionales: ");
                                    string observaciones = Console.ReadLine();

                                    if (nuevoEstado != null)
                                    {
                                        // Actualizar estado y fecha
                                        paciente.Estado = nuevoEstado;
                                        paciente.FechaIngreso = DateTime.Now;


                                        Console.WriteLine($"-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                                        Console.WriteLine($" Estado actualizado a: {nuevoEstado}-*-*-*-*-*");
                                        Console.WriteLine($" Estado actualizado a: {medicamentos}-*-*-*-*-*-*-*-*");
                                        Console.WriteLine($" Estado actualizado a: {observaciones} -*-*-*-*-*-*-*-");
                                        Console.WriteLine($" Fecha de actualización: {DateTime.Now:dd/MM/yyyy HH:mm}");

                                        paciente.Medicamentos = medicamentos;
                                        paciente.Observaciones = observaciones;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n Opción no válida");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n Debe ingresar un número válido");
                                }
                            }

                            Console.ReadKey();

                            break;
                        
                        case "5":

                            Console.Clear();
                            Console.WriteLine("=== LISTA DE PACIENTES ===");

                            // Obtener la lista de pacientes
                            var pacientes = PacienteData.ObtenerTodos();

                            if (pacientes.Count == 0)
                            {
                                Console.WriteLine("No hay pacientes registrados.");
                            }
                            else
                            {
                                Console.WriteLine($"Total de pacientes: {pacientes.Count}");

                                foreach (var p in pacientes)
                                {
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Dueño: " + p.NombreDueno);
                                    Console.WriteLine("Animal: " + p.NombreAnimal);
                                    Console.WriteLine("Tipo: " + p.TipoAnimal);
                                    Console.WriteLine("Especificación: " + p.EspecificacionTipo);
                                    Console.WriteLine("Fecha de ingreso: " + p.FechaIngreso.ToString("dd/MM/yyyy"));
                                    Console.WriteLine("Tipo de registro: " + p.TipoRegistro);
                                    Console.WriteLine("Estado: " + p.Estado);
                                    Console.WriteLine("Nivel de sangrado: " + p.NivelSangrado + "%");
                                    Console.WriteLine("Signos vitales: " + p.SignosVitales);

                                    if (!string.IsNullOrEmpty(p.Medicamentos))
                                        Console.WriteLine("Medicamentos: " + p.Medicamentos);

                                    if (!string.IsNullOrEmpty(p.Observaciones))
                                        Console.WriteLine("Observaciones: " + p.Observaciones);
                                }
                            }

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();

                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("=== ESTADO DEL PERSONAL MÉDICO ===");

                            var empleado = Empleados.ObtenerTodos();

                            if (!empleado.Any())
                            {
                                Console.WriteLine("\nNo hay empleados registrados.");
                            }
                            else
                            {
                                Console.WriteLine("\nListado de personal:");
                                Console.WriteLine("--------------------------------------------------");
                                Console.WriteLine($"{"ROL",-15}{"NOMBRE",-25}ESTADO");
                                Console.WriteLine("--------------------------------------------------");

                                foreach (var emp in empleado)
                                {
                                    string Disponible = emp.Disponible ? " Libre" : " Ocupado";
                                    Console.WriteLine($"{emp.Rol,-15}{emp.Nombre,-25}{Disponible}");
                                }
                            }

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();

                            break;
                        
                        case "7":

                            opcionMenu = Salir();
                            
                            break;
                        default:
                            Console.WriteLine("Seleccione una opcion valida.");
                            break;
                    }
}
                catch (Exception ex)
                {
                    Console.WriteLine("Error al mostrar el menu: " + ex.Message);
                }
            }
            while (!opcionMenu) ;
    }

        public bool Salir()
        {
            Console.WriteLine("Esta saliendo de sistema");
            Console.WriteLine("          (*_*)");
            Console.WriteLine("QUIERE EL DESPIDO INMEDIATO");
            Console.WriteLine("          (⌐■_■) ");
            Console.WriteLine("Si o no?");
            Console.WriteLine(" ");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                Console.WriteLine("Saliendo del sistema!");
                return true;
            }
            else { return false;
                Console.WriteLine("WWW del sistema!");
            }
        }





    }

}

