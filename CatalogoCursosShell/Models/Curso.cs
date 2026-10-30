namespace CatalogoCursosShell.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Docente { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Creditos { get; set; }

        // Constructor vacío para creación y enlace
        public Curso()
        {
        }

        public Curso(int id, string nombre, string docente, string descripcion, int creditos)
        {
            Id = id;
            Nombre = nombre;
            Docente = docente;
            Descripcion = descripcion;
            Creditos = creditos;
        }

        // Método auxiliar para clonar el objeto y evitar mutaciones directas antes de guardar
        public Curso Clonar()
        {
            return new Curso
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Docente = this.Docente,
                Descripcion = this.Descripcion,
                Creditos = this.Creditos
            };
        }
    }
}
