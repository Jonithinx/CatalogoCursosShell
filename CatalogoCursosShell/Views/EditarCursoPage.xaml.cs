using System;
using System.Collections.Generic;
using CatalogoCursosShell.Models;
using CatalogoCursosShell.Services;

namespace CatalogoCursosShell.Views
{
    public partial class EditarCursoPage : ContentPage, IQueryAttributable
    {
        private Curso? _cursoRecibido;

        public EditarCursoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Implementación de IQueryAttributable para recibir el objeto completo pasado mediante diccionario
        /// </summary>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Curso", out var cursoObj) && cursoObj is Curso curso)
            {
                _cursoRecibido = curso;
                lblIdCurso.Text = $"ID: #{_cursoRecibido.Id}";
                txtNombre.Text = _cursoRecibido.Nombre;
                txtDocente.Text = _cursoRecibido.Docente;
                txtCreditos.Text = _cursoRecibido.Creditos.ToString();
                txtDescripcion.Text = _cursoRecibido.Descripcion;
            }
        }

        private async void OnGuardarClicked(object? sender, EventArgs e)
        {
            if (_cursoRecibido == null)
            {
                await DisplayAlertAsync("Error", "No se encontró la referencia del curso a editar.", "Aceptar");
                return;
            }

            // Validaciones de formulario
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                await DisplayAlertAsync("Validación", "El nombre de la asignatura es requerido.", "Aceptar");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocente.Text))
            {
                await DisplayAlertAsync("Validación", "El nombre del docente es requerido.", "Aceptar");
                txtDocente.Focus();
                return;
            }

            if (!int.TryParse(txtCreditos.Text?.Trim(), out int creditos) || creditos <= 0)
            {
                await DisplayAlertAsync("Validación", "Ingrese un número válido de créditos (mayor a 0).", "Aceptar");
                txtCreditos.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                await DisplayAlertAsync("Validación", "La descripción del curso no puede estar vacía.", "Aceptar");
                txtDescripcion.Focus();
                return;
            }

            // Actualizar el modelo con los valores del formulario
            _cursoRecibido.Nombre = txtNombre.Text.Trim();
            _cursoRecibido.Docente = txtDocente.Text.Trim();
            _cursoRecibido.Creditos = creditos;
            _cursoRecibido.Descripcion = txtDescripcion.Text.Trim();

            // Guardar en el servicio en memoria
            CursoService.ActualizarCurso(_cursoRecibido);

            await DisplayAlertAsync("Éxito", "El curso se ha actualizado correctamente.", "Aceptar");

            // Navegación relativa para regresar a la página anterior en el stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelarClicked(object? sender, EventArgs e)
        {
            // Regresar sin guardar cambios mediante navegación relativa
            await Shell.Current.GoToAsync("..");
        }
    }
}
