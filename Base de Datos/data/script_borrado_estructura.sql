
drop table DIRTYDEEDS.Rol_Funcionalidad
drop table DIRTYDEEDS.Usuario_Rol
drop table DIRTYDEEDS.Rol
drop table DIRTYDEEDS.Calificacion
drop table DIRTYDEEDS.Empresa
drop table DIRTYDEEDS.Cliente
drop table DIRTYDEEDS.Direccion
drop table DIRTYDEEDS.Localidad
drop table DIRTYDEEDS.Item
drop table DIRTYDEEDS.Factura
drop table DIRTYDEEDS.OfertaCompra
drop table DIRTYDEEDS.Publicacion_Pregunta
drop table DIRTYDEEDS.Publicacion_Rubro
drop table DIRTYDEEDS.Publicacion
drop table DIRTYDEEDS.Rubro
drop table DIRTYDEEDS.Visibilidad
drop table DIRTYDEEDS.Estado
drop table DIRTYDEEDS.FormaPago
drop table DIRTYDEEDS.Usuario
drop view DIRTYDEEDS.Vendedores
drop view DIRTYDEEDS.Calificacion_Vendedores


-- Si ya existe borramos la funcion.
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.GetSiguienteCodigoPublicacion'))
begin
   drop function DIRTYDEEDS.GetSiguienteCodigoPublicacion
end
go

-- Si ya existe borramos la funcion.
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.GetSiguienteCodigoFactura'))
begin
   drop function DIRTYDEEDS.GetSiguienteCodigoFactura
end
go

-- Si ya existe borramos la funcion.
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.GetSiguienteCodigoCalificacion'))
begin
   drop function DIRTYDEEDS.GetSiguienteCodigoCalificacion
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.Preguntas'))
begin
   drop procedure DIRTYDEEDS.Preguntas
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.PreguntasRespondidas'))
begin
   drop procedure DIRTYDEEDS.PreguntasRespondidas
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.ItemsAunNoRendidos'))
begin
   drop procedure DIRTYDEEDS.ItemsAunNoRendidos
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.VendedoresConMayorFacturacion'))
begin
   drop procedure DIRTYDEEDS.VendedoresConMayorFacturacion
end
go


if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.OfertasGanadoras'))
begin
   drop procedure DIRTYDEEDS.OfertasGanadoras
end
go

if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.ComprasYOfertasGanadas'))
begin
   drop procedure DIRTYDEEDS.ComprasYOfertasGanadas
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.Calificaciones'))
begin
   drop procedure DIRTYDEEDS.Calificaciones
end
go

-- Si existe borramos el sp
if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.ComprasYOfertasConCalificacionPendiente'))
begin
   drop procedure DIRTYDEEDS.ComprasYOfertasConCalificacionPendiente
end
go

if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.VendedoresCalificaciones'))
begin
   drop procedure DIRTYDEEDS.VendedoresCalificaciones
end
go

if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.ClientesMayorCantidadSinCalificaciones'))
begin
   drop procedure DIRTYDEEDS.ClientesMayorCantidadSinCalificaciones
end
go

if exists (select * from sysobjects where id = object_id('DIRTYDEEDS.VendedoresConMasProductosNoVendidos'))
begin
   drop procedure DIRTYDEEDS.VendedoresConMasProductosNoVendidos
end
go



DROP SCHEMA DIRTYDEEDS



