IF DB_ID(N'Tienda01')IS NOT NULL

	/*DROP ALL TABLES

	DROP TABLE dbo.LogVenta;
	DROP TABLE dbo.DetallePago
	DROP TABLE dbo.LogEditProd;
	DROP TABLE dbo.Usuario_Caja;
	DROP TABLE dbo.DetalleProductos;
	DROP TABLE dbo.ReciboDeVenta;
	DROP TABLE dbo.NotaCred_Devol;
	DROP TABLE dbo.Descuento;
	DROP TABLE dbo.NotaCredito;
	DROP TABLE dbo.Devolucion;
	DROP TABLE dbo.Usuario;
	DROP TABLE dbo.Caja;
	DROP TABLE dbo.Producto;
	DROP TABLE dbo.Departamento;
	DROP TABLE dbo.UnidadDeMedida;
	DROP TABLE dbo.OpcionDePago;
	Drop Table dbo.DatosDeTienda;

	*/
BEGIN
	USE Tienda01;
------------------------------------------------------------Usuario
	IF OBJECT_ID(N'dbo.Usuario')IS NOT NULL
		DROP TABLE dbo.Usuario;
	CREATE TABLE  dbo.Usuario(
		 IDUsuario					SMALLINT		IDENTITY(10000,1) 
		,contraseña					VARCHAR(20)		NOT NULL
		,nombres					VARCHAR (30)	NOT NULL
		,apellidoPat				VARCHAR (30)	NOT NULL
		,apellidoMat				VARCHAR (30)
		,CURP						CHAR(18)		NOT NULL
		,fechNac					DATE			NOT NULL
		,numNomina					CHAR(16)		NOT NULL
		,email						VARCHAR(30)		NOT NULL
		,fechaAlta					DATE			NOT NULL
		,esAdmin					BIT				NOT NULL
		,Estatus					BIT	CONSTRAINT DF_CAJEROESTATUS DEFAULT 1 

		CONSTRAINT PK_CAJERO
			PRIMARY KEY(IDUsuario)
	);
-----------------------------------------------------------OpcionDePago
	IF OBJECT_ID(N'dbo.OpcionDePago')IS NOT NULL
		DROP TABLE dbo.OpcionDePago;
	CREATE TABLE  dbo.OpcionDePago(
		IDOpcionDePago			TINYINT 			IDENTITY(10,1)
		,Nombre					VARCHAR(20)			NOT NULL
		,Estatus				BIT	CONSTRAINT DF_OpcionDePago DEFAULT 1
		CONSTRAINT PK_OPCIONDEPAGO
			PRIMARY KEY(IDOpcionDePago)
	);
-----------------------------------------------------------UnidadDeMedida
	IF OBJECT_ID(N'dbo.UnidadDeMedida')IS NOT NULL
		DROP TABLE dbo.UnidadDeMedida;
	CREATE TABLE  dbo.UnidadDeMedida(
		IDUnidadDeMedida		SMALLINT 			IDENTITY(10,1)
		,Nombre					VARCHAR(20)			NOT NULL
		,Estatus				BIT	 CONSTRAINT DF_UNIMEDESTATUS DEFAULT 1
		,Descripcion			VARCHAR(30)			NOT NULL
		CONSTRAINT PK_UNIDADDEMEDIDA
			PRIMARY KEY(IDUnidadDeMedida)
	);
------------------------------------------------------------Caja
	IF OBJECT_ID(N'dbo.Caja')IS NOT NULL
		DROP TABLE dbo.Caja;
	CREATE TABLE  dbo.Caja(
		IDCaja						TINYINT			IDENTITY(1,1)
		,Disponible					BIT	CONSTRAINT DF_CAJAESTATUS	DEFAULT 1	NOT NULL
		,Activa						BIT CONSTRAINT DF_CAJAACTIVA DEFAULT 1		
		CONSTRAINT PK_CAJA
			PRIMARY KEY(IDCaja)
	);
------------------------------------------------------------Departamento
	IF OBJECT_ID(N'dbo.Departamento')IS NOT NULL
		DROP TABLE dbo.Departamento;
	CREATE TABLE  dbo.Departamento(
		IDDepartamento				SMALLINT		IDENTITY(10000,1)
		,nombreDept					VARCHAR(30)		NOT NULL
		,Reembolsable				BIT				NOT NULL
		,Estatus					BIT		CONSTRAINT DF_DPTOESTATUS DEFAULT 1
		CONSTRAINT PK_DEPARTAMENTO
			PRIMARY KEY(IDDepartamento)
	);
------------------------------------------------------------Recibo de Venta
	IF OBJECT_ID(N'dbo.ReciboDeVenta')IS NOT NULL
		DROP TABLE dbo.ReciboDeVenta;
	CREATE TABLE  dbo.ReciboDeVenta(
		IDRecibo			INT			   IDENTITY(1000000,1)
		,Total				SMALLMONEY	   NOT NULL
		,Subtotal			SMALLMONEY	   NOT NULL
		CONSTRAINT PK_RECIBOVENTA
			PRIMARY KEY(IDRecibo),
	);
------------------------------------------------------------Productos
	IF OBJECT_ID(N'dbo.Producto')IS NOT NULL
		DROP TABLE dbo.Producto;
	CREATE TABLE  dbo.Producto(
		 IDProducto				INT				 IDENTITY(1000000,1)
		,Nombre					VARCHAR(30)		 NOT NULL
		,Descripcion			VARCHAR(50)		 NOT NULL
		,Costo					SMALLMONEY		 NOT NULL
		,PrecioUnitario			SMALLMONEY		 NOT NULL
		,FechaAlta				DATE			 NOT NULL
		,Existencias			DECIMAL (7,3)	 NOT NULL
		,PuntoDeReorden			DECIMAL (7,3)	 NOT NULL
		,Estatus				BIT	 CONSTRAINT DF_ProductoEstatus DEFAULT 1	 
		,DepartamentoFK			SMALLINT		 NOT NULL
		,UnidadMedidaFK			SMALLINT		 NOT NULL

		CONSTRAINT PK_PRODUCTO
			PRIMARY KEY(IDProducto),
		CONSTRAINT FK_DEPARTAMENTO
			FOREIGN KEY (DepartamentoFK) REFERENCES Departamento(IDDepartamento),
		CONSTRAINT FK_UNIDADMEDIDA
			FOREIGN KEY (UnidadMedidaFK) REFERENCES UnidadDeMedida(IDUnidadDeMedida)
	);


------------------------------------------------------------Descuento
	IF OBJECT_ID(N'dbo.Descuento')IS NOT NULL
		DROP TABLE dbo.Descuento;
	CREATE TABLE  dbo.Descuento(
		 IDDescuento				INT				 IDENTITY(1000000,1)
		,Nombre 				VARCHAR(20)										NOT NULL
		,Porcentaje				TINYINT											NOT NULL
		,FechaINI				DATE											NOT NULL
		,FechaFIN				DATE											NOT NULL
		,ProductoFK				INT												NOT NULL
		,Estado					BIT	CONSTRAINT DF_DESCUENTODEFAULT DEFAULT 1	
		CONSTRAINT PK_DESCUENTO
			PRIMARY KEY(IDDescuento),
		CONSTRAINT FK_PRODUCTO
			FOREIGN KEY (ProductoFK) REFERENCES Producto(IDProducto)
	);
------------------------------------------------------------Nota de Credito
	IF OBJECT_ID(N'dbo.NotaCredito')IS NOT NULL
		DROP TABLE dbo.NotaCredito;
	CREATE TABLE  dbo.NotaCredito(
		IDNotaCredito			INT				 IDENTITY(1000000,1)
		,Cantidad				SMALLMONEY		 NOT NULL
		,Subtotal				SMALLMONEY		 NOT NULL
		,NumReciboFK			INT				 NOT NULL
		CONSTRAINT PK_NOTACREDITO
			PRIMARY KEY(IDNotaCredito),
		CONSTRAINT FK_NOTA_NUMERORECIBO
			FOREIGN KEY (NumReciboFK) REFERENCES ReciboDeVenta(IDRecibo)
	);
------------------------------------------------------------Devolucion
	IF OBJECT_ID(N'dbo.Devolucion')IS NOT NULL
		DROP TABLE dbo.Devolucion;
	CREATE TABLE  dbo.Devolucion(
		IDDevolucion			INT				IDENTITY(1000000,1)
		,ProductoFK				INT				 NOT NULL
		,Cantidad				SMALLINT		 NOT NULL
		,Merma					BIT				 NOT NULL
		CONSTRAINT PK_DEVOLUCION
			PRIMARY KEY (IDDevolucion),
		CONSTRAINT FK_DEVOL_PRODUCTO
			FOREIGN KEY (ProductoFK) REFERENCES Producto(IDProducto)
	);
------------------------------------------------------------Usuario- Caja
	IF OBJECT_ID(N'dbo.Usuario_Caja')IS NOT NULL
		DROP TABLE dbo.Usuario_Caja;
	CREATE TABLE  dbo.Usuario_Caja(
		IDCajero_Caja		SMALLINT	IDENTITY(10000,1)	
		,CajeroFK			SMALLINT	NOT NULL
		,CajaFK				TINYINT		NOT NULL
		,Fecha				SMALLDATETIME CONSTRAINT DF_CAJEROCAJA_FECHA DEFAULT GETDATE() NOT NULL

		CONSTRAINT PK_CAJERO_CAJA
			PRIMARY KEY(IDCajero_Caja),
		CONSTRAINT FK_CAJEROCAJA_CAJERO
			FOREIGN KEY (CajeroFK) REFERENCES Usuario(IDUsuario),
		CONSTRAINT FK_CAJEROCAJA_CAJA
			FOREIGN KEY (CajaFK) REFERENCES Caja(IDCaja)
	);
-------------------------------------------------------------Recibo de venta - producto
	IF OBJECT_ID(N'dbo.DetalleProductos')IS NOT NULL
		DROP TABLE dbo.DetalleProductos;
	CREATE TABLE  dbo.DetalleProductos(
		IDRecVent_Prod			INT		IDENTITY(1000000,1)
		,ReciboVentaFK			INT
		,ProductoFK				INT
		,CantProd				DECIMAL(7,3)

		CONSTRAINT PK_RECVENTAPROD
			PRIMARY KEY(IDRecVent_Prod),
		CONSTRAINT FK_RECVENTAPROD_RECVENTA
			FOREIGN KEY (ReciboVentaFK) REFERENCES ReciboDeVenta(IDRecibo),
		CONSTRAINT FK_RECVENTAPROD_PROD
			FOREIGN KEY (ProductoFK) REFERENCES Producto(IDProducto),
	);
------------------------------------------------------------(Usuario-Cajero)-(ReciboVenta-Producto-Descuento)
	IF OBJECT_ID(N'dbo.LogVenta')IS NOT NULL
		DROP TABLE dbo.LogVenta;
	CREATE TABLE  dbo.LogVenta(
		IDLogVenta						INT	IDENTITY(1000000,1)
		,Cajero_CajaFK					SMALLINT
		,ReciboVentaFK					INT
		,Fecha							DATETIME
		CONSTRAINT PK_LOGVENTA
			PRIMARY KEY(IDLogVenta),
		CONSTRAINT FK_LOGVENTA_CajeroCaja
			FOREIGN KEY (Cajero_CajaFK) REFERENCES Usuario_Caja(IDCajero_Caja),
		CONSTRAINT FK_LOGVENTA_ReciboVenta
			FOREIGN KEY (ReciboVentaFK) REFERENCES ReciboDeVenta(IDRecibo)
	);
------------------------------------------------------------Nota de credito - Devolucion
	IF OBJECT_ID(N'dbo.NotaCred_Devol')IS NOT NULL
		DROP TABLE dbo.NotaCred_Devol;
	CREATE TABLE  dbo.NotaCred_Devol(
		IDNotaCred_Devol				INT	IDENTITY(1000000,1)
		,NotaCreditoFK					INT
		,DevolucionFK					INT
		,Fecha							SMALLDATETIME

		CONSTRAINT PK_NotaCred_Devol
			PRIMARY KEY(IDNotaCred_Devol),
		CONSTRAINT FK_NotaCredDevol_NotaCredito
			FOREIGN KEY (NotaCreditoFK) REFERENCES NotaCredito(IDNotaCredito),
		CONSTRAINT FK_NotaCredDevol_Devolucion
			FOREIGN KEY (DevolucionFK) REFERENCES Devolucion(IDDevolucion)

	);
-------------------------------------------------------------DetallePago
	IF OBJECT_ID(N'dbo.DetallePago')IS NOT NULL
		DROP TABLE dbo.DetallePago;
	CREATE TABLE  dbo.DetallePago(
		IDDetallePago				INT	IDENTITY(1000000,1)
		,FkRecVenta					INT
		,FKOpPago					TINYINT
		,Cantidad					SMALLMONEY
		
		CONSTRAINT PK_DetallePago
			Primary key (IDDetallePago),
		Constraint FK_DetallePago_ReciboVenta
			Foreign key (FkRecVenta) References ReciboDeVenta(IDRecibo),
		Constraint FK_DetallePago_OpPago
			foreign key (FkOpPago) references OpcionDePago(IDOpcionDePago)
		)
	---------------------------------------------------------LogEditProd
	If OBJECT_ID(N'dbo.LogEditProd') IS NOT NULL
		Drop Table dbo.LogEditProd;
	Create Table dbo.LogEditProd(
		IDLogEditProd				INT IDENTITY(1000000,1)
		,FkUsuario					smallint
		,FkProducto					int
		,fecha						Datetime
	
	CONSTRAINT PK_LogEditProd
			PRIMARY KEY(IDLogEditProd),
		CONSTRAINT FK_LofEditProd_Usuario
			FOREIGN KEY (FkUsuario) REFERENCES usuario(IDUsuario),
		CONSTRAINT FK_LogEditProd_Producto
			FOREIGN key (FkProducto) References producto(IDProducto)
	)
	---------------------------------------------------------DatosDeTienda
	IF OBJECT_ID(N'dbo.DatosDeTienda')IS NOT NULL
		Drop table dbo.DatosDeTienda;
	Create Table dbo.DatosDeTienda(
		 IDTienda				TinyInt	IDENTITY (0,1)
		,NombreTienda			Varchar(30)	 NOT NULL
		,Sucursal				tinyint		 NOT NULL
		,RFC					CHAR(13)	 NOT NULL
		,Domicilio				VARCHAR(100) NOT NULL
		,CodigoPostal			CHAR(6)		 NOT NULL
		,email					VARCHAR(40)	 NOT NULL
		,numTel					CHAR(10)	 NOT NULL

		CONSTRAINT PK_DatosDeTienda
			PRIMARY KEY(IDTienda)
		)
END
GO