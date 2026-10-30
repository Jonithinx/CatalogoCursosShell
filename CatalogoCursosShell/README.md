# Presentación 4 – Navegación con Shell (.NET MAUI)

Aplicación móvil desarrollada en .NET MAUI y C# para la gestión de un catálogo de cursos académicos, implementando la arquitectura de navegación completa basada en Shell.

---

## 📋 Información del Estudiante

- **Nombre:** Jonathan Dubon
- **Número de Cuenta:** 323590009
- **Correo Institucional:** 323590009@est.ucenm.edu.hn
- **Universidad:** UCENM (Universidad Cristiana Evangélica Nuevo Milenio)
- **Carrera:** Ingeniería en Sistemas
- **Asignatura:** Programación Móvil II

---

## 📖 Descripción del Proyecto

Esta aplicación implementa las especificaciones de navegación con Shell en .NET MAUI:

1. **Menú Lateral (Flyout):**
   - Habilitado con `FlyoutBehavior="Flyout"`.
   - Encabezado institucional personalizado (`FlyoutHeader`).
   - Opción `Acerca de` (`AcercaPage`) mediante `FlyoutItem`.
   - Opción `Salir` mediante `MenuItem` para cerrar la aplicación con `Application.Current.Quit()`.

2. **Barra de Pestañas (TabBar):**
   - **Inicio (`//inicio`):** Pantalla principal con estadísticas y accesos directos.
   - **Cursos (`//cursos`):** Catálogo de cursos con `CollectionView` en tarjetas interactivas.
   - **Perfil (`//perfil`):** Información del estudiante y matrícula.

3. **Paso de Parámetros y Navegación Jerárquica:**
   - **Query String:** Desde `CursosPage` hacia `DetalleCursoPage` pasando el ID numérico (`?id={curso.Id}`) y recibido con `[QueryProperty(nameof(CursoId), "id")]`.
   - **Diccionario / `IQueryAttributable`:** Desde `DetalleCursoPage` hacia `EditarCursoPage` pasando el objeto completo `Curso` a través de `Dictionary<string, object>` y procesado en `ApplyQueryAttributes`.
   - **Navegación Relativa:** Regreso automático tras guardar o cancelar con `await Shell.Current.GoToAsync("..");` y recarga automática de datos en `OnAppearing()`.

4. **Persistencia en Memoria:**
   - Servicio singleton `CursoService` con operaciones `GetCursos()`, `GetCursoById(int id)` y `ActualizarCurso(Curso curso)`.

---

## 🗺️ Mapa de Rutas Shell

| Tipo de Ruta | Ruta / Nombre | Destino | Parámetros |
| :--- | :--- | :--- | :--- |
| **Pestaña TabBar** | `//inicio` | `InicioPage` | N/A |
| **Pestaña TabBar** | `//cursos` | `CursosPage` | N/A |
| **Pestaña TabBar** | `//perfil` | `PerfilPage` | N/A |
| **Flyout Item** | `//acerca` | `AcercaPage` | N/A |
| **Flyout Menu** | `Salir` | Cierra App | N/A |
| **Ruta Registrada** | `DetalleCursoPage` | `DetalleCursoPage` | Query String (`?id={id}`) |
| **Ruta Registrada** | `EditarCursoPage` | `EditarCursoPage` | Diccionario (`Dictionary<string, object>`) |
| **Retorno Relativo** | `..` | Vista anterior | N/A |
