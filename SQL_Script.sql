-- DROP SCHEMA dbo;

--CREATE SCHEMA dbo;
-- prueba_bg.dbo.Cliente definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.Cliente;

CREATE TABLE prueba_bg.dbo.Cliente (
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	apellido varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	correo nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	cedula varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY (id)
);


-- prueba_bg.dbo.DetalleFactura definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.DetalleFactura;

CREATE TABLE prueba_bg.dbo.DetalleFactura (
	id int IDENTITY(1,1) NOT NULL,
	id_factura int NOT NULL,
	id_producto int NOT NULL,
	cantidad int NOT NULL,
	precio_unitario decimal(10,2) NOT NULL,
	precio_total decimal(10,2) NOT NULL,
	CONSTRAINT PK_DetalleFactura PRIMARY KEY (id)
);


-- prueba_bg.dbo.Factura definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.Factura;

CREATE TABLE prueba_bg.dbo.Factura (
	id int IDENTITY(1,1) NOT NULL,
	id_cliente int NOT NULL,
	id_usuario int NOT NULL,
	fecha datetime NOT NULL,
	forma_de_pago varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Factura PRIMARY KEY (id)
);


-- prueba_bg.dbo.Productos definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.Productos;

CREATE TABLE prueba_bg.dbo.Productos (
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	precio_unitario decimal(10,2) NOT NULL,
	CONSTRAINT PK_Productos PRIMARY KEY (id)
);


-- prueba_bg.dbo.Usuario definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.Usuario;

CREATE TABLE prueba_bg.dbo.Usuario (
	id int IDENTITY(1,1) NOT NULL,
	username varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	password varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	rol varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (id)
);


-- prueba_bg.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE prueba_bg.dbo.[__EFMigrationsHistory];

CREATE TABLE prueba_bg.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


