USE GD1C2014;
GO
CREATE SCHEMA DIRTYDEEDS AUTHORIZATION gd

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

create table Usuario
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Usuario char(20) not null unique,
	Contrasenia varchar(256) not null DEFAULT 'e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a',
	IntentosFallidos int not null DEFAULT 0,
	IdReferencia int not null,
	Discriminante char not null,
	Deleted bit not null DEFAULT 0
)

create table Calificacion
(
	Codigo int primary key,
	CodigoPublicacion int foreign key references Publicacion(Codigo),
	IdCalificador int foreign key references Usuario(Id),
	IdCalificado int foreign key references Usuario(Id),
	Descripcion nvarchar(255) not null,
	CantidadEstrellas int not null,
	IdCompra int foreign key references OfertaCompra(Id)
)

create table Usuario_Rol
(
	IdUsuario int foreign key references Usuario(Id),
	IdRol int foreign key references Rol(Id)
	primary key (IdUsuario, IdRol)
)

create table Cliente
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Apellido nvarchar(150) not null,
	Nombre nvarchar(150) not null,
	TipoDocumento char(4) not null,
	Documento int not null,
	FechaNacimiento datetime not null,
	Telefono nvarchar(40) not null DEFAULT '', 
	Mail nvarchar(150) not null,
	IdDireccion int foreign key references Direccion(Id),
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
	Descripcion varchar(255) not null,
	Monto numeric(18, 2) not null,
	Cantidad int not null,
	CodigoPublicacion int not null,
	primary key (NumFactura,NumItem)
)

create table Visibilidad
(
	Id int not null IDENTITY(1,1) primary key,
	Codigo varchar(20) not null,
	Descripcion nvarchar(255) not null,
	Precio numeric(18, 2) not null,
	Porcentaje numeric(18, 2) not null,
	DiasActiva int not null DEFAULT 30,
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
	Presentacion nvarchar(255) not null,
	StockOriginal int not null,
	StockActual int not null,
	Fecha datetime not null,
	FechaVto datetime not null,
	Precio numeric(18, 2) not null,
	Tipo char(1) not null,
	AceptaPreguntas bit not null DEFAULT 1,
	Vendida char(1) not null Default 'N',
	IdEstado int foreign key references Estado(Id),
	IdVisibilidad int foreign key references Visibilidad(Id),
	IdUsuario int foreign key references Usuario(Id) not null
)

create table Publicacion_Rubro
(
	CodPublicacion int foreign key references Publicacion(Codigo),
	IdRubro int foreign key references Rubro(Id) not null
)

create table Estado
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	Descripcion varchar(50) not null
)

create table Publicacion_Pregunta
(
	CodPublicacion int foreign key references Publicacion(Codigo),
	NumPregunta int,
	Pregunta nvarchar(255) not null default '',
	Respuesta nvarchar(255)not null default '',
	primary key (CodPublicacion, NumPregunta)
)

create table OfertaCompra
(
	Id int NOT NULL IDENTITY(1,1) primary key,
	IdUsuario int foreign key references Usuario(Id),
	CodPublicacion int foreign key references Publicacion(Codigo),
	Fecha datetime not null,
	Monto numeric(18, 2) not null,
	Cantidad int not null ,
	Discriminante char(1) not null 
)




-- VISTAS
CREATE VIEW DIRTYDEEDS.Vendedores(IdUsuario,Vendedor)
AS
SELECT DISTINCT usuarios.Id as IdUsuario, CAST(clientes.Documento as varchar(20)) as Vendedor FROM DIRTYDEEDS.Cliente as clientes, DIRTYDEEDS.Usuario as usuarios, DIRTYDEEDS.Publicacion as publicaciones
WHERE publicaciones.IdUsuario = usuarios.Id
AND usuarios.IdReferencia = clientes.Id
AND usuarios.Discriminante = 'C'
UNION
SELECT DISTINCT usuarios.Id,empresas.Cuit FROM DIRTYDEEDS.Empresa as empresas, DIRTYDEEDS.Usuario as usuarios, DIRTYDEEDS.Publicacion as publicaciones
WHERE usuarios.IdReferencia = empresas.Id
AND usuarios.Id = publicaciones.IdUsuario
AND usuarios.Discriminante = 'E'
GO

-- Vendedores con calificacion Promedio
CREATE VIEW DIRTYDEEDS.Calificacion_Vendedores(IdUsuario,Vendedor,CalificacionPromedio)
AS
SELECT IdCalificado, vendedores.vendedor, SUM(CantidadEstrellas) / COUNT(IdCalificado) as promedio FROM DIRTYDEEDS.Calificacion, DIRTYDEEDS.Vendedores as vendedores
WHERE IdCalificado = vendedores.IdUsuario
GROUP BY IdCalificado, vendedores.vendedor
GO


-- Funciones
create function DIRTYDEEDS.GetSiguienteCodigoPublicacion()
returns int
as
begin
	declare @ret int
	select @ret = MAX(DIRTYDEEDS.Publicacion.Codigo) from DIRTYDEEDS.Publicacion
	return @ret + 1
end
go

create function DIRTYDEEDS.GetSiguienteCodigoFactura()
returns int
as
begin
	declare @ret int
	select @ret = MAX(DIRTYDEEDS.Factura.Numero) from DIRTYDEEDS.Factura
	return @ret + 1
end
go

create function DIRTYDEEDS.GetSiguienteCodigoCalificacion()
returns int
as
begin
	declare @ret int
	select @ret = MAX(DIRTYDEEDS.Calificacion.Codigo) from DIRTYDEEDS.Calificacion
	return @ret + 1
end
go

-- Stored Procedures
-- Preguntas a ser respndidas dado un usuario
create procedure DIRTYDEEDS.Preguntas(@IdUsuarioLoggeado int)
as
begin  
	select CodPublicacion as Codigo_Publicacion, NumPregunta as Numero_Pregunta, Pregunta, 
			Respuesta, Presentacion as Descripcion_Publicacion, StockActual, Fecha, Precio 
	from DIRTYDEEDS.Publicacion_Pregunta 
		join DIRTYDEEDS.Publicacion on Publicacion.Codigo = Publicacion_Pregunta.CodPublicacion
		join DIRTYDEEDS.Usuario on Usuario.Id = Publicacion.IdUsuario
	where IdUsuario = @IdUsuarioLoggeado 
end
go

CREATE Procedure DIRTYDEEDS.OfertasGanadoras
AS
BEGIN
	IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#OfertasMaximas')) BEGIN DROP TABLE #OfertasMaximas END
	
	SELECT CodPublicacion, MAX(Fecha) as FechaMaxima, MAX(Monto) as MontoMaximo INTO #OfertasMaximas
	FROM DIRTYDEEDS.OfertaCompra 
	WHERE Monto != 0 
	GROUP By CodPublicacion
	
	SELECT oferta.Id,oferta.IdUsuario,oferta.CodPublicacion,oferta.Fecha,oferta.Monto,oferta.Cantidad FROM DIRTYDEEDS.OfertaCompra as oferta, #OfertasMaximas as maximas
	WHERE oferta.Monto != 0
	AND oferta.CodPublicacion = maximas.CodPublicacion
	AND Fecha = maximas.FechaMaxima
	AND Monto = maximas.MontoMaximo
	ORDER BY oferta.CodPublicacion,oferta.Monto DESC
END
GO

CREATE Procedure DIRTYDEEDS.ComprasYOfertasGanadas
AS 
BEGIN
	IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#ComprasYOfertasGanadas')) BEGIN DROP TABLE #ComprasYOfertasGanadas END
	SELECT CodPublicacion, MAX(Fecha) as FechaMaxima, MAX(Monto) as MontoMaximo INTO #ComprasYOfertasGanadas
	FROM DIRTYDEEDS.OfertaCompra 
	WHERE Monto != 0 
	GROUP By CodPublicacion
	
	SELECT oferta.Id,oferta.IdUsuario,oferta.CodPublicacion,oferta.Fecha,oferta.Monto,oferta.Cantidad FROM DIRTYDEEDS.OfertaCompra as oferta, #ComprasYOfertasGanadas as maximas
	WHERE oferta.Monto != 0
	AND oferta.CodPublicacion = maximas.CodPublicacion
	AND Fecha = maximas.FechaMaxima
	AND Monto = maximas.MontoMaximo
	UNION
	SELECT Id,IdUsuario,CodPublicacion,Fecha,Monto,Cantidad FROM DIRTYDEEDS.OfertaCompra WHERE Monto = 0
	ORDER BY oferta.CodPublicacion,oferta.Monto DESC
END
GO


-- Historial de Calificaciones otorgadas y recibidas
create procedure DIRTYDEEDS.Calificaciones(@IdUsuarioLoggeado int)
as
begin  
	select CASE WHEN Calificacion.IdCalificado = @IdUsuarioLoggeado THEN 'Fuiste Calificado' 
									else 'Calificaste' end as Tipo , 
	Calificacion.CantidadEstrellas as Cantidad_Estrellas, Calificacion.Descripcion as Comentario_Calificacion, 
	Calificacion.CodigoPublicacion as Codigo_Publicacion, Publicacion.Presentacion
	from DIRTYDEEDS.Calificacion
	join DIRTYDEEDS.Publicacion on Publicacion.Codigo = Calificacion.CodigoPublicacion
	where IdCalificado = @IdUsuarioLoggeado or IdCalificador = @IdUsuarioLoggeado
	order by CodigoPublicacion desc 
end
go

-- Compras y Ofertas ganadoras con calificacion pendiente
create procedure DIRTYDEEDS.ComprasYOfertasConCalificacionPendiente(@IdUsuarioLoggeado int)
as
begin

	IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#OfertasMaximas')) BEGIN DROP TABLE #OfertasMaximas END

	-- Obtenemos las ofertas maximas de todas las subastas
	SELECT CodPublicacion, MAX(Fecha) as FechaMaxima, MAX(Monto) as MontoMaximo INTO #OfertasMaximas
	FROM DIRTYDEEDS.OfertaCompra 
	WHERE Monto != 0 
	GROUP By CodPublicacion

	-- Obtenemos las Ofertas ganadoras de las subastas que aun no tengan Calificaciones.
	SELECT publicacion.Presentacion, publicacion.Precio, OfertaCompra.Fecha, OfertaCompra.Cantidad, 'Subasta' as Tipo,
			OfertaCompra.CodPublicacion as Codigo_Publicacion, publicacion.IdUsuario as Id_Vendedor, 
			OfertaCompra.Id as Id_Compra
		FROM DIRTYDEEDS.OfertaCompra
		join  #OfertasMaximas on OfertaCompra.CodPublicacion = #OfertasMaximas.CodPublicacion
								AND OfertaCompra.Fecha = #OfertasMaximas.FechaMaxima
								AND OfertaCompra.Monto = #OfertasMaximas.MontoMaximo
		join DIRTYDEEDS.Publicacion on 	Publicacion.Codigo = OfertaCompra.CodPublicacion
		left outer join DIRTYDEEDS.Calificacion on OfertaCompra.Id = Calificacion.IdCompra
		WHERE OfertaCompra.Monto != 0 and publicacion.IdEstado = 4 
		and Calificacion.Codigo is null 
		and OfertaCompra.IdUsuario = @IdUsuarioLoggeado

		
	union

	-- Y lo unimos con las compras que aun no tengan calificaciones
	select Publicacion.Presentacion, Publicacion.Precio,OfertaCompra.Fecha, OfertaCompra.Cantidad, 'Compra' as Tipo, 
	OfertaCompra.CodPublicacion as Codigo_Publicacion, Publicacion.IdUsuario as Id_Vendedor, OfertaCompra.Id as Id_Compra
	 from DIRTYDEEDS.OfertaCompra 
		left outer join DIRTYDEEDS.Calificacion on OfertaCompra.Id = Calificacion.IdCompra
		join DIRTYDEEDS.Publicacion on Publicacion.Codigo = OfertaCompra.CodPublicacion
	where OfertaCompra.Discriminante = 'C' 
		and Calificacion.Codigo is null
		and OfertaCompra.IdUsuario = @IdUsuarioLoggeado
end
go


-- Items a pagar aun no rendidos. (facturacion)
create procedure DIRTYDEEDS.ItemsAunNoRendidos(@IdUsuarioLoggeado int)
as
begin
-- Items a pagar por Publicar para todas las publicaciones que no hayan sido rendidas (no esta su item asociado).
select Publicacion.Codigo, Publicacion.Presentacion, Visibilidad.Descripcion, Visibilidad.Precio as Costo, 
		'Publicación' as Tipo, 1 as Cantidad, Publicacion.Fecha 
from DIRTYDEEDS.Publicacion 
left outer join DIRTYDEEDS.Item on Item.CodigoPublicacion = Publicacion.Codigo
join DIRTYDEEDS.Visibilidad on Visibilidad.Id = Publicacion.IdVisibilidad
where Item.NumFactura is null
	and Publicacion.IdEstado = 4
	and Publicacion.IdUsuario = @IdUsuarioLoggeado
	
union

-- Lo unimos con las publicaciones vendidas (join con la tabla temporal precalculada) que no hayan sido rendidas.
select Publicacion.Codigo, Publicacion.Presentacion, Visibilidad.Descripcion, 
		(Visibilidad.Porcentaje * Publicacion.Precio) as Costo,'Comision Venta' as Tipo, 1 as Cantidad, Publicacion.Fecha 
from DIRTYDEEDS.Publicacion 
left outer join DIRTYDEEDS.Item on Item.CodigoPublicacion = Publicacion.Codigo
join DIRTYDEEDS.Visibilidad on Visibilidad.Id = Publicacion.IdVisibilidad
where Item.NumFactura is null
	and Publicacion.IdEstado = 4
	and Publicacion.Vendida = 'S'
	and Publicacion.IdUsuario = @IdUsuarioLoggeado
	
end
go

-- Listado Estadistico de vendedores con mayor facturacion
create procedure DIRTYDEEDS.VendedoresConMayorFacturacion(@Anio int, @MesInicio int, @MesFin int)
as
begin
	select top 5 
	CASE WHEN max(Cliente.Id) is Null THEN 'Empresa' else 'Cliente' end as Tipo_Vendedor, 
	CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.RazonSocial) else max(Cliente.Apellido) end as Identificacion,
	CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.Cuit) else  max(Cliente.Documento) end as Dni_O_Cuit,
	Usuario.Id as Id_Usuario, Factura.Total from DIRTYDEEDS.Usuario
	join DIRTYDEEDS.Cliente on Cliente.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Empresa on Empresa.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Publicacion on Publicacion.IdUsuario = Usuario.Id
	join DIRTYDEEDS.Item on Item.CodigoPublicacion = Publicacion.Codigo
	join DIRTYDEEDS.Factura on Factura.Numero = Item.NumFactura
	where year(Factura.Fecha) = @Anio
	and MONTH(Factura.Fecha) between @MesInicio and @MesFin
	group by Usuario.Id, Factura.Total
	order by Factura.Total desc
end
go

create procedure DIRTYDEEDS.VendedoresConMasProductosNoVendidos(@Anio int, @MesInicio int, @MesFin int, @IdVisibilidad int)
as
begin
	IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#OfertasMaximas')) BEGIN DROP TABLE #OfertasMaximas END
	-- Obtenemos las ofertas maximas de todas las subastas
	SELECT CodPublicacion, MAX(Fecha) as FechaMaxima, MAX(Monto) as MontoMaximo INTO #OfertasMaximas FROM DIRTYDEEDS.OfertaCompra  WHERE Monto != 0 GROUP By CodPublicacion

	select top 5 
	CASE WHEN max(Cliente.Id) is Null THEN 'Empresa' else 'Cliente' end as Tipo_Vendedor, 
	CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.RazonSocial) else max(Cliente.Apellido) end as Identificacion,
	CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.Cuit) else  max(Cliente.Documento) end as Dni_O_Cuit,
	 COUNT(*) as No_Vendidos from DIRTYDEEDS.Usuario
	join DIRTYDEEDS.Cliente on Cliente.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Empresa on Empresa.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Publicacion on Publicacion.IdUsuario = Usuario.Id
	join DIRTYDEEDS.Visibilidad on Publicacion.IdVisibilidad = Visibilidad.Id
	where Publicacion.Codigo not in -- El codigo de publicacion no tiene que estar en las ventas.
	(
		-- Obtenemos las Ofertas ganadoras de las subastas
		SELECT OfertaCompra.CodPublicacion as Codigo_Publicacion FROM DIRTYDEEDS.OfertaCompra
			join  #OfertasMaximas on OfertaCompra.CodPublicacion = #OfertasMaximas.CodPublicacion
									AND OfertaCompra.Fecha = #OfertasMaximas.FechaMaxima
									AND OfertaCompra.Monto = #OfertasMaximas.MontoMaximo
			join DIRTYDEEDS.Publicacion on 	Publicacion.Codigo = OfertaCompra.CodPublicacion
			WHERE OfertaCompra.Monto != 0 and publicacion.IdEstado = 4 
			group by OfertaCompra.CodPublicacion
			
		union

		-- Y lo unimos con las compras que aun no tengan calificaciones
		select OfertaCompra.CodPublicacion as Codigo_Publicacion from DIRTYDEEDS.OfertaCompra 
			join DIRTYDEEDS.Publicacion on Publicacion.Codigo = OfertaCompra.CodPublicacion
		where OfertaCompra.Discriminante = 'C' and OfertaCompra.Cantidad = Publicacion.StockOriginal
		group by OfertaCompra.CodPublicacion
	
	)
	and year(Publicacion.Fecha) = @Anio
	and MONTH(Publicacion.Fecha) between @MesInicio and @MesFin
	and Visibilidad.Id = @IdVisibilidad
	group by  IdUsuario
	order by COUNT(*) desc
end
go


CREATE PROCEDURE DIRTYDEEDS.VendedoresCalificaciones(@Anio int, @MesInicio int, @MesFin int)
AS
BEGIN
	select top 5
		CASE WHEN max(Cliente.Id) is Null THEN 'Empresa' else 'Cliente' end as Tipo_Vendedor, 
		CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.RazonSocial) else max(Cliente.Apellido) end as Identificacion,
		CASE WHEN max(Cliente.Id) is Null THEN max(Empresa.Cuit) else  max(Cliente.Documento) end as Dni_O_Cuit,
		sum(Calificacion.CantidadEstrellas) as Sumatoria_Estrellas, max(Usuario.Id) as Id_Usuario
	FROM DIRTYDEEDS.Vendedores as vendedores
	join DIRTYDEEDS.Calificacion on Calificacion.IdCalificado = vendedores.IdUsuario
	join DIRTYDEEDS.Usuario on vendedores.IdUsuario = Usuario.Id
	join DIRTYDEEDS.Cliente on Cliente.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Empresa on Empresa.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Publicacion on Publicacion.IdUsuario = Usuario.Id
	where year(Publicacion.Fecha) = @Anio
		and MONTH(Publicacion.Fecha) between @MesInicio and @MesFin
	group by Usuario.Id
	ORDER BY sum(CantidadEstrellas) desc
END
GO

CREATE PROCEDURE DIRTYDEEDS.ClientesMayorCantidadSinCalificaciones(@Anio int, @MesInicio int, @MesFin int)
AS
BEGIN
	select top 5
		 Cliente.Apellido, MAX(Cliente.Nombre) as Nombre, max(Cliente.Documento) as Documento,
		COUNT(*) as Cantidad_Sin_Calificar,
		max(Usuario.Id) as Id_Usuario
	FROM DIRTYDEEDS.Cliente
	join DIRTYDEEDS.Usuario on Cliente.Id = Usuario.IdReferencia
	join DIRTYDEEDS.Publicacion on Publicacion.IdUsuario = Usuario.Id
	left outer join DIRTYDEEDS.Calificacion on Calificacion.CodigoPublicacion = Publicacion.Codigo
	where year(Publicacion.Fecha) = @Anio
		and MONTH(Publicacion.Fecha) between @MesInicio and @MesFin
	group by Cliente.Apellido
	ORDER BY COUNT(*) desc
END
GO


-- Indices
CREATE INDEX IdVisibilidad
ON DIRTYDEEDS.Publicacion (IdVisibilidad)




-- Migracion de la tabla maestra a nuestro modelo de datos.
INSERT INTO DIRTYDEEDS.FormaPago (Descripcion) 
SELECT DISTINCT Forma_Pago_Desc FROM gd_esquema.Maestra 
WHERE Forma_Pago_Desc IS NOT NULL;

INSERT INTO DIRTYDEEDS.Factura (Numero, Fecha, Total, IdFormaPago)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total,Id FROM gd_esquema.Maestra, DIRTYDEEDS.FormaPago 
WHERE Forma_Pago_Desc = Descripcion AND Factura_Nro IS NOT NULL;

INSERT INTO DIRTYDEEDS.Localidad(Nombre,Deleted) VALUES ('Buenos Aires', 0)

INSERT INTO DIRTYDEEDS.Estado
SELECT DISTINCT Publicacion_Estado from gd_esquema.Maestra

INSERT INTO DIRTYDEEDS.Visibilidad(Codigo,Descripcion,Porcentaje,Precio)
SELECT DISTINCT Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Porcentaje,Publicacion_Visibilidad_Precio
FROM gd_esquema.Maestra
ORDER BY Publicacion_Visibilidad_Precio DESC

INSERT INTO DIRTYDEEDS.Direccion(Domicilio,NumeroCalle,Piso,Depto,CodPostal,IdLocalidad, Deleted)
SELECT DISTINCT Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal, Id, 0 FROM gd_esquema.Maestra, DIRTYDEEDS.Localidad
WHERE Cli_Dni IS NOT NULL 

INSERT INTO DIRTYDEEDS.Direccion (Domicilio, NumeroCalle, Piso,Depto,CodPostal, IdLocalidad)
SELECT DISTINCT Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, Publ_Empresa_Depto,Publ_Empresa_Cod_Postal,Id FROM gd_esquema.Maestra,DIRTYDEEDS.Localidad
WHERE Publ_Empresa_Dom_Calle IS NOT NULL

INSERT INTO DIRTYDEEDS.Cliente(TipoDocumento,Documento,Nombre,Apellido,FechaNacimiento,Mail,IdDireccion)
SELECT DISTINCT 'DNI', Cli_Dni,Cli_Nombre,Cli_Apeliido,Cli_Fecha_Nac,Cli_Mail,dir.Id
FROM gd_esquema.Maestra,DIRTYDEEDS.Direccion as dir
WHERE Cli_Dni IS NOT NULL 
AND Cli_Dom_Calle = Domicilio 
AND Cli_Nro_Calle = NumeroCalle

INSERT INTO DIRTYDEEDS.Usuario values ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 0, 0, 'C', 0)

INSERT INTO DIRTYDEEDS.Usuario(Usuario,Discriminante, IdReferencia, IntentosFallidos)
SELECT DISTINCT Cli_DNI,'C',Id, -1 from gd_esquema.Maestra, DIRTYDEEDS.Cliente
WHERE Cli_Dni IS NOT NULL
AND Cli_Dni = Documento

INSERT INTO DIRTYDEEDS.Empresa (RazonSocial,Cuit,FechaIngreso,Mail,NombreContacto, Ciudad, IdDireccion)
SELECT DISTINCT Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion, Publ_Empresa_Mail, 'Sin Contacto', 'Buenos Aires',dir.Id
FROM gd_esquema.Maestra,DIRTYDEEDS.Direccion as dir
WHERE Publ_Empresa_Razon_Social IS NOT NULL
AND Publ_Empresa_Dom_Calle = Domicilio
AND Publ_Empresa_Nro_Calle = NumeroCalle

INSERT INTO DIRTYDEEDS.Usuario(Usuario,Discriminante,IdReferencia, IntentosFallidos)
SELECT DISTINCT Publ_Empresa_Cuit,'E',Id, -1 from gd_esquema.Maestra, DIRTYDEEDS.Empresa
WHERE Publ_Empresa_Cuit IS NOT NULL
AND Publ_Empresa_Cuit = Cuit

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Presentacion,StockOriginal,StockActual,Fecha,FechaVto,Precio,Tipo,IdEstado,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'C', estado.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Estado as estado
WHERE Publicacion_Tipo = 'Compra Inmediata'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND CAST(Publ_Cli_Dni as varchar(20)) = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Presentacion,StockOriginal,StockActual,Fecha,FechaVto,Precio,Tipo,IdEstado,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'S', estado.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Estado as estado
WHERE Publicacion_Tipo = 'Subasta'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND CAST(Publ_Cli_Dni as varchar(20)) = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Presentacion,StockOriginal,StockActual,Fecha,FechaVto,Precio,Tipo,IdEstado,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'C', estado.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Estado as estado
WHERE Publicacion_Tipo = 'Compra Inmediata'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND Publ_Empresa_Cuit = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Presentacion,StockOriginal,StockActual,Fecha,FechaVto,Precio,Tipo,IdEstado,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock, Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'S', estado.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Estado as estado
WHERE Publicacion_Tipo = 'Subasta'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND Publ_Empresa_Cuit = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion_Rubro(CodPublicacion,IdRubro)
SELECT publicacion.Codigo, rubro.Id FROM DIRTYDEEDS.Rubro as rubro, DIRTYDEEDS.Publicacion as publicacion

-- Migramos primero las compras que si tienen calificacion
INSERT INTO DIRTYDEEDS.OfertaCompra(CodPublicacion,Fecha,Monto,Cantidad,IdUsuario,Discriminante)
SELECT Publicacion_Cod, Compra_Fecha, 0 as Monto, Compra_Cantidad as Cantidad, usuario.id,'C' from gd_esquema.Maestra, DIRTYDEEDS.Usuario as usuario
WHERE Compra_Fecha IS NOT NULL
AND CAST(Cli_Dni as varchar(20)) = usuario.Usuario
and Calificacion_Codigo is not null
order by Publicacion_Cod,Compra_Fecha, Cantidad

-- AHora las calificaciones asociadas a esas compras.
INSERT INTO DIRTYDEEDS.Calificacion(CodigoPublicacion,Codigo,CantidadEstrellas,Descripcion,IdCalificador,IdCalificado, IdCompra)
SELECT Publicacion_Cod,Calificacion_Codigo,Calificacion_Cant_Estrellas,
	Calificacion_Descripcion,calificador.id as IdCalificador,calificado.id  as IdCalificado,
	ROW_NUMBER() over (order by Publicacion_Cod,Compra_Fecha, gd_esquema.Maestra.Compra_Cantidad) as IdCompra
from gd_esquema.Maestra, DIRTYDEEDS.Usuario as calificador, DIRTYDEEDS.Usuario as calificado
WHERE Compra_Fecha IS NOT NULL
AND CAST(Cli_Dni as varchar(20))= calificador.Usuario
AND (Publ_Empresa_Cuit = calificado.Usuario OR CAST(Publ_Cli_Dni as varchar(20)) = calificado.Usuario)
and Calificacion_Codigo is not null
order by gd_Esquema.Maestra.Publicacion_Cod,Compra_Fecha, Compra_Cantidad

-- COmpletamos las compras con aquellas que no tengan calificacion.
INSERT INTO DIRTYDEEDS.OfertaCompra(CodPublicacion,Fecha,Monto,Cantidad,IdUsuario,Discriminante)
SELECT Publicacion_Cod, Compra_Fecha, 0 as Monto, Compra_Cantidad as Cantidad, usuario.id,'C' from gd_esquema.Maestra, DIRTYDEEDS.Usuario as usuario
WHERE Compra_Fecha IS NOT NULL
AND CAST(Cli_Dni as varchar(20)) = usuario.Usuario
and Calificacion_Codigo is null
order by Publicacion_Cod,Compra_Fecha, Cantidad

-- Y migramos las ofertas.
INSERT INTO DIRTYDEEDS.OfertaCompra(CodPublicacion,Fecha,Monto,Cantidad,IdUsuario,Discriminante)
SELECT Publicacion_Cod, Oferta_Fecha, Oferta_Monto, 0 as Cantidad, usuario.id,'S' from gd_esquema.Maestra, DIRTYDEEDS.Usuario as usuario
WHERE Oferta_Fecha IS NOT NULL
AND CAST(Cli_Dni as varchar(20)) = usuario.Usuario
order by Publicacion_Cod,Compra_Fecha

INSERT INTO DIRTYDEEDS.Item(NumItem,Monto,Cantidad,NumFactura,Descripcion, CodigoPublicacion)
SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) as NumItem,Item_Factura_Monto, Item_Factura_Cantidad, Factura_Nro,'' as Descripcion, Publicacion_Cod
FROM gd_esquema.Maestra
WHERE Item_Factura_Monto IS NOT NULL
ORDER BY Factura_Nro

-- Rubros
INSERT INTO DIRTYDEEDS.Rubro(Descripcion)
SELECT DISTINCT Publicacion_Rubro_Descripcion from gd_esquema.Maestra

INSERT INTO DIRTYDEEDS.Publicacion_Rubro(CodPublicacion,IdRubro)
SELECT DISTINCT publicaciones.codigo, rubros.Id 
FROM DIRTYDEEDS.Publicacion as publicaciones, DIRTYDEEDS.Rubro as rubros, gd_esquema.Maestra as maestra
WHERE maestra.Publicacion_Cod = publicaciones.Codigo
AND rubros.Descripcion = maestra.Publicacion_Rubro_Descripcion


-- Agregado de Configuracion del Sistema

--Estados
insert into DIRTYDEEDS.Estado(Descripcion) values ('Borrador')
insert into DIRTYDEEDS.Estado(Descripcion) values ('Pausada')
insert into DIRTYDEEDS.Estado(Descripcion) values ('Finalizada')


INSERT INTO DIRTYDEEDS.Rol(Nombre) VALUES('Empresa') 
INSERT INTO DIRTYDEEDS.Rol(Nombre) VALUES('Administrativo') 
INSERT INTO DIRTYDEEDS.Rol(Nombre) VALUES('Cliente') 

-- Empresa
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(1,2)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(1,3)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(1,4)
-- Admin
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(2,5)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(2,6)
-- Cliente
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(3,1)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(3,2)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(3,3)
INSERT INTO DIRTYDEEDS.Rol_Funcionalidad(IdRol,IdFuncionalidad) VALUES(3,4)

-- Permiso de Administrativo para el usuario Admin
insert into DIRTYDEEDS.Usuario_Rol values (1, 2)

-- Todas las empresas migradas tienen permisos de empresa.
insert into DIRTYDEEDS.Usuario_Rol (IdUsuario, IdRol)
select DIRTYDEEDS.Usuario.Id, 1 from DIRTYDEEDS.Usuario where DIRTYDEEDS.Usuario.Discriminante = 'E'and DIRTYDEEDS.Usuario.Id <> 1

-- Todos los clientes migrados tienen permisos de cliente.
insert into DIRTYDEEDS.Usuario_Rol (IdUsuario, IdRol)
select DIRTYDEEDS.Usuario.Id, 3 from DIRTYDEEDS.Usuario where DIRTYDEEDS.Usuario.Discriminante = 'C' and DIRTYDEEDS.Usuario.Id <> 1


