INSERT INTO DIRTYDEEDS.FormaPago (Descripcion) 
SELECT DISTINCT Forma_Pago_Desc FROM gd_esquema.Maestra 
WHERE Forma_Pago_Desc IS NOT NULL;

INSERT INTO DIRTYDEEDS.Factura (Numero, Fecha, Total, IdFormaPago)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total,Id FROM gd_esquema.Maestra, DIRTYDEEDS.FormaPago 
WHERE Forma_Pago_Desc = Descripcion AND Factura_Nro IS NOT NULL;

INSERT INTO DIRTYDEEDS.Localidad(Nombre,Deleted) VALUES ('Buenos Aires', 0)

INSERT INTO DIRTYDEEDS.Rubro(Descripcion) VALUES('General')

INSERT INTO DIRTYDEEDS.Publicacion_Estado
SELECT DISTINCT Publicacion_Estado from gd_esquema.Maestra

INSERT INTO DIRTYDEEDS.Visibilidad(Codigo,Descripcion,Porcentaje,Precio)
SELECT DISTINCT Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Porcentaje,Publicacion_Visibilidad_Precio
FROM gd_esquema.Maestra

INSERT INTO DIRTYDEEDS.Usuario(Usuario)
Select DISTINCT Cli_DNI from gd_esquema.Maestra
WHERE Cli_Dni IS NOT NULL

INSERT INTO DIRTYDEEDS.Usuario(Usuario)
SELECT DISTINCT Publ_Empresa_Cuit from gd_esquema.Maestra
WHERE Publ_Empresa_Cuit IS NOT NULL

INSERT INTO DIRTYDEEDS.Direccion(Domicilio,NumeroCalle,Piso,Depto,CodPostal,IdLocalidad, Deleted)
SELECT DISTINCT Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal, Id, 0 FROM gd_esquema.Maestra, DIRTYDEEDS.Localidad
WHERE Cli_Dni IS NOT NULL 

INSERT INTO DIRTYDEEDS.Direccion (Domicilio, NumeroCalle, Piso,Depto,CodPostal, IdLocalidad)
SELECT DISTINCT Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, Publ_Empresa_Depto,Publ_Empresa_Cod_Postal,Id FROM gd_esquema.Maestra,DIRTYDEEDS.Localidad
WHERE Publ_Empresa_Dom_Calle IS NOT NULL

INSERT INTO DIRTYDEEDS.Cliente(TipoDocumento,Documento,Nombre,Apellido,FechaNacimiento,Mail,IdDireccion,IdUsuario)
SELECT DISTINCT 'DNI', Cli_Dni,Cli_Nombre,Cli_Apeliido,Cli_Fecha_Nac,Cli_Mail,dir.Id, usuario.Id
FROM gd_esquema.Maestra,DIRTYDEEDS.Direccion as dir, DIRTYDEEDS.Usuario as usuario
WHERE Cli_Dni IS NOT NULL 
AND Cli_Dom_Calle = Domicilio 
AND Cli_Nro_Calle = NumeroCalle
AND CAST(Cli_Dni as CHAR(20))= usuario.Usuario

INSERT INTO DIRTYDEEDS.Empresa (RazonSocial,Cuit,FechaIngreso,Mail,NombreContacto, Ciudad, IdDireccion, IdUsuario)
SELECT DISTINCT Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion, Publ_Empresa_Mail, 'Sin Contacto', 'Buenos Aires',dir.Id, usuario.id
FROM gd_esquema.Maestra,DIRTYDEEDS.Direccion as dir, DIRTYDEEDS.Usuario as usuario
WHERE Publ_Empresa_Razon_Social IS NOT NULL
AND Publ_Empresa_Dom_Calle = Domicilio
AND Publ_Empresa_Nro_Calle = NumeroCalle
AND Publ_Empresa_Cuit = usuario.Usuario

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Descripcion,Stock,Fecha,FechaVto,Precio,Tipo,IdEstado,IdRubro,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'C', estado.Id, rubro.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Rubro as rubro, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Publicacion_Estado as estado
WHERE Publicacion_Tipo = 'Compra Inmediata'
AND rubro.Descripcion = 'General'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND CAST(Publ_Cli_Dni as varchar(20)) = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Descripcion,Stock,Fecha,FechaVto,Precio,Tipo,IdEstado,IdRubro,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'S', estado.Id, rubro.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Rubro as rubro, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Publicacion_Estado as estado
WHERE Publicacion_Tipo = 'Subasta'
AND rubro.Descripcion = 'General'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND CAST(Publ_Cli_Dni as varchar(20)) = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Descripcion,Stock,Fecha,FechaVto,Precio,Tipo,IdEstado,IdRubro,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'C', estado.Id, rubro.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Rubro as rubro, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Publicacion_Estado as estado
WHERE Publicacion_Tipo = 'Compra Inmediata'
AND rubro.Descripcion = 'General'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND Publ_Empresa_Cuit = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado

INSERT INTO DIRTYDEEDS.Publicacion(Codigo,Descripcion,Stock,Fecha,FechaVto,Precio,Tipo,IdEstado,IdRubro,IdVisibilidad,IdUsuario)
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha, Publicacion_Fecha_Venc,Publicacion_Precio,'S', estado.Id, rubro.Id, visibilidad.Id, usuario.Id
FROM gd_esquema.Maestra, DIRTYDEEDS.Rubro as rubro, DIRTYDEEDS.Visibilidad as visibilidad, DIRTYDEEDS.Usuario as usuario, DIRTYDEEDS.Publicacion_Estado as estado
WHERE Publicacion_Tipo = 'Subasta'
AND rubro.Descripcion = 'General'
AND Publicacion_Visibilidad_Cod = visibilidad.Codigo
AND Publ_Empresa_Cuit = usuario.Usuario
AND estado.Descripcion = Publicacion_Estado
