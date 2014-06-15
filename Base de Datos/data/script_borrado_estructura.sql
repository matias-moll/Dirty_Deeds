
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
drop table DIRTYDEEDS.Publicacion_Pregunta
drop table DIRTYDEEDS.Publicacion_Rubro
drop table DIRTYDEEDS.OfertaCompra
drop table DIRTYDEEDS.Publicacion
drop table DIRTYDEEDS.Rubro
drop table DIRTYDEEDS.Visibilidad
drop table DIRTYDEEDS.Publicacion_Estado
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

DROP SCHEMA DIRTYDEEDS



