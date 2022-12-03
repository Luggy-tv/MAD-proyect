IF DB_ID(N'Tienda01')IS NOT NULL
	USE Tienda01;
GO

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

IF OBJECT_ID('v_OpcionesDePago') IS NOT NULL
	DROP View v_OpcionesDePago;
GO
Create view v_OpcionesDePago AS
	Select	 IDOpcionDePago AS[Numero de opcion de pago]
			,Nombre AS[Nombre de opcion de pago]
			,CASE Estatus WHEN 0THEN 'NO DISPONIBLE'ELSE 'DISPONIBLE' END AS [Estado de Opcion de pago]
			from OpcionDePago ;
GO

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
IF OBJECT_ID('v_Productos')IS NOT NULL
	DROP view v_Productos;
GO
CREATE VIEW v_Productos as
SELECT p.IDProducto,p.Nombre,p.Descripcion,p.Costo,p.PrecioUnitario,p.FechaAlta,p.Existencias,p.PuntoDeReorden,D.nombreDept [Departamento],Ue.Nombre[Unidad De Medida] From Producto AS P LEFT JOIN Departamento AS D ON P.DepartamentoFK=D.IDDepartamento LEFT JOIN UnidadDeMedida AS UE ON P.UnidadMedidaFK=UE.IDUnidadDeMedida  Where p.Estatus=1 AND D.Estatus=1;
GO
IF OBJECT_ID('v_Descuentos')IS NOT NULL
	DROP view v_Descuentos;
GO
CREATE VIEW v_Descuentos as
	SELECT IDDescuento,D.Nombre [Descuento],Porcentaje,FechaINI,FechaFIN,P.Nombre [Producto] FROM Descuento AS D LEFT JOIN Producto AS p ON d.ProductoFK=P.IDProducto WHere Estado=1; 
GO


