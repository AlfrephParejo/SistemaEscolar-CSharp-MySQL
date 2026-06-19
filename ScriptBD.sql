-- ==========================================
-- CREACIÓN DE BASE DE DATOS
-- ==========================================
CREATE DATABASE colegio;
USE colegio;


-- ==========================================
-- TABLA CURSOS
-- ==========================================
CREATE TABLE cursos(
Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL
);

-- ==========================================
-- TABLA ESTUDIANTES
-- ==========================================
CREATE TABLE estudiantes (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Edad` int NOT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  `fecha_registro` datetime DEFAULT CURRENT_TIMESTAMP,
  `CursoId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `FK_Estudiante_Curso` (`CursoId`),
  CONSTRAINT `FK_Estudiante_Curso` FOREIGN KEY (`CursoId`) REFERENCES `cursos` (`Id`)
  );

-- ==========================================
-- TABLA MAESTRO
-- ==========================================
CREATE TABLE maestro (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Asignatura` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ==========================================
-- TABLA MATERIAS
-- ==========================================
CREATE TABLE materias (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `CursoId` int NOT NULL,
  `MaestroId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `CursoId` (`CursoId`),
  KEY `MaestroId` (`MaestroId`),
  CONSTRAINT `materias_ibfk_1` FOREIGN KEY (`CursoId`) REFERENCES `cursos` (`Id`),
  CONSTRAINT `materias_ibfk_2` FOREIGN KEY (`MaestroId`) REFERENCES `maestro` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




-- ==========================================
-- DATOS INICIALES EN TABLA CURSO
-- ==========================================
INSERT INTO cursos (Nombre) VALUES('6°'), ('7°'), ('8°'), ('9°'), ('10°'), ('11°'); 



-- ==========================================
-- DATOS INICIALES EN TABLA ESTUDIANTES
-- ==========================================
INSERT INTO estudiantes (Nombre, Apellido, Edad, Correo)
VALUES('Juan', 'Perez', 18, 'juan@gmail.com'),
 ('Maria', 'Gomez', 18, 'maria@gmail.com'),
  ('Pedro', 'Martinez', 17, 'pmartinez@gmail.com'),
   ('Estefani', 'De La Hoz', 16, 'steffy@gmail.com'),
    ('Victor', 'Bohorquez', 18, 'victorb@gmail.com'),
     ('Deisy', 'Palencia', 18, 'pastelita@gmail.com'),
      ('Angelica', 'Bautista', 19, 'abautista@gmail.com'),
       ('Felicia', 'Menco', 18, 'menco231@gmail.com'),
        ('Patricia', 'Fernandez', 18, 'Pato@gmail.com'),
         ('Jose', 'Consuegra', 18, 'jconsuegra@gmail.com');



-- ==========================================
-- DATOS INICIALES EN TABLA MAESTRO
-- ==========================================
INSERT INTO Maestro (Nombre, Apellido, Asignatura, correo) values ('Jose', 'Certein', 'Biologia', 'jose@colegio.com'),
('Alfredo', 'Parejo', 'Informatica', 'alfredo@colegio.com'),
('Martha', 'Gonzalez', 'Matematicas', 'martha@colegio.com'),
('Eduardo', 'Camacho', 'Deportes', 'eduardo@colegio.com'),
('Ruben', 'Herrera', 'Musica', 'ruben@colegio.com'),
('Luis', 'Ramirez', 'Historia', 'luis@colegio.com');



-- ==========================================
-- DATOS INICIALES EN TABLA MATERIAS
-- ==========================================
INSERT INTO materias (Nombre, CursoId, MaestroId)
VALUES
('Ciencias', 1, 1),
('Biología', 5, 1),
('Biología', 6, 1),

('Informática', 5, 2),
('Informática', 6, 2),

('Matemáticas', 5, 3),
('Matemáticas', 6, 3),

('Deportes', 5, 4),
('Deportes', 6, 4),

('Música', 5, 5),
('Música', 6, 5),

('Historia', 5, 6),
('Historia', 6, 6);