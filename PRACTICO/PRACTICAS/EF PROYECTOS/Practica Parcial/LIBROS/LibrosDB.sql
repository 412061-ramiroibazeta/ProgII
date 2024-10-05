CREATE DATABASE Biblioteca;
GO

USE Biblioteca;
GO

CREATE TABLE Categoria (
    CategoriaId INT,
    Nombre VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Categoria PRIMARY KEY (CategoriaId)
);
GO

CREATE TABLE Libro (
    LibroId INT IDENTITY(1,1),
    Titulo VARCHAR(100) NOT NULL,
    Autor VARCHAR(100) NOT NULL,
    CategoriaId INT NOT NULL, 
    FechaPublicacion DATE NOT NULL,
    Disponible BIT NOT NULL, 
    CONSTRAINT PK_Libro PRIMARY KEY (LibroId),
    CONSTRAINT FK_Libro_Categoria FOREIGN KEY (CategoriaId) 
	REFERENCES Categoria(CategoriaId)
);

------

INSERT INTO Categoria (CategoriaId, Nombre)
VALUES (1, 'Ficción');

INSERT INTO Categoria (CategoriaId, Nombre)
VALUES (2, 'Ciencia');

INSERT INTO Categoria (CategoriaId, Nombre)
VALUES (3, 'Historia');

INSERT INTO Libro (Titulo, Autor, CategoriaId, FechaPublicacion, Disponible)
VALUES ('Cien años de soledad', 'Gabriel García Márquez', 1, '30-05-1967', 1);

INSERT INTO Libro (Titulo, Autor, CategoriaId, FechaPublicacion, Disponible)
VALUES ('El origen de las especies', 'Charles Darwin', 2, '24-11-1859', 1);

INSERT INTO Libro (Titulo, Autor, CategoriaId, FechaPublicacion, Disponible)
VALUES ('Sapiens', 'Yuval Noah Harari', 3, '04-09-2011', 1);


--1) Todos los libros disponibles
--2) Validar campos obligatorios al insertar un libro, debe estar disponible al insertarse
--3) Consultar libros por autor 
--4) Consultar libros por categoría
--5) Consultar libros por fecha de publicación
--6) Al editar un libro se debe sacar de disponibilidad



