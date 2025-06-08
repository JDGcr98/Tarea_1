using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tarea_1.Enums
{
    internal class validar
    {      
            public static string LeerSoloTexto(string mensaje)
            {
                string entrada;
                do
                {
                    Console.Write(mensaje);
                    entrada = Console.ReadLine();
                    if (!Regex.IsMatch(entrada, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                        Console.WriteLine("Solo se permiten letras y espacios.");
                } while (!Regex.IsMatch(entrada, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"));

                return entrada;
            }

            public static string LeerTextoYNumeros(string mensaje)
            {
                string entrada;
                do
                {
                    Console.Write(mensaje);
                    entrada = Console.ReadLine();
                    if (!Regex.IsMatch(entrada, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$"))
                        Console.WriteLine("Solo se permiten letras, números y espacios.");
                } while (!Regex.IsMatch(entrada, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$"));

                return entrada;
            }
        }
    

}
