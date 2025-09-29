using System;
using System.Security;

namespace Trabajo_Individual.Models;

public class Tarea
{
    public string Trabajo { get; set; }
    public bool Completada { get; set; }
    public DateTime FechaLimite { get; set; }
    public int Prioridad { get; set; }
    public string Categoria { get; set; }


}