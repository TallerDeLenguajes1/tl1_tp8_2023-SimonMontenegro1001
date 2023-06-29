using System;
using EspacioTarea;

namespace Punto1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tarea> tareasRealizadas = new List<Tarea>();
            List<Tarea> tareasPendientes = GenerarTareasAleatorias();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("----- Menú -----");
                Console.WriteLine("1. Mostar tareas pendientes.");
                Console.WriteLine("2. Mostar tareas realizadas.");
                Console.WriteLine("3. Marcar tarea como realizada");
                Console.WriteLine("4. Buscar tareas pendientes por descripción");
                Console.WriteLine("5. Salir");
                Console.WriteLine("");

                Console.Write("Ingrese una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ImprimirTareas(tareasPendientes);
                        break;
                    case "2":
                        ImprimirTareas(tareasRealizadas);
                        break;
                    case "3":
                        MarcarTareaRealizada(tareasPendientes, tareasRealizadas);
                        break;
                    case "4":
                        BuscarTareasPorDescripcion(tareasPendientes);
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }
        static void BuscarTareasPorDescripcion(List<Tarea> tareasPendientes)
        {
            Console.WriteLine("Ingrese la palabra clave de la tarea a buscar:");
            string palabraClave = Console.ReadLine();

            List<Tarea> tareasEncontradas = tareasPendientes.FindAll(t => t.Descripcion.Contains(palabraClave));

            if (tareasEncontradas.Count > 0)
            {
                Console.WriteLine("Tareas encontradas:");
                ImprimirTareas(tareasEncontradas);
            }
            else
            {
                Console.WriteLine("No se encontraron tareas con la palabra clave especificada.");
            }
        }

        static void MarcarTareaRealizada(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas)
        {
            Console.WriteLine("Ingrese el ID de la tarea que desea marcar como realizada:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int tareaId))
            {
                Tarea tareaEncontrada = tareasPendientes.Find(t => t.TareaId == tareaId);

                if (tareaEncontrada != null)
                {
                    tareasRealizadas.Add(tareaEncontrada);
                    tareasPendientes.RemoveAll(t => t.TareaId == tareaId);
                    Console.WriteLine("Tarea marcada como realizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna tarea con el ID especificado.");
                }
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un ID de tarea válido.");
            }
        }

        static List<Tarea> GenerarTareasAleatorias()
        {
            List<Tarea> tareas = new List<Tarea>();
            Random rand = new Random();

            int cantidadTareas = rand.Next(1, 10);

            for (int i = 0; i < cantidadTareas; i++)
            {
                string descripcion = "Descripción de la tarea " + (i + 1);
                int duracion = rand.Next(10, 100);
                Tarea tarea = new Tarea(descripcion, duracion);
                tareas.Add(tarea);
            }

            return tareas;
        }

        static void ImprimirTareas(List<Tarea> tareas)
        {
            foreach (Tarea tarea in tareas)
            {
                Console.WriteLine("Tarea " + tarea.TareaId + ", Descripción: " + tarea.Descripcion + ", Duración: " + tarea.Duracion);
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}