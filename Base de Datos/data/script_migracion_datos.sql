INSERT INTO DIRTYDEEDS.FormaPago (Descripcion) 
SELECT DISTINCT Forma_Pago_Desc FROM gd_esquema.Maestra 
WHERE Forma_Pago_Desc IS NOT NULL;