using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Trabajo_Individual.Models;

namespace Trabajo_Individual.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string mensaje = string.Empty;

    [ObservableProperty] private bool tarea_completada = false;
    public string Greeting { get; } = "FORMULARIO DE TAREAS";
    [ObservableProperty] private Tarea tarea = new ();
    public ObservableCollection<string> ListarCategorias { get; set; } = new()
    {
        "Estudio", "Casa", "Trabajo"
    };

    public void MostrarOpcionesAvanzadas()
    {
        if (tarea_completada)
        {
            tarea_completada = false;
        }
    }

    public void MostrarTarea(object parameter)
    {
        CheckBox check = (CheckBox)parameter;
        if (check.IsChecked is false)
        {

            Mensaje = "Debes marcar el check";
            Console.WriteLine("Debes marcar el check");
            check.Foreground = Brushes.DarkRed;
            check.FontWeight = FontWeight.Bold;
            return;
        }
    }
    

}