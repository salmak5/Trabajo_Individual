using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Trabajo_Individual.Models;

namespace Trabajo_Individual.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string mensaje = string.Empty;
        [ObservableProperty] private Tarea tarea = new();
        [ObservableProperty] private bool aceptarCondiciones;

        [ObservableProperty] private bool modoEditar = false;
        [ObservableProperty] private bool modoCrear = true;
        public string Greeting { get; } = "FORMULARIO DE TAREAS";

        public ObservableCollection<Tarea> Tareas { get; } = new ObservableCollection<Tarea>();

        [ObservableProperty] private Tarea tareaSeleccionada = new();

        public ObservableCollection<string> ListarCategorias { get; } = new ObservableCollection<string>
        {
            "Estudio", "Casa", "Trabajo"
        };

        public MainWindowViewModel()
        {

            CargarTreas();
        }

        private void CargarTreas()
        {
            Tarea tarea = new Tarea();
            tarea.Categoria = "estudio";
            tarea.Descripcion = "Proyecto";
            tarea.FechaLimite = DateTime.Now;
            Tareas.Add(tarea);

            Tarea tarea2 = new Tarea();
            tarea2.Categoria = "casa";
            tarea2.Descripcion = "compras";
            tarea.FechaLimite = DateTime.Now;
            Tareas.Add(tarea2);

            Tarea tarea3 = new Tarea();
            tarea3.Categoria = "trabajo";
            tarea3.Descripcion = "enviar email";
            tarea.FechaLimite = DateTime.Now;
            Tareas.Add(tarea3);
        }

        [RelayCommand]
        public void ComprobarFechaLimite()
        {
            CheckDate();
        }

        private bool CheckDate()
        {
            if (Tarea.FechaLimite < DateTime.Today)
            {
                Mensaje = "La fecha no puede ser inferior a hoy";
                return false;
            }
            else
            {
                Mensaje = "";
                return true;
            }
        }

        [RelayCommand]
        public void CargarTareaSeleccionada()
        {
            Tarea = TareaSeleccionada;
            ModoCrear = false;
            ModoEditar = false;
        }

        [RelayCommand]
        public void MostrarTarea(object parameter)
        {
            bool okCheckFecha = CheckDate();

            if (okCheckFecha == false)
            {
                return;
            }

            if (!CheckDate())
            {
                return;
            }

            CheckBox check = (CheckBox)parameter;

            if (check.IsChecked is false)
            {
                Mensaje = "Debes marcar el check";
                Console.WriteLine("Debes marcar el check");
                check.Foreground = Brushes.Red;
                check.FontWeight = FontWeight.Bold;
                return;
            }

            if (string.IsNullOrWhiteSpace(Tarea.Descripcion))
            {
                Mensaje = "Debes indicar su descripcion";
                Console.WriteLine("Debes indicar una descripcion");
            }
            else
            {
                // SE CREA LA TAREA
                Console.WriteLine(Tarea.Categoria + " " + Tarea.Descripcion);
                Mensaje = String.Empty;
                Tareas.Add(tarea);
                Tarea = new Tarea();
                check.IsChecked = false;
            }

        }


    }
}