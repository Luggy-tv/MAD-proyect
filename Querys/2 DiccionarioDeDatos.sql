IF DB_ID(N'Tienda01')IS NOT NULL
	USE Tienda01;
/*
SELECT T.NAME AS [Nombre de tabla], 
       C.NAME AS [Nombre de columna], 
       P.NAME AS [Tipo de dato], 
       CASE C.max_length 
         WHEN -1 THEN 'MAX' 
         ELSE CONVERT(VARCHAR, C.max_length) 
       END AS [Tamaño], 
       CASE c.is_nullable 
         WHEN 0 THEN 'No Nulo' 
         ELSE 'Nulo' 
       END AS [Nullable], 
       CASE c.is_identity 
         WHEN 0 THEN '' 
         ELSE 'PK' 
       END AS [PK], 
       CASE 
         WHEN ( fk.object_id IS NULL ) THEN '' 
         ELSE 'FK' 
       END AS [FK], 
       Isnull(sep.value, '') [Descripcion] 
FROM   sys.objects AS T 
       JOIN sys.columns AS C ON T.object_id = C.object_id 
       JOIN sys.schemas AS S ON T.schema_id = S.schema_id 
       JOIN sys.types AS P ON C.system_type_id = P.system_type_id 
       LEFT JOIN sys.extended_properties sep ON C.object_id = sep.major_id AND C.column_id = sep.minor_id AND sep.NAME = 'MS_Description' 
       LEFT JOIN (sys.foreign_keys fk 
                  INNER JOIN sys.foreign_key_columns fc ON ( fk.object_id = fc.constraint_object_id )) 
              ON ( ( fk.parent_object_id = C.object_id ) 
                   AND ( fc.parent_column_id = C.column_id ) ) 
WHERE  T.type_desc = 'USER_TABLE' 
		and  T.name <> 'sysdiagrams' 
ORDER  BY T.NAME, 
          c.column_id; 
		  */
GO
-------------------------------------------------------------------------------------------Usuario
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDAdministrador
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Identificador de cada usuario, es auto generado.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'IDUsuario';
	--contraseña
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Contraseña del usuario, necesaria para iniciar sesion en el sistema.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'contraseña';
	--nombres
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Nombre o nombres del usuario.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'nombres';
	--apellidoPat
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Apellido Paterno del usuario.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'apellidoPat';
	--apellidoMat
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Apellido Materno del usuario.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'apellidoMat';
	--CURP
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'La Clave Única de Registro de Población es un único de identidad de 18 caracteres utilizado para identificar residentes mexicanos.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'CURP';
	--fechNac	
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Fecha de nacimiento del usuario formato (YYYY-MM-DD).',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'fechNac';
	--numNomina
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Numero de nomina del usuario.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'numNomina';
	--email
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Correo electronico principal del usuario.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'email';
	--fechaAlta
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Fecha a la cual se agrego al usuario al sistema.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'fechaAlta';
	--Estatus
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Menciona el estatus actual del usuario, si es 1= activo en la empresa; 0= no activo en la empresa.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'Estatus';
	--EsAdmin
	EXEC sp_addextendedproperty
@name = N'MS_Description', @value = 'Menciona si el usuario actual es admin, 1= es administrador; 0= no es administrador.',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table', @level1name = 'Usuario',
@level2type = N'Column', @level2name = 'esAdmin';
END
GO
-------------------------------------------------------------------------------------------Caja
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDCaja
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de cada caja, es auto generado.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Caja',
	@level2type = N'Column', @level2name = 'IDCaja';
	--Estatus
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Marca el estatus de la caja, si es igual a 1= esta disponible; 0= esta siendo usada.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Caja',
	@level2type = N'Column', @level2name = 'Disponible';
	--Activa
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Marca si la caja esta o estará disponible para su uso, si 1= esta disponible;0= esta caja ha sido descontinuada.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Caja',
	@level2type = N'Column', @level2name = 'Activa';
	END
GO
-------------------------------------------------------------------------------------------LogVenta
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;--IDLogVenta
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de cada vez que se realice una venta, es auto generado.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogVenta',
	@level2type = N'Column', @level2name = 'IDLogVenta';
	--Cajero_CajaFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al cajero que esta utilizando la caja donde se realiza la transaccion.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogVenta',
	@level2type = N'Column', @level2name = 'Cajero_CajaFK';
	--ReciboVentaFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'LLave foranea que se refiere al recibo de venta que se genera al realizar una venta.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogVenta',
	@level2type = N'Column', @level2name = 'ReciboVentaFK';
	--Fecha
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha en la que se genera la transaccion.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogVenta',
	@level2type = N'Column', @level2name = 'Fecha';
END
GO
-------------------------------------------------------------------------------------------Usuario_Caja
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDCajero_Caja
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de cada vez que el cajero ingrese a una caja.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Usuario_Caja',
	@level2type = N'Column', @level2name = 'IDCajero_Caja';
	--CajeroFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea a la que hace referencia al cajero que inicia sesion en la caja.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Usuario_Caja',
	@level2type = N'Column', @level2name = 'CajeroFK';
	--CajaFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia a la caja siendo usada por el cajero.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Usuario_Caja',
	@level2type = N'Column', @level2name = 'CajaFK';
	--Fecha
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha y hora a la que el cajero inicia sesion en la caja.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Usuario_Caja',
	@level2type = N'Column', @level2name = 'Fecha';
END
GO
-------------------------------------------------------------------------------------------Departamento
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;--IDDepartamento
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de departamento, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Departamento',
	@level2type = N'Column', @level2name = 'IDDepartamento';
	--nombreDept
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre del departamento.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Departamento',
	@level2type = N'Column', @level2name = 'nombreDept';
	--Reembolsable
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Menciona la capacidad de productos que pertencen al departamento de ser reembolsable.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Departamento',
	@level2type = N'Column', @level2name = 'Reembolsable';
	--Estatus
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Estado que menciona si el departamento sigue activo y todos los productos pertenecientes a este.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Departamento',
	@level2type = N'Column', @level2name = 'Estatus';
END
GO
-------------------------------------------------------------------------------------------Descuento
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDDescuento
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador del descuento, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'IDDescuento';
	--Nombre
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre del descuento.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'Nombre';
	--Porcentaje
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Porcentaje del descuento a aplicar del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'Porcentaje';
	--FechaINI
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha inicial en la que se aplica el descuento.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'FechaINI';
	--FechaFIN
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha final en la que se aplica el descuento.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'FechaFIN';
	--ProductoFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea al producto al que se esta asociado el descuento.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'ProductoFK';
	--Estado
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Estado del descuento, si es 1= Descuento aun activo, 0=Descuento no activo.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Descuento',
	@level2type = N'Column', @level2name = 'Estado';
END
GO
-------------------------------------------------------------------------------------------Devolucion
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDDevolucion
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de devolucion, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Devolucion',
	@level2type = N'Column', @level2name = 'IDDevolucion';
	--ProductoFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que apunta a que producto fue devuelto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Devolucion',
	@level2type = N'Column', @level2name = 'ProductoFK';
	--Cantidad
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Este cuenta la cantidad de productos regresados.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Devolucion',
	@level2type = N'Column', @level2name = 'Cantidad';
	--Merma
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Estado que menciona si la devolucion es merma o se reingresa al inventario, 1=es merma y la devolucion sera negativa; 0= NO es merma y regresara al inventario.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Devolucion',
	@level2type = N'Column', @level2name = 'Merma';
END
GO
-------------------------------------------------------------------------------------------NotaCred_Devol
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDNotaCred_Devol
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador creado al generar una devolucion que incluye referencia a la nota de credito, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCred_Devol',
	@level2type = N'Column', @level2name = 'IDNotaCred_Devol';
	--NotaCreditoFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia a la nota de credito que esta transaccion pertenece.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCred_Devol',
	@level2type = N'Column', @level2name = 'NotaCreditoFK';
	--DevolucionFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia a la devolucion hecha por estra transaccion.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCred_Devol',
	@level2type = N'Column', @level2name = 'DevolucionFK';
	--Fecha
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha en la que se realizo la devolucion y la generacion de la nota de credito.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCred_Devol',
	@level2type = N'Column', @level2name = 'Fecha';
END
GO
--------------------------------------------------------------------------------------------NotaCredito
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDNotaCredito
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Idenrtificador de nota de credito, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCredito',
	@level2type = N'Column', @level2name = 'IDNotaCredito';
	--Cantidad
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Cantidad de saldo a favor al cliente .',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCredito',
	@level2type = N'Column', @level2name = 'Cantidad';
	--Subtotal
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Esta es la suma parcial del credito antes de obtener el total general.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCredito',
	@level2type = N'Column', @level2name = 'Subtotal';
	--NumReciboFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que indica a que recibo de venta pertenece la nota de credito.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'NotaCredito',
	@level2type = N'Column', @level2name = 'NumReciboFK';
END
GO
--------------------------------------------------------------------------------------------OpcionDePago
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;--IDOpcionDePago
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de la opcion de pago, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'OpcionDePago',
	@level2type = N'Column', @level2name = 'IDOpcionDePago';
	--Nombre
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre de la opcion de pago.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'OpcionDePago',
	@level2type = N'Column', @level2name = 'Nombre';
	--Estatus
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Estado de que marca si la opcion de pago esta disponbible, 1 siendo disponible; 0 siendo no disponible.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'OpcionDePago',
	@level2type = N'Column', @level2name = 'Estatus';
END
GO
--------------------------------------------------------------------------------------------Producto
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;--IDProducto
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de producto, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'IDProducto';
	--Nombre
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'Nombre';
	--Descripcion
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Descripcion del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'Descripcion';
	--UnidadMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que identifica la unidad de medida usadas por el sistema.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'UnidadMedidaFK';
	--Costo
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Precio al que la tienda compra el producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'Costo';
	--PrecioUnitario
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Precio el que el cliente deberá pagar por unidad de medida.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'PrecioUnitario';
	--FechaAlta
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha en que se agrego el producto al sistema.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'FechaAlta';
	--Existencias
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Cantidad de un producto que se encuentra en el inventario actual.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'Existencias';
	--PuntoDeReorden
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Cantidad de un producto a la que llega para que se necesite hacer un reorden del producto al provedor.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'PuntoDeReorden';
	--Estatus
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Define el estado actual del producto, si es igual a 1= el producto sigue en venta; 0= el producto esta descontinuado.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'Estatus';
	--DepartamentoFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia a cual departamento pertenece el producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'Producto',
	@level2type = N'Column', @level2name = 'DepartamentoFK';
END
GO
--------------------------------------------------------------------------------------------ReciboDeVenta
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDRecibo
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de recibo, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'ReciboDeVenta',
	@level2type = N'Column', @level2name = 'IDRecibo';
	--Total
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Cantidad total a pagar por el cliente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'ReciboDeVenta',
	@level2type = N'Column', @level2name = 'Total';
	--Subtotal
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Sumatoria previa de los precios unitarios al total.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'ReciboDeVenta',
	@level2type = N'Column', @level2name = 'Subtotal';
END
GO
--------------------------------------------------------------------------------------------RecVent_Prod
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDRecVent_Prod
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de la accion de agregar un producto a un recibo de venta, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetalleProductos',
	@level2type = N'Column', @level2name = 'IDRecVent_Prod';
	--ReciboVentaFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al recibo de venta del cual pertenecen los productos.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetalleProductos',
	@level2type = N'Column', @level2name = 'ReciboVentaFK';
	--ProductoFK
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al producto agregado al recibo de venta.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetalleProductos',
	@level2type = N'Column', @level2name = 'ProductoFK';
	--CantProd
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Cantidad de producto que se agrega al recibo de venta, se mide por unidad de medida del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetalleProductos',
	@level2type = N'Column', @level2name = 'CantProd';
END
GO

--------------------------------------------------------------------------------------------UnidadDeMedida
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de unidad de medidas, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'UnidadDeMedida',
	@level2type = N'Column', @level2name = 'IDUnidadDeMedida';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre de la unidad de medida, puede ser: Latas, bolsas, botellas, kilos, litros, etc.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'UnidadDeMedida',
	@level2type = N'Column', @level2name = 'Nombre';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Estatus de la unidad de medida si es 1 quiere decir que esta disponible; si es 0 no esta disponible.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'UnidadDeMedida',
	@level2type = N'Column', @level2name = 'Estatus';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Pequeña descripcion de la unidad de medida ya que puede que algunas sean especificas para cierto producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'UnidadDeMedida',
	@level2type = N'Column', @level2name = 'Descripcion';
END
GO

--------------------------------------------------------------------------------------------LogEditProd
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDLogEditProd
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de registro de modificacion de un producto, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogEditProd',
	@level2type = N'Column', @level2name = 'IDLogEditProd';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al usuaro que edito el producto en cuestion.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogEditProd',
	@level2type = N'Column', @level2name = 'FkUsuario';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al producto editado.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogEditProd',
	@level2type = N'Column', @level2name = 'FkProducto';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha de la edicion del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'LogEditProd',
	@level2type = N'Column', @level2name = 'fecha';
END
GO

--------------------------------------------------------------------------------------------DatosDeTienda
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--[IDTienda]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de tienda, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'IDTienda';
	--[NombreTienda]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Nombre de la tienda.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'NombreTienda';
	--[Sucursal]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Numero de sucursal de la franquicia.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'Sucursal';
	--[RFC]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Registro Federal de Contribuyentes de la tienda.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'RFC';
	--[Domicilio]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Direccion en la que se encuentra el local.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'Domicilio';
	--[CodigoPostal]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Es el codigo postal del domicilio.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'CodigoPostal';
	--[email]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Correo electronico de contacto de la tienda.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'email';
	--[numTel]
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Numero telefonico de contacto de la tienda.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DatosDeTienda',
	@level2type = N'Column', @level2name = 'numTel';
END
GO

--------------------------------------------------------------------------------------------LogEditProd
IF DB_ID(N'Tienda01')IS NOT NULL
BEGIN
	USE Tienda01;
	--IDLogEditProd
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Identificador de detalle de pago de un recibo de venta, generado automaticamente.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetallePago',
	@level2type = N'Column', @level2name = 'IDDetallePago';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia al recibo de venta.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetallePago',
	@level2type = N'Column', @level2name = 'FkRecVenta';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Llave foranea que hace referencia .',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetallePago',
	@level2type = N'Column', @level2name = 'FKOpPago';
	--IDUnidadDeMedida
	EXEC sp_addextendedproperty
	@name = N'MS_Description', @value = 'Fecha de la edicion del producto.',
	@level0type = N'Schema', @level0name = 'dbo',
	@level1type = N'Table', @level1name = 'DetallePago',
	@level2type = N'Column', @level2name = 'Cantidad';
END
GO


SELECT T.NAME AS [Nombre de tabla], 
       C.NAME AS [Nombre de columna], 
       P.NAME AS [Tipo de dato], 
       CASE C.max_length 
         WHEN -1 THEN 'MAX' 
         ELSE CONVERT(VARCHAR, C.max_length) 
       END AS [Tamaño], 
       CASE c.is_nullable 
         WHEN 0 THEN 'No Nulo' 
         ELSE 'Nulo' 
       END AS [Nullable], 
       CASE c.is_identity 
         WHEN 0 THEN '' 
         ELSE 'PK' 
       END AS [PK], 
       CASE 
         WHEN ( fk.object_id IS NULL ) THEN '' 
         ELSE 'FK' 
       END AS [FK], 
       Isnull(sep.value, '') [Descripcion] 
FROM   sys.objects AS T 
       JOIN sys.columns AS C ON T.object_id = C.object_id 
       JOIN sys.schemas AS S ON T.schema_id = S.schema_id 
       JOIN sys.types AS P ON C.system_type_id = P.system_type_id 
       LEFT JOIN sys.extended_properties sep ON C.object_id = sep.major_id AND C.column_id = sep.minor_id AND sep.NAME = 'MS_Description' 
       LEFT JOIN (sys.foreign_keys fk 
                  INNER JOIN sys.foreign_key_columns fc ON ( fk.object_id = fc.constraint_object_id )) 
              ON ( ( fk.parent_object_id = C.object_id ) 
                   AND ( fc.parent_column_id = C.column_id ) ) 
WHERE  T.type_desc = 'USER_TABLE' 
		and  T.name <> 'sysdiagrams' 
ORDER  BY T.NAME, 
          c.column_id; 

--EJEMPLO DE AGREGADO
--EXEC sp_addextendedproperty
--@name = N'MS_Description', @value = '',
--@level0type = N'Schema', @level0name = 'dbo',
--@level1type = N'Table', @level1name = '',
--@level2type = N'Column', @level2name = '';
--GO

--EJEMPLO DE UPDATE
--EXEC sp_updateextendedproperty
--@name = N'MS_Description', @value = '',
--@level0type = N'Schema', @level0name = 'dbo',
--@level1type = N'Table', @level1name = '',
--@level2type = N'Column', @level2name = '';
--GO
GO