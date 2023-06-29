using System;

namespace EspacioTarea
{
    internal class Tarea
    {
        private static int idActual = 1;
        private int tareaId;
        private string descripcion;
        private int duracion;

        public Tarea(string descripcion, int duracion)
        {
            this.tareaId = idActual++;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }
        public int TareaId { get => tareaId; set => tareaId = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion
        {
            get => duracion;
            set
            {
                if (value < 10 && value < 100)
                {
                    duracion = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La duración debe estar entre 10 y 100.");
                }
            }
        }
    }
}