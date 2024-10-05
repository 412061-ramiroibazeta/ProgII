CREATE DATABASE TiendaElectronica;
GO

USE TiendaElectronica;
GO

CREATE TABLE Categoria (
    CategoriaId INT IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Categoria PRIMARY KEY (CategoriaId) 
);
GO

CREATE TABLE Producto (
    ProductoId INT IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    CategoriaId INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    FechaDeIngreso DATE NOT NULL, 
    CONSTRAINT PK_Producto PRIMARY KEY (ProductoId), 
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaId) REFERENCES Categoria(CategoriaId) 
);
GO

--1) Todos los productos
--2) Todos los productos entre precios a y b
--3) Producto por nombre
--4) Producto por categoría 
--5) Productos que hayan ingresado a partir de una fecha
--6) Al ingresar un producto se debe validar que todos los datos estén correctos y la fecha de ingreso al día que se hizo la operación.
--7) Al actualizar el stock, se debe actualizar la fecha de ingreso al día que se hizo la operación.
--8) 