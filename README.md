# Sistema de Gestión Escolar

Sistema de gestión escolar desarrollado en C# y MySQL como proyecto de aprendizaje para practicar Programación Orientada a Objetos, acceso a bases de datos y consultas SQL.

## Funcionalidades

### Gestión de estudiantes

* Crear estudiantes
* Listar estudiantes
* Buscar estudiante por ID
* Actualizar estudiantes
* Eliminar estudiantes

### Gestión de cursos

* Crear cursos
* Listar cursos
* Buscar cursos
* Actualizar cursos
* Eliminar cursos

### Gestión de maestros

* Crear maestros
* Listar maestros
* Buscar maestros
* Actualizar maestros
* Eliminar maestros

### Gestión de materias

* Asignar materias a cursos y maestros
* Consultar materias
* Actualizar materias
* Eliminar materias

### Reportes

* Estudiantes por curso
* Materias por curso
* Maestros y materias asignadas

## Tecnologías utilizadas

* C#
* .NET
* MySQL
* MySql.Data
* Visual Studio

## Conceptos aplicados

* Programación Orientada a Objetos (POO)
* CRUD
* Arquitectura por capas
* Relaciones entre tablas
* Llaves primarias y foráneas
* SQL JOIN
* Listas y colecciones
* Manejo de excepciones
* Menús interactivos en consola

## Estructura del proyecto

```text
CrudEstudiantes
│
├── Models
├── Data
├── Menus
├── Helpers
└── Program.cs
```

## Base de datos

El proyecto utiliza las siguientes tablas:

* estudiantes
* cursos
* maestro
* materias

Relaciones:

* Un estudiante pertenece a un curso.
* Una materia pertenece a un curso.
* Una materia es impartida por un maestro.

## Cómo ejecutar el proyecto

1. Clonar el repositorio.
2. Crear la base de datos MySQL.
3. Ejecutar los scripts SQL incluidos.
4. Configurar la cadena de conexión en `ConexionDB.cs`.
5. Ejecutar el proyecto desde Visual Studio.

## Objetivo del proyecto

Este proyecto fue desarrollado como práctica para fortalecer conocimientos en C#, SQL y diseño de aplicaciones de consola conectadas a bases de datos relacionales.

## Mejoras futuras

* Validaciones avanzadas.
* Exportación de reportes.
* Interfaz gráfica con Windows Forms.
* Versión web con ASP.NET Core.
* Sistema de autenticación y roles.
