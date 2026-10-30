using System.Linq;
using CatalogoCursosShell.Services;

namespace CatalogoCursosShell.Views
{
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ActualizarMetricas();
        }

        private void ActualizarMetricas()
        {
            var cursos = CursoService.GetCursos();
            lblTotalCursos.Text = cursos.Count.ToString();
            lblTotalCreditos.Text = cursos.Sum(c => c.Creditos).ToString();
        }

        private async void OnIrACursosClicked(object? sender, EventArgs e)
        {
            // Navega a la pestaña de cursos registrada en el TabBar
            await Shell.Current.GoToAsync("//cursos");
        }
    }
}
