using System;
using CatalogoCursosShell.Views;
using Microsoft.Maui.Controls;

namespace CatalogoCursosShell
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rutas detalladas para navegación con GoToAsync
            Routing.RegisterRoute(nameof(DetalleCursoPage), typeof(DetalleCursoPage));
            Routing.RegisterRoute(nameof(EditarCursoPage), typeof(EditarCursoPage));
        }

        private void OnSalirClicked(object? sender, EventArgs e)
        {
            // Cierra la aplicación respetando el ciclo de vida de MAUI
            Application.Current?.Quit();
        }
    }
}
