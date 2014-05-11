USE GD1C2014;
GO
CREATE SCHEMA DIRTYDEEDS AUTHORIZATION gd

create table Usuario
(
	id int primary key,
	username char(20) not null unique,
	contrasenia varchar(32) not null,
	deleted bit not null
)

create table Rol
(
	id int primary key,
	nombre varchar(30) not null,
	deleted bit not null
)

create table Funcionalidad
(
	id int primary key,
	descripcion varchar(30) not null,
	deleted bit not null
)

create table Rol_Funcionalidad
(
	idRol int foreign key references Rol(id),
	idFuncionalidad int foreign key references Funcionalidad(id),
	primary key (idRol, idFuncionalidad)
)

create table Usuario_Rol
(
	idUsuario int foreign key references Usuario(id),
	idRol int foreign key references Rol(id)
	primary key (idUsuario, idRol)
)

create table Calificacion
(
	codigo numeric(18, 0) primary key,
	descripcion nvarchar(255) not null,
	cantidadEstrellas numeric(18, 0) not null
)

create table Usuario_Calificacion
(
	idUsuario int foreign key references Usuario(id),
	codCalificacion numeric(18, 0) foreign key references Calificacion(codigo),
	primary key (idUsuario, codCalificacion)
)

create table Localidad
(
	codPostal int primary key not null,
	nombre nvarchar(100) not null
)

create table Cliente
(
	id int primary key,
	apellido nvarchar(255) not null,
	nombre nvarchar(255) not null,
	tipoDocumento char(4) not null,
	documento numeric(18, 0) not null,
	fechaNacimiento datetime not null,
	mail nvarchar(255) not null,
	domicilio nvarchar(255) not null,
	numeroCalle numeric(18, 0) not null,
	piso numeric(18, 0) not null,
	depto nvarchar(50) not null,
	codPostal int not null foreign key references Localidad(codPostal)
)

create table Empresa
(
	id int primary key,
	razonSocial nvarchar(255) not null unique,
	cuit nvarchar(50) not null unique,
	fechaIngreso datetime not null,
	mail nvarchar(50) not null,
	domicilio nvarchar(255) not null,
	numeroCalle numeric(18, 0) not null,
	piso numeric(18, 0) not null,
	depto nvarchar(50) not null,
	codPostal int not null foreign key references Localidad(codPostal),
	ciudad varchar(60) not null,
	nombreContacto varchar(60) not null
)

create table FormaPago
(
	id int primary key,
	descripcion nvarchar(255) not null
)

create table Factura
(
	numero numeric(18, 0) primary key,
	fecha datetime not null,
	total numeric(18, 2) not null,
	idFormaPago int not null foreign key references FormaPago(id)
)

create table Item
(
	numFactura numeric(18, 0) foreign key references Factura(numero),
	numItem int not null,
	descripcion varchar(60) not null,
	monto numeric(18, 2) not null,
	cantidad numeric(18, 0) not null,
	primary key (numFactura,numItem)
)

create table Visibilidad
(
	codigo numeric(18, 0) primary key,
	descripcion nvarchar(255) not null,
	precio numeric(18, 2) not null,
	porcentaje numeric(18, 2) not null
)

create table Rubro
(
	id int primary key,
	descripcion nvarchar(255) not null
)

create table Publicacion
(
	codigo numeric(18, 0) primary key,
	descripcion nvarchar(255) not null,
	stock numeric(18, 0) not null,
	fecha datetime not null,
	fechaVto datetime not null,
	precio numeric(18, 2) not null,
	tipo char(1) not null,
	idRubro int foreign key references Rubro(id),
	codVisibilidad numeric(18, 0) foreign key references Visibilidad(codigo)
)

create table Publicacion_Pregunta
(
	codPublicacion numeric(18, 0) foreign key references Publicacion(codigo),
	numPregunta int,
	pregunta nvarchar(255) not null,
	respuesta nvarchar(255),
	primary key (codPublicacion, numPregunta)
)

create table OfertaCompra
(
	idUsuario int foreign key references Usuario(id),
	codPublicacion numeric(18, 0) foreign key references Publicacion(codigo),
	fecha datetime not null,
	monto numeric(18, 2),
	cantidad numeric(18, 0),
	primary key (idUsuario, codPublicacion) 
)


GO

