CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Cedula VARCHAR(20)
);

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    PrecioUnitario DECIMAL(10,2)
);

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50),
    Contrasena VARCHAR(100),
    Rol VARCHAR(50)
);

CREATE TABLE Facturas (
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    FormaPago VARCHAR(50)
);

CREATE TABLE DetallesFactura (
    IdDetalleFactura INT IDENTITY(1,1) PRIMARY KEY,
    IdFactura INT FOREIGN KEY REFERENCES Facturas(IdFactura),
    IdProducto INT FOREIGN KEY REFERENCES Productos(IdProducto),
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    PrecioTotal DECIMAL(10,2)
);