using System;
using System.IO;

namespace Punto2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el path de la carpeta:");
            string directorio = Console.ReadLine();// C:\Users\simon\program\c#NET\tp8\tl1_tp8_2023-SimonMontenegro1001
            //string directorio = @"C:\Users\simon\program\c#NET\tp8\tl1_tp8_2023-SimonMontenegro1001";
            string csv = "index.csv";
            if (Directory.Exists(directorio))
            {
                //DirectoryInfo[] archivos = new DirectoryInfo(directorio).GetDirectories(); //directorios

                //IEnumerable<string> archivos = Directory.EnumerateFiles(directorio, "*", SearchOption.AllDirectories);//todos archivos
                string[] archivos = Directory.GetFiles(directorio); // solo los hijos
                using (StreamWriter sw = new StreamWriter(csv))
                {
                    sw.WriteLine("Índice-Nombre-Extensión");
                    for (int i = 0; i < archivos.Length; i++)
                    {
                        string nombreArchivo = Path.GetFileName(archivos[i]);
                        string extensionArchivo = Path.GetExtension(archivos[i]);
                        sw.WriteLine($"{i + 1}-{nombreArchivo}-{extensionArchivo}");
                    }
                }
                Console.WriteLine("Listado de archivos guardado en index.csv.");
            }
            else
            {
                Console.WriteLine("El directorio especificado no existe.");
            }
        }
    }
}