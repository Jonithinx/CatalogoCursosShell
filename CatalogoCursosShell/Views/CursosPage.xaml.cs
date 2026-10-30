using System;
using System.Collections.Generic;
using CatalogoCursosShell.Models;
using CatalogoCursosShell.Services;

namespace CatalogoCursosShell.Views
{
    public partial class CursosPage : ContentPage
    {
        public CursosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarCursos();
        }

        private void CargarCursos()
        {
            var cursos = CursoService.GetCursos();
            cvCursos.ItemsSource = cursos;
            lblContador.Text = $"{cursos.Count} cursos disponibles en el catálogo";
            cvCursos.SelectedItem = null; // Reiniciar selección para permitir volver a tocar el mismo
        }

        private async void OnCursoSelected(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Curso curso)
            {
                // Limpiar selección para evitar estados residuales
                cvCursos.SelectedItem = null;
                await NavegarADetalle(curso);
            }
        }

        private async void OnVerDetalleClicked(object? sender, EventArgs e)
        {
            if (sender is Button boton && boton.CommandParameter is Curso curso)
            {
                await NavegarADetalle(curso);
            }
        }

        private async Task NavegarADetalle(Curso curso)
        {
            // Navegación enviando parámetro por Query String
            await Shell.Current.GoToAsync($"{nameof(DetalleCursoPage)}?id={curso.Id}");
        }
    }
}
