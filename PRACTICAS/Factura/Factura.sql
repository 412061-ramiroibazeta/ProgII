CREATE DATABASE Facturas
GO
USE Facturas
GO 

CREATE TABLE Forma_pago (
    id_forma_pago INT NOT NULL,
    forma_pago VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Forma_pago PRIMARY KEY (id_forma_pago)
);

CREATE TABLE Facturas (
    nro_factura INT NOT NULL,
    fecha DATE NOT NULL,
    id_forma_pago INT NOT NULL,
    id_cliente INT NOT NULL,
    CONSTRAINT PK_Facturas PRIMARY KEY (nro_factura),
    CONSTRAINT FK_Factura_FormaPago FOREIGN KEY (id_forma_pago) 
	REFERENCES Forma_pago(id_forma_pago)
);

CREATE TABLE Articulos (
    id_articulo INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PK_Articulos PRIMARY KEY (id_articulo)
);

CREATE TABLE Detalle_factura (
    id_detalle_factura INT NOT NULL,
    id_factura INT NOT NULL,
    id_articulo INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    CONSTRAINT PK_Detalle_factura PRIMARY KEY (id_detalle_factura),
    CONSTRAINT FK_Detalle_factura_Factura FOREIGN KEY (id_factura) 
	REFERENCES Facturas(nro_factura),
    CONSTRAINT FK_Detalle_factura_Articulo FOREIGN KEY (id_articulo) 
	REFERENCES Articulos(id_articulo)
);

INSERT INTO Forma_pago (id_forma_pago, forma_pago)
VALUES 
(1, 'Efectivo'),
(2, 'Tarjeta de Crédito'),
(3, 'Transferencia Bancaria');

INSERT INTO Factura (nro_factura, fecha, id_forma_pago, id_cliente)
VALUES 
(1001, '2024-08-01', 1, 201),
(1002, '2024-08-15', 2, 202);

INSERT INTO Articulos (id_articulo, nombre, precio_unitario)
VALUES 
(1, 'Laptop', 1200.00),
(2, 'Mouse', 25.50),
(3, 'Teclado', 45.75),
(4, 'Monitor', 300.00),
(5, 'Impresora', 150.00);

INSERT INTO Detalle_factura (id_detalle_factura, id_factura, id_articulo, precio, cantidad)
VALUES 
(1, 1001, 1, 1200.00, 1),
(2, 1001, 2, 25.50, 2),
(3, 1002, 4, 300.00, 1),
(4, 1002, 5, 150.00, 1);


--------------------------------------------- STORE PROCEDURES ---------------------------------------------------------
--FORMA DE PAGO
-- Obtener todos
CREATE PROCEDURE sp_get_all_forma_pago
AS
BEGIN
    SELECT * FROM Forma_pago;
END;

-- Nuevo registro
CREATE PROCEDURE sp_insert_forma_pago
    @id_forma_pago INT,
    @forma_pago VARCHAR(50)
AS
BEGIN
    INSERT INTO Forma_pago (id_forma_pago, forma_pago)
    VALUES (@id_forma_pago, @forma_pago);
END;

-- FACTURAS
-- Obtener todos
CREATE PROCEDURE sp_get_all_factura
AS
BEGIN
    SELECT * FROM Factura;
END;

-- Nuevo registro
CREATE PROCEDURE sp_insert_factura
    @nro_factura INT,
    @fecha DATE,
    @id_forma_pago INT,
    @id_cliente INT
AS
BEGIN
    INSERT INTO Factura (nro_factura, fecha, id_forma_pago, id_cliente)
    VALUES (@nro_factura, @fecha, @id_forma_pago, @id_cliente);
END;

-- ARTICULOS
-- Obtener todos

CREATE PROCEDURE sp_get_all_articulos
AS
BEGIN
    SELECT * FROM Articulos;
END;

-- Nuevo registro
CREATE PROCEDURE sp_insert_articulos
    @id_articulo INT,
    @nombre VARCHAR(100),
    @precio_unitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Articulos (id_articulo, nombre, precio_unitario)
    VALUES (@id_articulo, @nombre, @precio_unitario);
END;

-- DETALLE FACTURA
-- Obtener todos
CREATE PROCEDURE sp_get_all_detalle_factura
AS
BEGIN
    SELECT * FROM Detalle_factura;
END;

-- Nuevo registro
CREATE PROCEDURE sp_insert_detalle_factura
    @id_detalle_factura INT,
    @id_factura INT,
    @id_articulo INT,
    @precio DECIMAL(10, 2),
    @cantidad INT
AS
BEGIN
    INSERT INTO Detalle_factura (id_detalle_factura, id_factura, id_articulo, precio, cantidad)
    VALUES (@id_detalle_factura, @id_factura, @id_articulo, @precio, @cantidad);
END;

--

  
