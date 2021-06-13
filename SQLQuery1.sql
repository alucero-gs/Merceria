--Scripts de la base de datos en Mysql server

--Tablas

CREATE TABLE [dbo].[Categorias]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(30) NOT NULL, 
    [Descripcion] TEXT NOT NULL, 
    [Estado] INT NOT NULL 
)

CREATE TABLE [dbo].[Subcategorias]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Categoria] INT NOT NULL, 
    [Nombre] NCHAR(30) NOT NULL, 
    [Descripcion] TEXT NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_Categorias FOREIGN KEY (Id_Categoria) REFERENCES Categorias (Id),
)


CREATE TABLE [dbo].[TipoUsuario]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(30) NOT NULL, 
    [Descripcion] TEXT NOT NULL, 
    [Estado] INT NOT NULL
)

CREATE TABLE [dbo].[Productos]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Subcategoria] INT NOT NULL, 
    [Nombre] NCHAR(50) NOT NULL, 
    [Descripcion] TEXT NOT NULL, 
    [Precio_Compra] MONEY NOT NULL, 
    [Precio_Venta] MONEY NOT NULL, 
    [Existencia] INT NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_Subcategorias FOREIGN KEY (Id_Subcategoria) REFERENCES Subcategorias (Id),
)

CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(30) NULL, 
    [Apellido_Paterno] NCHAR(30) NULL, 
    [Apellido_Materno] NCHAR(30) NOT NULL, 
    [Fecha_Nacimiento] DATE NOT NULL, 
    [Telefono] NCHAR(10) NOT NULL, 
    [Correo] NCHAR(50) NOT NULL, 
    [Id_TipoUsuario] INT NOT NULL, 
    [Username] NCHAR(50) NOT NULL, 
    [Password] TEXT NOT NULL, 
    [Estado] NCHAR(10) NOT NULL ,
	CONSTRAINT fk_TipoUsuario FOREIGN KEY (Id_TipoUsuario) REFERENCES TipoUsuario (Id),
)

CREATE TABLE [dbo].[Direcciones]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Usuario] INT NOT NULL, 
    [Calle] NCHAR(100) NOT NULL, 
    [Entidad] NCHAR(30) NOT NULL, 
    [Municipio] NCHAR(30) NOT NULL, 
    [Numero_Exterior] INT NOT NULL, 
    [Numero_Interior] INT NOT NULL, 
    [Codigo_Postal] INT NOT NULL, 
    [Referencias] TEXT NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuarios (Id),
)

CREATE TABLE [dbo].[Paqueterias]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(30) NOT NULL, 
    [Razon_Social] NVARCHAR(100) NOT NULL, 
    [Telefono] NCHAR(10) NOT NULL, 
    [Correo] NVARCHAR(50) NOT NULL, 
    [Direccion] TEXT NOT NULL, 
    [Estado] INT NOT NULL
)

CREATE TABLE [dbo].[Tarjetas]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Usuario] INT NOT NULL, 
    [Numero_Tarjeta] NCHAR(16) NOT NULL, 
    [Mes_Vencimiento] NCHAR(3) NOT NULL, 
    [Anio_Vencimiento] NCHAR(4) NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_Usuario_Tarjeta FOREIGN KEY (Id_Usuario) REFERENCES Usuarios (Id),
)

CREATE TABLE [dbo].[ImagenesProducto]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(MAX) NOT NULL, 
    [Id_Producto] INT NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_ProductoImagen FOREIGN KEY (Id_Producto) REFERENCES Productos (Id),
)

CREATE TABLE [dbo].[Compras]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Producto] INT NOT NULL, 
    [Cantidad] INT NOT NULL, 
    [Subtotal] MONEY NOT NULL, 
    [IVA] MONEY NOT NULL, 
    [Total] MONEY NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_Producto_Compra FOREIGN KEY (Id_Producto) REFERENCES Productos (Id),
)

CREATE TABLE [dbo].[Ventas]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Cantidad] INT NOT NULL, 
    [Subtotal] MONEY NOT NULL,
	[IVA] MONEY NOT NULL,
    [Total] MONEY NOT NULL, 
    [Id_Usuario] INT NOT NULL, 
    [Estado] INT NOT NULL, 
    CONSTRAINT fk_UsuarioVenta FOREIGN KEY (Id_Usuario) REFERENCES Usuarios (Id),

)

CREATE TABLE [dbo].[DetalleVenta]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Venta] INT NOT NULL, 
    [Id_Producto] INT NOT NULL, 
    [Cantidad] INT NOT NULL, 
    [Subtotal] MONEY NOT NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_DetalleVenta FOREIGN KEY (Id_Venta) REFERENCES Ventas (Id),
	CONSTRAINT fk_DetalleVentaProducto FOREIGN KEY (Id_Producto) REFERENCES Productos (Id),
)

CREATE TABLE [dbo].[Envios]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_Paqueteria] INT NOT NULL, 
	[Id_Venta] INT NOT NULL, 
    [Codigo_Rastreo] NVARCHAR(50) NOT NULL, 
    [Fecha_Envio] DATE NOT NULL, 
    [Fecha_Estimada_Entrega] DATE NOT NULL, 
    [Estado_Envio] INT NOT NULL, 
    [Fecha_Entrega] DATE NULL, 
    [Estado] INT NOT NULL,
	CONSTRAINT fk_EnviosPaqueteria FOREIGN KEY (Id_Paqueteria) REFERENCES Paqueterias (Id),
	CONSTRAINT fk_EnviosVenta FOREIGN KEY (Id_Venta) REFERENCES Ventas (Id),
)

--Datos Precargados

SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Confección                    ', N'Articulos varios pára la confeccion', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Costura                       ', N'Articulos varios de costura', 1)
INSERT INTO [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Maquinas de Coser             ', N'Variedad de maquinas para la costura', 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF

SET IDENTITY_INSERT [dbo].[Subcategorias] ON
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (1, 1, N'Listones                      ', N'Listones', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (2, 1, N'Elásticos                     ', N'Elasticos', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (3, 1, N'Encajes                       ', N'Encajes', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (4, 1, N'Cierres                       ', N'Cierres', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (5, 1, N'Cintas                        ', N'Cintas', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (6, 2, N'Tejidos                       ', N'Tejidos', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (7, 2, N'Agujas                        ', N'Agujas', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (8, 2, N'Alfileres                     ', N'Alfileres', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (9, 2, N'Botones                       ', N'Botones', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (10, 2, N'Hilos                         ', N'Hilos', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (11, 3, N'SemiProfesionales             ', N'SemiProfesionales', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (12, 3, N'Profesionales                 ', N'Profesionales', 1)
INSERT INTO [dbo].[Subcategorias] ([Id], [Id_Categoria], [Nombre], [Descripcion], [Estado]) VALUES (13, 3, N'Accesorios                    ', N'Accesorios', 1)
SET IDENTITY_INSERT [dbo].[Subcategorias] OFF

SET IDENTITY_INSERT [dbo].[Paqueterias] ON
INSERT INTO [dbo].[Paqueterias] ([Id], [Nombre], [Razon_Social], [Telefono], [Correo], [Direccion], [Estado]) VALUES (1, N'DHL                           ', N'DHL S.A DE C.V', N'7221348976', N'dhlservicio@dhl.com', N'Calle manuel villada N° 123, La mota, Lerma', 1)
SET IDENTITY_INSERT [dbo].[Paqueterias] OFF

SET IDENTITY_INSERT [dbo].[TipoUsuario] ON
INSERT INTO [dbo].[TipoUsuario] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Admin                         ', N'Administrador del sitio', 1)
INSERT INTO [dbo].[TipoUsuario] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Cliente                       ', N'Cliente que realiza compras en el sitio', 1)
INSERT INTO [dbo].[TipoUsuario] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Comprador                     ', N'Realiza el abastecimiento del stock', 1)
INSERT INTO [dbo].[TipoUsuario] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Enviador                      ', N'Realiza el envio de los pedidos y el seguimiento de los mismos', 1)
INSERT INTO [dbo].[TipoUsuario] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (5, N'Servicio al cliente           ', N'Realiza el servicio al cliente y atiende dudas o problemas', 1)
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF


