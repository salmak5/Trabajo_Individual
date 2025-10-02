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
        [ObservableProperty] private bool avanzadas = false;

        [ObservableProperty] private bool modoEditar = true;
        [ObservableProperty] private bool modoCrear = false;
        public string Greeting { get; } = "FORMULARIO DE TAREAS";

        public ObservableCollection<Tarea> Tareas { get; } = new();

        [ObservableProperty] private Tarea tareaSeleccionada = new();

        public ObservableCollection<string> ListarCategorias { get; } = new ObservableCollection<string>
        {
            "Estudio", "Casa", "Trabajo"
        };

        public MainWindowViewModel()
        {

            CargarTareas();
        }

        private void CargarTareas()
        {
            Tarea tarea = new Tarea();
            tarea.Categoria = "estudio";
            tarea.Descripcion = "Proyecto";
            tarea.FechaLimite = DateTime.Now;
            Tareas.Add(tarea);

            Tarea tarea2 = new Tarea();
            tarea2.Categoria = "casa";
            tarea2.Descripcion = "compras";
            tarea2.FechaLimite = DateTime.Now;
            Tareas.Add(tarea2);

            Tarea tarea3 = new Tarea();
            tarea3.Categoria = "trabajo";
            tarea3.Descripcion = "enviar email";
            tarea3.FechaLimite = DateTime.Now;
            Tareas.Add(tarea3);
        }
        [RelayCommand]
        public void Cancelar()
        {
            Tarea = new Tarea();
            ModoCrear = true;
            ModoEditar = false;
        }

        public void MostrarOpcionesAvanzadas()
        {
            if (Avanzadas)
            {
                Avanzadas = false;
            }
            else
            {
                Avanzadas = true;
            }

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
        public void EditarTarea()
        {
            if (TareaSeleccionada == null)
            {
                Mensaje = "Debes seleccionar una tarea para editar";
                return;
            }

            // Validaciones
            if (string.IsNullOrWhiteSpace(Tarea.Descripcion))
            {
                Mensaje = "Debes escribir una descripción";
                return;
            }

            if (string.IsNullOrWhiteSpace(Tarea.Categoria))
            {
                Mensaje = "Debes seleccionar una categoría";
                return;
            }

            if (!CheckDate()) return;

            // Actualizar la tarea en la colección
            TareaSeleccionada.Descripcion = Tarea.Descripcion;
            TareaSeleccionada.Categoria = Tarea.Categoria;
            TareaSeleccionada.FechaLimite = Tarea.FechaLimite;
            TareaSeleccionada.Completada = Tarea.Completada;
            TareaSeleccionada.Prioridad = Tarea.Prioridad;

            // Limpiar formulario
            Cancelar();
        }


        [RelayCommand]
        public void MostrarTarea()
        {
           
           

            if (string.IsNullOrWhiteSpace(Tarea.Descripcion))
            {
                Mensaje = "Debes escribir una descripción";
                return;
            }
            if(!CheckDate()) return;

            var nuevaTarea = new Tarea
            {
                Descripcion = Tarea.Descripcion,
                Categoria = Tarea.Categoria,
                FechaLimite = Tarea.FechaLimite,
                Completada = Tarea.Completada,
                Prioridad = Tarea.Prioridad
            };

            Tareas.Add(nuevaTarea);


        }
    }
}