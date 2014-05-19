INSERT INTO DIRTYDEEDS.FormaPago (Descripcion) 
SELECT DISTINCT Forma_Pago_Desc FROM gd_esquema.Maestra 
WHERE Forma_Pago_Desc IS NOT NULL;

INSERT INTO DIRTYDEEDS.Factura (Numero, Fecha, Total, IdFormaPago)
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total,Id FROM gd_esquema.Maestra, DIRTYDEEDS.FormaPago 
WHERE Forma_Pago_Desc = Descripcion AND Factura_Nro IS NOT NULL;

INSERT INTO DIRTYDEEDS.Cliente (TipoDocumento,Documento,Nombre,Apellido,FechaNacimiento,Mail)
SELECT DISTINCT 'DNI', Cli_Dni,Cli_Nombre,Cli_Apeliido,Cli_Fecha_Nac,Cli_Mail
FROM gd_esquema.Maestra
WHERE Cli_Dni IS NOT NULL 
ORDER BY Cli_Apeliido;

INSERT INTO DIRTYDEEDS.Direccion (IdCliente, Domicilio, NumeroCalle, Piso,Depto,CodPostal )
SELECT DISTINCT Id, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal FROM gd_esquema.Maestra,DIRTYDEEDS.Cliente
WHERE Documento = Cli_Dni AND Cli_Dni IS NOT NULL;