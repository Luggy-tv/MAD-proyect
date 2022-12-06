IF DB_ID(N'Tienda01')IS NOT NULL
	USE Tienda01;
GO
--------------------------------------------------------Vistas Usuarios
IF OBJECT_ID('v_Usuarios') IS NOT NULL
	DROP View v_Usuarios;
GO
Create view v_Usuarios AS
	Select	 IDUsuario												AS [Numero de usuario]
			,CONCAT(nombres, ' ',apellidoPat, ' ' , apellidoMat )	AS [Nombre Completo]
			,CURP													AS [CURP]
			, DATEDIFF(year,fechNac,CAST(GETDATE()AS date) )		AS [Edad]
			,email													AS [Correo electronico]
			,fechaAlta												AS [Fecha de Ingreso a la tienda]
			,CASE  esAdmin WHEN 0 THEN 'NO' ELSE 'SI' END		    AS [Es Administrador]
			,CASE Estatus WHEN 0 THEN 'Dado de Baja'ELSE 'Activo' END AS[Estado en la empresa]
			from Usuario;
GO

IF OBJECT_ID('v_UsuariosActivos') IS NOT NULL
	DROP View v_UsuariosActivos;
GO
Create view v_UsuariosActivos AS
	SELECT IDUsuario	
		,contraseña	
		,nombres	
		,apellidoPat
		,apellidoMat
		,CURP		
		,fechNac	
		,numNomina	
		,email		
		,fechaAlta	
		,esAdmin	
		from Usuario where Estatus =1;
GO
--------------------------------------------------------Vistas Opciones de Pagos
IF OBJECT_ID('v_OpcionesDePago') IS NOT NULL
	DROP View v_OpcionesDePago;
GO
Create view v_OpcionesDePago AS
	Select	 IDOpcionDePago AS[Numero de opcion de pago]
			,Nombre AS[Nombre de opcion de pago]
			,CASE Estatus WHEN 0THEN 'NO DISPONIBLE'ELSE 'DISPONIBLE' END AS [Estado de Opcion de pago]
			from OpcionDePago ;
GO
IF OBJECT_ID('v_OpcionesDePagoActivas') IS NOT NULL
	DROP View v_OpcionesDePagoActivas;
GO
Create view v_OpcionesDePagoActivas AS

	SELECT IDOpcionDePago,Nombre From OpcionDePago where Estatus=1;
GO
--------------------------------------------------------Vistas Unidad De Medidas
IF OBJECT_ID('v_UnidadDeMedidas') IS NOT NULL
	DROP View v_UnidadDeMedidas;
GO
Create view v_UnidadDeMedidas AS
	Select	 IDUnidadDeMedida	AS [Numero de unidad de medidas]
			,Nombre				AS	[Nombre de unidad de medida]
			,Descripcion		AS [Descripcion de unidad de medida]
			,CASE Estatus WHEN 0THEN 'NO DISPONIBLE'ELSE 'DISPONIBLE' END AS [Estado de unidad de medida]
			from UnidadDeMedida ;
GO
IF OBJECT_ID('v_UnidadDeMedidasActivas') IS NOT NULL
	DROP View v_UnidadDeMedidasActivas;
GO
Create view v_UnidadDeMedidasActivas AS

	SELECT	IDUnidadDeMedida,Nombre,Descripcion from UnidadDeMedida where Estatus=1;
GO
--------------------------------------------------------Vistas de productos
IF OBJECT_ID('v_Productos')IS NOT NULL
	DROP view v_Productos;
GO
CREATE VIEW v_Productos as
SELECT p.IDProducto,p.Nombre,p.Descripcion,p.Costo,p.PrecioUnitario,p.FechaAlta,p.Existencias,p.PuntoDeReorden,D.nombreDept [Departamento],Ue.Nombre[Unidad De Medida] From Producto AS P LEFT JOIN Departamento AS D ON P.DepartamentoFK=D.IDDepartamento LEFT JOIN UnidadDeMedida AS UE ON P.UnidadMedidaFK=UE.IDUnidadDeMedida  Where p.Estatus=1 AND D.Estatus=1;
GO
--------------------------------------------------------Vistas de descuentos
IF OBJECT_ID('v_Descuentos')IS NOT NULL
	DROP view v_Descuentos;
GO
CREATE VIEW v_Descuentos as
	SELECT IDDescuento,D.Nombre [Descuento],Porcentaje,FechaINI,FechaFIN,P.Nombre [Producto] FROM Descuento AS D LEFT JOIN Producto AS p ON d.ProductoFK=P.IDProducto WHere Estado=1; 
GO
-------------------------------------------------------Vista de Recibo de Venta
IF OBJECT_ID('v_ReciboDeVenta')IS NOT NULL
	Drop view v_ReciboDeVenta;
GO
Create view v_ReciboDeVenta as
	SELECT 
		 Recibo.IDRecibo						AS [Numero de recibo]
		,CASE 
			when Venta.IDLogVenta IS NOT NULL then 
				CONCAT(Usu.nombres,' ',Usu.apellidoPat,' ',Usu.apellidoMat) 
			else 
				'Cajero no identificado' 
		 end									AS [Nombre del cajero]
		,CASE 
			when Venta.IDLogVenta IS NOT NULL then 
				format(Venta.Fecha,'dd MMMM yyyy hh:mm:ss','es-es') 
			else 
				'Fecha no identificada' 
		 end									AS [Fecha de Venta]
		,CASE 
			when Venta.IDLogVenta IS NOT NULL then 
				convert(varchar(19),caja.IDCaja)
			else 
				'Caja no identificada' 
		 end									AS [Caja de la venta]
		,Prod.Nombre							AS [Nombre Del Producto]
		,format(Prod.Costo,'c','en-us')			AS [Precio de Producto]
		,DetalleProd.CantProd					AS [Cantidad de productos]
		,CASE 
			WHEN Venta.Fecha BETWEEN descu.FechaINI AND descu.FechaFIN THEN
				descu.Nombre
			ELSE
				'No hay descuento aplicado'											
		end										AS [Descuento Aplicado]
		,CASE 
			WHEN Venta.Fecha BETWEEN descu.FechaINI AND descu.FechaFIN THEN
				format(dbo.fn_GetProductDiscount(Prod.Costo,Descu.Porcentaje)*DetalleProd.CantProd,'c','en-us')
			else
				'No hay descuento aplicado'
		 end										AS [Cantidad Descontada]
		,OpcionPago.Nombre							AS [Opcion de pago]
		,format(DetallePago.Cantidad,'c','en-us')	AS [Cantidad de pago]
		,format(Recibo.Subtotal,'c','en-us')		AS [Subtotal]
		,format(Recibo.Total,'c','en-us')			AS [Total]
		from ReciboDeVenta			as Recibo 
		left join DetallePago		as DetallePago	on Recibo.IDRecibo			= DetallePago.FkRecVenta 
		left join DetalleProductos	as DetalleProd	on Recibo.IDRecibo			= DetalleProd.ReciboVentaFK  
		left join Producto			as Prod			on DetalleProd.ProductoFK	= Prod.IDProducto
		left join OpcionDePago		as OpcionPago	on DetallePago.FKOpPago		= OpcionPago.IDOpcionDePago
		left join LogVenta			as Venta		on Recibo.idrecibo			= Venta.ReciboVentaFK
		left join Usuario_Caja		as LogUsuCaja	on Venta.Cajero_CajaFK		= LogUsuCaja.IDCajero_Caja
		left join Usuario			as Usu			on LogUsuCaja.CajeroFK		= Usu.IDUsuario
		left join Caja				as Caja			on LogUsuCaja.CajaFK		= Caja.IDCaja
		left join Descuento			as Descu		on descu.ProductoFK			= Prod.IDProducto
GO
-------------------------------------------------------Vista de Busqueda de producto en recibo
IF OBJECT_ID('v_BuscarProductoEnRecibo')IS NOT NULL
	DROP view v_BuscarProductoEnRecibo;
GO
CREATE VIEW v_BuscarProductoEnRecibo as
	SELECT 
		Recibo.IDRecibo				as [Numero de recibo],	 --int
		DetalleProd.ProductoFK		as [Codigo de Producto], --int
		Producto.Nombre				as [Nombre de Producto], --string
		DetalleProd.CantProd		as [Cantidad en recibo], --decimal
		Departamento.Reembolsable	as [Reembolsable]		 --boolean
	from ReciboDeVenta				as Recibo 
	left join DetalleProductos		as DetalleProd	on Recibo.IDRecibo = DetalleProd.ReciboVentaFK  
	left join Producto				as Producto		on DetalleProd.ProductoFK=Producto.IDProducto
	left join Departamento			as Departamento on Producto.DepartamentoFK=Departamento.IDDepartamento
GO
-------------------------------------------------------Vista de NotadeCredito y Devoluciones
IF OBJECT_ID('v_NotaCreditoYDevol')IS NOT NULL
	DROP view v_NotaCreditoYDevol;
GO
CREATE VIEW v_NotaCreditoYDevol as
	select 
		NotaCred.IDNotaCredito		as [Numero De Nota De Credito],
		ReciboVent.IDRecibo			as [Recibo De Compra],
		NotaCred.Cantidad			as [Total del Recibo],
		Prod.IDProducto				as [Codigo del Producto],
		Prod.Nombre					as [Producto Devuelto],
		Devol.Cantidad				as [Cantidad de Productos devueltos],
		Devol.Merma					as [Es Merma]
	from NotaCred_Devol		as NotCredDevol
	left join NotaCredito	as NotaCred		on NotaCred.IDNotaCredito	=NotCredDevol.NotaCreditoFK
	left join Devolucion	as Devol		on Devol.IDDevolucion		=NotCredDevol.NotaCreditoFK
	left join ReciboDeVenta as ReciboVent	on ReciboVent.IDRecibo		=NotaCred.NumReciboFK
	left join Producto		as Prod			on Prod.IDProducto			=Devol.ProductoFK
GO


--select* from Devolucion
--select*from NotaCredito
--select*from NotaCred_Devol

--alter table NotaCred_Devol
--drop constraint [FK_NotaCredDevol_Devolucion]
--alter table NotaCred_Devol
--drop constraint[FK_NotaCredDevol_NotaCredito]

--ALTER  table NotaCred_Devol
--add CONSTRAINT FK_NotaCredDevol_NotaCredito
--	FOREIGN KEY (NotaCreditoFK) REFERENCES NotaCredito(IDNotaCredito)
--ALTER  table NotaCred_Devol
--add CONSTRAINT FK_NotaCredDevol_Devolucion
--	FOREIGN KEY (DevolucionFK) REFERENCES Devolucion(IDDevolucion)

--truncate table devolucion
--truncate table	NotaCredito
--truncate table	NotaCred_Devol