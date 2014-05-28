USE GD1C2014;
GO
CREATE SCHEMA DIRTYDEEDS AUTHORIZATION gd

create table Usuario
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Username char(20) not null unique,
	Contrasenia varchar(32) not null,
	Deleted bit not null
)

create table Rol
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Nombre varchar(30) not null,
	Deleted bit not null
)

create table Funcionalidad
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion varchar(30) not null,
	Deleted bit not null
)

create table Rol_Funcionalidad
(
	IdRol int foreign key references Rol(Id),
	IdFuncionalidad int foreign key references Funcionalidad(id),
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
	Codigo numeric(18, 0) primary key,
	Descripcion nvarchar(255) not null,
	CantidadEstrellas numeric(18, 0) not null
)

create table Usuario_Calificacion
(
	IdUsuario int foreign key references Usuario(Id),
	CodCalificacion numeric(18, 0) foreign key references Calificacion(Codigo),
	primary key (IdUsuario, CodCalificacion)
)

create table Cliente
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Apellido nvarchar(255) not null,
	Nombre nvarchar(255) not null,
	TipoDocumento char(4) not null,
	Documento numeric(18, 0) not null,
	FechaNacimiento datetime not null,
	Mail nvarchar(255) not null,
	Deleted bit not null
)

create table Empresa
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	RazonSocial nvarchar(255) not null unique,
	Cuit nvarchar(50) not null unique,
	FechaIngreso datetime not null,
	Mail nvarchar(50) not null,
	NombreContacto varchar(60) not null,
	Deleted bit not null
)

create table Localidad
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Nombre nvarchar(255) not null unique
)
create table Direccion
(
	Id int not null IDENTITY(1,1) primary key,
	IdCliente int foreign key references Cliente(Id),
	IdEmpresa int foreign key references Empresa(Id),
	Domicilio nvarchar(255) not null,
	NumeroCalle numeric(18, 0) not null,
	Piso numeric(18, 0) not null,
	Depto nvarchar(50) not null,
	CodPostal int not null,
	IdLocalidad int foreign key references Localidad(Id)
)

create table FormaPago
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion nvarchar(255) not null
)

create table Factura
(
	Numero numeric(18, 0) primary key,
	Fecha datetime not null,
	Total numeric(18, 2) not null,
	IdFormaPago int not null foreign key references FormaPago(Id)
)

create table Item
(
	NumFactura numeric(18, 0) foreign key references Factura(Numero),
	NumItem int not null,
	Descripcion varchar(60) not null,
	Monto numeric(18, 2) not null,
	Cantidad numeric(18, 0) not null,
	primary key (NumFactura,NumItem)
)

create table Visibilidad
(
	Codigo numeric(18, 0) not null IDENTITY(1,1) primary key,
	Descripcion nvarchar(255) not null,
	Precio numeric(18, 2) not null,
	Porcentaje numeric(18, 2) not null,
	Deleted bit not null
)

create table Rubro
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion nvarchar(255) not null,
	Deleted bit not null
)

create table Publicacion
(
	Codigo numeric(18, 0) primary key,
	Descripcion nvarchar(255) not null,
	Stock numeric(18, 0) not null,
	Fecha datetime not null,
	FechaVto datetime not null,
	Precio numeric(18, 2) not null,
	Tipo char(1) not null,
	IdRubro int foreign key references Rubro(Id),
	CodVisibilidad numeric(18, 0) foreign key references Visibilidad(Codigo)
)

create table Publicacion_Pregunta
(
	CodPublicacion numeric(18, 0) foreign key references Publicacion(Codigo),
	NumPregunta int,
	Pregunta nvarchar(255) not null,
	Respuesta nvarchar(255),
	primary key (CodPublicacion, NumPregunta)
)

create table OfertaCompra
(
	IdUsuario int foreign key references Usuario(Id),
	CodPublicacion numeric(18, 0) foreign key references Publicacion(Codigo),
	Fecha datetime not null,
	Monto numeric(18, 2),
	Cantidad numeric(18, 0),
	primary key (IdUsuario, CodPublicacion) 
)


GO

