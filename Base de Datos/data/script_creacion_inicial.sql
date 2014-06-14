USE GD1C2014;
GO
CREATE SCHEMA DIRTYDEEDS AUTHORIZATION gd

create table Usuario
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Usuario char(20) not null unique,
	Contrasenia varchar(256) not null DEFAULT 'Password',
	IntentosFallidos int not null DEFAULT 0,
	Deleted bit not null DEFAULT 0
)

create table Rol
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Nombre varchar(30) not null,
	Deleted bit not null DEFAULT 0
)

create table Rol_Funcionalidad
(
	IdRol int foreign key references Rol(Id),
	IdFuncionalidad int not null,
	primary key (IdRol, IdFuncionalidad)
)

create table Usuario_Rol
(
	IdUsuario int foreign key references Usuario(Id),
	IdRol int foreign key references Rol(Id)
	primary key (IdUsuario, IdRol)
)

create table Calificacion
(
	Codigo int primary key,
	Descripcion nvarchar(255) not null,
	CantidadEstrellas int not null
)

create table Usuario_Calificacion
(
	IdUsuario int foreign key references Usuario(Id),
	CodCalificacion int foreign key references Calificacion(Codigo),
	primary key (IdUsuario, CodCalificacion)
)

create table Cliente
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Apellido nvarchar(150) not null,
	Nombre nvarchar(150) not null,
	TipoDocumento char(4) not null,
	Documento int not null,
	FechaNacimiento datetime not null,
	Telefono nvarchar(40), 
	Mail nvarchar(150) not null,
	IdDireccion int foreign key references Direccion(Id),
	IdUsuario int foreign key references Usuario(Id),
	Deleted bit not null DEFAULT 0
)

create table Empresa
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	RazonSocial nvarchar(255) not null unique,
	Cuit nvarchar(50) not null unique,
	FechaIngreso datetime not null,
	Mail nvarchar(50) not null,
	Ciudad nvarchar(60) not null,
	NombreContacto varchar(60) not null,
	IdDireccion int foreign key references Direccion(Id),
	IdUsuario int foreign key references Usuario(Id),
	Deleted bit not null DEFAULT 0
)

create table Localidad
(
	Id int not null IDENTITY(1,1) primary key,
	Nombre nvarchar(255) unique,
	Deleted bit not null DEFAULT 0
)
create table Direccion
(
	Id int not null IDENTITY(1,1) primary key,
	Domicilio nvarchar(255) not null,
	NumeroCalle int not null,
	Piso int not null,
	Depto nvarchar(50) not null,
	CodPostal int NOT NULL,
	IdLocalidad int foreign key references Localidad(Id),
	Deleted bit not null DEFAULT 0
)

create table FormaPago
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion nvarchar(255) not null
)

create table Factura
(
	Numero int primary key,
	Fecha datetime not null,
	Total numeric(18, 2) not null,
	IdFormaPago int not null foreign key references FormaPago(Id)
)

create table Item
(
	NumFactura int foreign key references Factura(Numero),
	NumItem int not null,
	Descripcion varchar(60) not null,
	Monto numeric(18, 2) not null,
	Cantidad int not null,
	primary key (NumFactura,NumItem)
)

create table Visibilidad
(
	Id int not null IDENTITY(1,1) primary key,
	Codigo varchar(20) not null,
	Descripcion nvarchar(255) not null,
	Precio numeric(18, 2) not null,
	Porcentaje numeric(18, 2) not null,
	Deleted bit not null DEFAULT 0
)

create table Rubro
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion nvarchar(255) not null,
	Deleted bit not null DEFAULT 0
)

create table Publicacion
(
	Codigo int primary key,
	Descripcion nvarchar(255) not null,
	Stock int not null,
	Fecha datetime not null,
	FechaVto datetime not null,
	Precio numeric(18, 2) not null,
	Tipo char(1) not null,
	IdEstado int foreign key references Publicacion_Estado(Id),
	IdRubro int foreign key references Rubro(Id),
	IdVisibilidad int foreign key references Visibilidad(Id),
	IdUsuario int foreign key references Usuario(Id) not null
)

create table Publicacion_Estado
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion varchar(50) not null
)

create table Publicacion_Pregunta
(
	CodPublicacion int foreign key references Publicacion(Codigo),
	NumPregunta int,
	Pregunta nvarchar(255) not null,
	Respuesta nvarchar(255),
	primary key (CodPublicacion, NumPregunta)
)

create table OfertaCompra
(
	IdUsuario int foreign key references Usuario(Id),
	CodPublicacion int foreign key references Publicacion(Codigo),
	Fecha datetime not null,
	Monto numeric(18, 2),
	Cantidad int,
	primary key (IdUsuario, CodPublicacion) 
)


GO

