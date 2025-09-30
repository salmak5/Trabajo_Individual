using System;

namespace Trabajo_Individual.Models
{
    public class Tarea
    {
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaLimite { get; set; }
        public int Prioridad { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"Categoría: {Categoria}, Descripción: {Descripcion}, Fecha límite: {FechaLimite:dd/MM/yyyy}, Prioridad: {Prioridad}, Completada: {(Completada ? "Sí" : "No")}";
        }
    }
}



