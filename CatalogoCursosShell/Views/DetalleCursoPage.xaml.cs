using System.Collections.Generic;
using CatalogoCursosShell.Models;
using CatalogoCursosShell.Services;

namespace CatalogoCursosShell.Views
{
    [QueryProperty(nameof(CursoId), "id")]
    public partial class DetalleCursoPage : ContentPage
    {
        private int _cursoId;
        private Curso? cursoActual;

        public string CursoId
        {
            get => _cursoId.ToString();
            set
            {
                if (int.TryParse(value, out int id))
                {
                    _cursoId = id;
                    CargarCurso(_cursoId);
                }
            }
        }

        public DetalleCursoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Refrescar los datos del curso al volver de la pantalla de edición
            if (_cursoId > 0)
            {
                CargarCurso(_cursoId);
            }
        }

        private void CargarCurso(int id)
        {
            cursoActual = CursoService.GetCursoById(id);

            if (cursoActual != null)
            {
                lblBadgeId.Text = $"ID: #{cursoActual.Id}";
                lblBadgeCreditos.Text = $"{cursoActual.Creditos} Créditos";
                lblNombreCurso.Text = cursoActual.Nombre;
                lblDocente.Text = cursoActual.Docente;
                lblDescripcion.Text = cursoActual.Descripcion;
            }
            else
            {
                lblNombreCurso.Text = "Curso no encontrado";
                lblDocente.Text = "N/A";
                lblDescripcion.Text = "El curso solicitado no se encuentra en el catálogo.";
            }
        }

        private async void OnEditarCursoClicked(object? sender, EventArgs e)
        {
            if (cursoActual == null)
            {
                await DisplayAlertAsync("Atención", "No se puede editar porque el curso no existe.", "Aceptar");
                return;
            }

            // Paso del objeto completo mediante diccionario
            var parametros = new Dictionary<string, object>
            {
                { "Curso", cursoActual }
            };

            await Shell.Current.GoToAsync(nameof(EditarCursoPage), parametros);
        }

        private async void OnVolverClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
