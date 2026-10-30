using System.Collections.Generic;
using System.Linq;
using CatalogoCursosShell.Models;

namespace CatalogoCursosShell.Services
{
    public class CursoService
    {
        // Lista en memoria con cursos iniciales
        private static readonly List<Curso> _cursos = new()
        {
            new Curso(
                1,
                "Programación Móvil II",
                "Ing. Carlos Menjívar",
                "Desarrollo avanzado de aplicaciones multiplataforma con .NET MAUI, arquitectura MVVM, consumo de APIs REST y navegación mediante Shell.",
                4
            ),
            new Curso(
                2,
                "Base de Datos Avanzadas",
                "Dra. Elena Morales",
                "Modelado de datos complejo, optimización de consultas en SQL Server, transacciones ACID, índices avanzados e introducción a bases de datos NoSQL.",
                4
            ),
            new Curso(
                3,
                "Redes y Telecomunicaciones",
                "Ing. Roberto Sánchez",
                "Configuración de topologías de red, protocolos de enrutamiento TCP/IP, VLANs, subnetting IPv4/IPv6 y principios de seguridad perimetral.",
                3
            ),
            new Curso(
                4,
                "Inteligencia Artificial Aplicada",
                "Dr. Alejandro Ramos",
                "Fundamentos de Machine Learning, redes neuronales profundas con Python, visión por computadora y aplicaciones de modelos de lenguaje.",
                4
            ),
            new Curso(
                5,
                "Seguridad Informática y Criptografía",
                "MSc. Sofía Carranza",
                "Técnicas de pentesting ético, análisis de vulnerabilidades, algoritmos criptográficos simétricos/asimétricos y normativas de ciberseguridad.",
                3
            ),
            new Curso(
                6,
                "Ingeniería de Software y DevOps",
                "Ing. Fernando Castillo",
                "Metodologías ágiles Scrum, integración y despliegue continuo (CI/CD) con GitHub Actions, Docker containers y control de calidad de software.",
                4
            )
        };

        /// <summary>
        /// Obtiene la lista completa de cursos registrados.
        /// Retorna una copia de cada curso para aislar modificaciones.
        /// </summary>
        public static List<Curso> GetCursos()
        {
            return _cursos.Select(c => c.Clonar()).ToList();
        }

        /// <summary>
        /// Obtiene un curso por su identificador único.
        /// </summary>
        public static Curso? GetCursoById(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);
            return curso?.Clonar();
        }

        /// <summary>
        /// Actualiza los datos de un curso existente en la lista en memoria.
        /// </summary>
        public static bool ActualizarCurso(Curso curso)
        {
            if (curso == null) return false;

            var index = _cursos.FindIndex(c => c.Id == curso.Id);
            if (index != -1)
            {
                _cursos[index].Nombre = curso.Nombre;
                _cursos[index].Docente = curso.Docente;
                _cursos[index].Descripcion = curso.Descripcion;
                _cursos[index].Creditos = curso.Creditos;
                return true;
            }

            return false;
        }
    }
}
