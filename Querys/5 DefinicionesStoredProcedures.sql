USE Tienda01;
GO
    /*
	DROPS ALL SP
	
	DROP PROCEDURE sp_GestionarUsuario;
	DROP PROCEDURE sp_GestionarOpcionDePago;
	DROP PROCEDURE sp_GestionarUnidadDeMedida;
	DROP PROCEDURE sp_GestionarCaja;
	DROP PROCEDURE sp_GestionarDepartamento;
	DROP PROCEDURE sp_GestionarProducto;

	*/

	-----------------------------------------------------------------------------------------------------SP_Gestionar_Usuario
IF OBJECT_ID('sp_GestionarUsuario') IS NOT NULL
	DROP PROCEDURE sp_GestionarUsuario;
GO
Create Procedure sp_GestionarUsuario(
	 @op			CHAR(1)
	,@IDUsuario		SMALLINT		 = NULL
	,@contraseña	VARCHAR(20)		 = NULL
	,@nombres		VARCHAR(30)		 = NULL
	,@apellidoPat	VARCHAR(30)		 = NULL
	,@apellidoMat	VARCHAR(30)		 = NULL
	,@CURP			CHAR(18)		 = NULL
	,@fechNac		DATE			 = NULL
	,@numNomina		CHAR(16)		 = NULL
	,@email			VARCHAR(30)		 = NULL
	,@esAdmin		BIT				 = NULL
	
	--Este sp tiene 3 opciones: I,E,D

	--I lo que hace es guardar todo menos la fecha que se ingresa, 
	--se guarda la fecha del servidor como la fecha de alta.

	--E Sobre escribe todos los datos modificables siendo estos:
	-- Contraseña, Numero nomina, fecha nacimiento

	--D Dar de baja logica al Administrador convirtiendo estatus de 1 a 0

	--S muestra un select de los Usuaros en base
)
AS
BEGIN
	DECLARE @hoy DATETIME;
		set @hoy = GETDATE();

		IF @op='I'
		BEGIN
			INSERT INTO Usuario(contraseña,nombres,apellidoPat,apellidoMat,CURP,fechNac,numNomina,email,fechaAlta,esAdmin)
				VALUES(@contraseña,@nombres,@apellidoPat,@apellidoMat,@CURP,@fechNac,@numNomina,@email,@hoy,@esAdmin);
		END

		IF @op='E'
		BEGIN
			UPDATE Usuario SET		
				 contraseña			  =ISNULL(@contraseña	,contraseña	 )
				,nombres			  =ISNULL(@nombres		,nombres	 )
				,apellidoPat		  =ISNULL(@apellidoPat	,apellidoPat )
				,apellidoMat		  =ISNULL(@apellidoMat	,apellidoMat )
				,CURP				  =ISNULL(@CURP			,CURP		 )
				,fechNac			  =ISNULL(@fechNac		,fechNac	 )
				,numNomina			  =ISNULL(@numNomina	,numNomina	 )
				,email				  =ISNULL(@email		,email		 )
			WHERE IDUsuario=@IDUsuario;	
		END

		IF @op='D'
		BEGIN
			UPDATE Usuario SET
			Estatus = 0
			WHERE IDUsuario=@IDUsuario;
		END

		IF @op='S'
		BEGIN
			SELECT	IDUsuario	
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
					from v_UsuariosActivos;
		END
END
GO
	-----------------------------------------------------------------------------------------------------SP_Gestionar_OPCION_DE_PAGO
IF OBJECT_ID('sp_GestionarOpcionDePago')IS NOT NULL
	DROP PROCEDURE sp_GestionarOpcionDePago;
GO
Create Procedure sp_GestionarOpcionDePago(
	@op						CHAR(1)
	,@IDOpcionDePago		TINYINT 			= NULL
	,@Nombre				VARCHAR(20)			= NULL

	--Este sp tiene 3 opciones: I,E,D
	--I lo que hace es guardar todo como se ingresa.

	--E Sobre escribe todos los datos modificables siendo estos:
	-- Nombre

	--D Dar de baja Fisica la opcionde pago.
)
AS
BEGIN
	
	IF @op='I'
	Begin
		INSERT INTO OpcionDePago(Nombre)
			VALUES(@Nombre);
	End

	IF @op='E'
	BEGIN
		UPDATE OpcionDePago SET
			Nombre = ISNULL(@Nombre,Nombre)
		WHERE IDOpcionDePago=@IDOpcionDePago;
	END

	IF @op='D'
		UPDATE OpcionDePago SET
			Estatus=0
		WHERE IDOpcionDePago=@IDOpcionDePago;

	IF @op ='S'
		SELECT IDOpcionDePago,Nombre From v_OpcionesDePagoActivas;
		
END
GO
	-----------------------------------------------------------------------------------------------------SP_Gestionar_UNIDAD_DE_MEDIDA
IF OBJECT_ID('sp_GestionarUnidadDeMedida') IS NOT NULL
	DROP PROCEDURE sp_GestionarUnidadDeMedida;
GO
Create Procedure sp_GestionarUnidadDeMedida(
	@op						CHAR(1)
	,@IDUnidadMedida		SMALLINT 	= NULL	
	,@Nombre				VARCHAR(20)	= NULL
	,@Descripcion			VARCHAR(30)	= NULL	

	--Este sp tiene 3 opciones: I,E,D
	--I lo que hace es guardar todo como se ingresa.

	--E Sobre escribe todos los datos modificables siendo estos:
	-- Nombre,Descripcion

	--D Dar de baja logica la unidad de medida.
)AS
BEGIN
	
	IF @op='I'
	BEGIN
		INSERT INTO UnidadDeMedida(Nombre,Descripcion)
			VALUES(@Nombre,@Descripcion)
	END

	IF @op ='E'
	BEGIN
		UPDATE UnidadDeMedida SET
			Nombre	=ISNULL(@Nombre,Nombre)
			,Descripcion	=ISNULL(@Descripcion,Descripcion)
		WHERE IDUnidadDeMedida=@IDUnidadMedida;
	END

	IF @op='D'
		UPDATE UnidadDeMedida SET
			Estatus =0
		WHERE	IDUnidadDeMedida=@IDUnidadMedida;

	IF @op= 'S'
		SELECT	IDUnidadDeMedida,Nombre,Descripcion from v_UnidadDeMedidasActivas;
END			  
GO
---------------------------------------------------------------------------------------------------------SP_Gestionar_CAJA
IF OBJECT_ID('sp_GestionarCaja')IS NOT NULL
	DROP PROCEDURE sp_GestionarCaja;
GO
Create Procedure sp_GestionarCaja(

	@op				CHAR(1)
	,@IDCaja		TINYINT = NULL
	,@Disponible	bit		=NULL

	--Este sp tiene 2 opciones: I,D
	--I lo que hace es guardar todo como se ingresa.

	--D Dar de baja logica la caja.
)
AS
BEGIN
	IF @op= 'I'
	BEGIN
		INSERT INTO Caja
			DEFAULT VALUES;
	END

	IF @op='e'
	Update Caja set
			Disponible =ISNULL(@Disponible,0)
			where IDCaja=@IDCaja;


	IF @op='S'
	SELECT IDCaja,Disponible FROM Caja where Activa=1;

	if @op='l'
	select idcaja, disponible from caja where Disponible =1;



END
GO
---------------------------------------------------------------------------------------------------------SP_Gestionar_Tienda
IF OBJECT_ID('sp_GestionarTienda')IS NOT NULL
	DROP PROCEDURE sp_GestionarTienda;
GO
Create Procedure sp_GestionarTienda(

	 @op				CHAR(1)
	,@NombreTienda		Varchar(30)		=NULL
	,@Sucursal			tinyint			=NULL
	,@RFC				CHAR(13)		=NULL
	,@Domicilio			VARCHAR(100)	=NULL
	,@CodigoPostal		CHAR(6)			=NULL
	,@email				VARCHAR(40)		=NULL
	,@numTel			CHAR(10)		=NULL

	--Este sp tiene 2 opciones: I,D
	--I lo que hace es guardar todo como se ingresa.

	--E Edita los valores editables que son 
)
AS
BEGIN
	IF @op= 'I'
	BEGIN
		INSERT INTO DatosDeTienda(
		NombreTienda	
		,Sucursal		
		,RFC			
		,Domicilio		
		,CodigoPostal	
		,email			
		,numTel			
		)
		VALUES (	
		@NombreTienda	
		,@Sucursal		
		,@RFC			
		,@Domicilio		
		,@CodigoPostal	
		,@email			
		,@numTel			
		)
	END

	IF @op='E'
		UPDATE DatosDeTienda SET
			NombreTienda	=ISNULL(@NombreTienda,NombreTienda)
			,Sucursal		=ISNULL(@Sucursal,Sucursal)
			,RFC			=ISNULL(@RFC,RFC)
			,Domicilio		=ISNULL(@Domicilio,Domicilio)
			,CodigoPostal	=ISNULL(@CodigoPostal,CodigoPostal)
			,email			=ISNULL(@email,email)
			,numTel			=ISNULL(@numTel,numTel)

	IF @op='S'
	SELECT NombreTienda,Sucursal,RFC,Domicilio,CodigoPostal,email,numTel FROM DatosDeTienda;

END
GO
---------------------------------------------------------------------------------------------------------SP_Gestionar_DEPARTAMENTO
IF OBJECT_ID('sp_GestionarDepartamento')IS NOT NULL
	DROP PROCEDURE sp_GestionarDepartamento;
GO
Create Procedure sp_GestionarDepartamento(
	@op					CHAR
	,@IDDepartamento	SMALLINT			=NULL
	,@nombreDept		VARCHAR(30)			=NULL
	,@Reembolsable		BIT					=NULL

	--Este sp tiene 2 opciones: I,E,D
	--I lo que hace es guardar todo como se ingresa.
	
	--E Sobre escribe todos los datos modificables siendo estos:
	--Nombre, Reembolsable

	--D Elimina de forma logica haciendo estatus = 0
)
AS
BEGIN
	IF @op='I'
	BEGIN
		INSERT INTO Departamento(nombreDept,Reembolsable)
		VALUES(@nombreDept,@Reembolsable)
	END

	IF @op='E'
	BEGIN
		UPDATE Departamento SET
		nombreDept			=ISNULL(@nombreDept,nombreDept)
		,Reembolsable		=ISNULL(@Reembolsable,Reembolsable)
		WHERE @IDDepartamento=IDDepartamento;
	END

	--Recuerda agregar una validacion para eliminar departamentos que no tengan productos activos 
	--SELECT para contar cantidad de productos que pertenecen a cierto departamento 
	--SELECT  COUNT(b.IDProducto) FROM Departamento A INNER JOIN Producto B ON A.IDDepartamento = B.DepartamentoFK
	IF @op='D' 
	BEGIN
		UPDATE Departamento SET
		 Estatus=0
		 WHERE @IDDepartamento= IDDEpartamento;

		 UPDATE Producto SET
			Estatus =0
			Where @IDDepartamento=DepartamentoFK;
	END

	IF @op='S'
	BEGIN
		SELECT IDDepartamento,nombreDept,Reembolsable FROM Departamento where Estatus=1;
	END
END
GO
---------------------------------------------------------------------------------------------------------SP_Gestionar_PRODUCTO
IF OBJECT_ID('sp_GestionarProducto')IS NOT NULL
	DROP PROCEDURE sp_GestionarProducto;
GO
Create Procedure sp_GestionarProducto(
	 @op					CHAR			
	,@IDProducto			INT			  	 =NULL
	,@Nombre				VARCHAR(30)	  	 =NULL
	,@Descripcion			VARCHAR(50)	  	 =NULL
	,@Costo					SMALLMONEY	  	 =NULL
	,@PrecioUnitario		SMALLMONEY		 =NULL
	,@Existencias			DECIMAL (7,3)	 =NULL
	,@PuntoDeReorden		DECIMAL (7,3)	 =NULL
	,@DepartamentoFK		SMALLINT		 =NULL
	,@UnidadMedidaFK		SMALLINT		 =NULL
	
	--Este sp tiene 2 opciones: I,i,E,D
	--i lo que hace es guardar todo como se ingresa.

	--I lo que hace es guardar todo menos la fecha que se ingresa, 
	--se guarda la fecha del servidor como la fecha de alta.
	
	--E Sobre escribe todos los datos modificables siendo estos:
	--Nombre,descripcion,costo,precio unitario, existencias, punto de reorden, departamento y unidad de medida

	--D Elimina de forma logica haciendo estatus = 0
)
AS
BEGIN
	DECLARE @hoy DATETIME;
		set @hoy = GETDATE();
		IF @op='I'
	BEGIN
		INSERT INTO Producto(
				Nombre		
				,Descripcion	
				,Costo			
				,PrecioUnitario
				,FechaAlta		
				,Existencias	
				,PuntoDeReorden	
				,DepartamentoFK
				,UnidadMedidaFK
				)
		VALUES(
				@Nombre		
				,@Descripcion	
				,@Costo			
				,@PrecioUnitario
				,@hoy		
				,@Existencias	
				,@PuntoDeReorden		
				,@DepartamentoFK
				,@UnidadMedidaFK)
	END
	IF @op='E'
	BEGIN
		UPDATE Producto SET
		Nombre			=ISNULL  (@Nombre,	Nombre)
		,Descripcion	=ISNULL  (@Descripcion,Descripcion)
		,Costo			=ISNULL  (@Costo,Costo)
		,PrecioUnitario	=ISNULL  (@PrecioUnitario,PrecioUnitario)
		,Existencias	=ISNULL  (@Existencias	  ,Existencias	 )
		,PuntoDeReorden	=ISNULL	 (@PuntoDeReorden ,PuntoDeReorden)
		,DepartamentoFK	=ISNULL	 (@DepartamentoFK ,DepartamentoFK)
		,UnidadMedidaFK	=ISNULL	 (@UnidadMedidaFK ,UnidadMedidaFK)
		WHERE @IDProducto=IDProducto;
	END

	--Recuerda agregar una validacion para eliminar departamentos que no tengan productos activos 
	--SELECT para contar cantidad de productos que pertenecen a cierto departamento 
	--SELECT  COUNT(b.IDProducto) FROM Departamento A INNER JOIN Producto B ON A.IDDepartamento = B.DepartamentoFK
	IF @op='D' 
	BEGIN
		UPDATE Producto SET
		 Estatus=0
		 WHERE @IDProducto=IDProducto;
	END

	IF @op='S'
		--SELECT p.IDProducto,p.Nombre,p.Descripcion,p.Costo,p.PrecioUnitario,p.FechaAlta,p.Existencias,p.PuntoDeReorden,D.nombreDept [Departamento],Ue.Nombre[Unidad De Medida] From Producto AS P LEFT JOIN Departamento AS D ON P.DepartamentoFK=D.IDDepartamento LEFT JOIN UnidadDeMedida AS UE ON P.UnidadMedidaFK=UE.IDUnidadDeMedida  Where p.Estatus=1;
		SELECT p.IDProducto,p.Nombre,p.Descripcion,p.Costo,p.PrecioUnitario,p.FechaAlta,p.Existencias,p.PuntoDeReorden,p.DepartamentoFK,p.UnidadMedidaFK from Producto as P LEFT JOIN Departamento AS D on p.DepartamentoFK= d.IDDepartamento Where p.Estatus=1 AND d.Estatus=1;
END
GO
--------------------------------------------------------------------------------------------------------SP_GESTIONAR_INVENTARIO
--IF OBJECT_ID('sp_GestionarInventario')IS NOT NULL
--	DROP PROCEDURE sp_GestionarInventario;
--GO
--Create Procedure sp_GestionarInventario(
--	 @op					CHAR			
--	,@DepartamentoID        SMALLINT         =NULL
--	,@cantMin               DECIMAL (7,3)    =NULL
--	,@agotados              BIT              =NULL
--	,@merma                 BIT              =NULL
	
	--Este sp tiene 2 opciones: I,i,E,D
	--i lo que hace es guardar todo como se ingresa.

	--I lo que hace es guardar todo menos la fecha que se ingresa, 
	--se guarda la fecha del servidor como la fecha de alta.
	
	--E Sobre escribe todos los datos modificables siendo estos:
	--Nombre,descripcion,costo,precio unitario, existencias, punto de reorden, departamento y unidad de medida

	--D Elimina de forma logica haciendo estatus = 0
--)
--AS
--BEGIN
--	IF @op='S'
		--SELECT p.IDProducto,p.Nombre,p.Descripcion,p.Costo,p.PrecioUnitario,p.FechaAlta,p.Existencias,p.PuntoDeReorden,D.nombreDept [Departamento],Ue.Nombre[Unidad De Medida] From Producto AS P LEFT JOIN Departamento AS D ON P.DepartamentoFK=D.IDDepartamento LEFT JOIN UnidadDeMedida AS UE ON P.UnidadMedidaFK=UE.IDUnidadDeMedida  Where p.Estatus=1;
--		SELECT p.IDProducto,
--				p.Nombre,
--				p.Descripcion,
--				p.Costo,
--				p.PrecioUnitario,
--				p.FechaAlta,
--				p.Existencias,
--				p.PuntoDeReorden,
--				p.DepartamentoFK,
--				p.UnidadMedidaFK 
--		from Producto as P 
--		LEFT JOIN Departamento AS D on p.DepartamentoFK= d.IDDepartamento 
--		LEFT JOIN
--		LEFT JOIN
--		LEFT JOIN
--		Where p.Estatus=1 AND d.Estatus=1;

--END
--GO











-----------------------------------------------------------SP_INSERTAR_DESCUENTO
IF OBJECT_ID('sp_GestionarDescuento')IS NOT NULL
	DROP PROCEDURE sp_GestionarDescuento;
GO
Create Procedure sp_GestionarDescuento(
										 @op					CHAR
										,@IDDescuento			INT				=NULL  
										,@Nombre 				VARCHAR(20)	  	=NULL
										,@Porcentaje			TINYINT		  	=NULL
										,@FechaINI				DATE		  	=NULL
										,@FechaFIN				DATE			=NULL
										,@ProductoFK			INT				=NULL
	
	--Este sp tiene 3 opciones: I,E,D

	--I lo que hace es guardar todo menos la fecha que se ingresa, 
	--se guarda la fecha del servidor como la fecha de alta.
	
	--E Sobre escribe todos los datos modificables siendo estos:
	--Nombre, porcentaje, fecha inicial, fecha final, llave foranea de producto

	--D Elimina de forma logica haciendo estatus = 0
)
AS
BEGIN
	DECLARE @hoy DATETIME;
		set @hoy = GETDATE();

		IF @op='I'
	BEGIN
		INSERT INTO Descuento(
				 Nombre 	
				,Porcentaje
				,FechaINI	
				,FechaFIN	
				,ProductoFK
				)
		VALUES(
				@Nombre 	
				,@Porcentaje
				,@FechaINI	
				,@FechaFIN	
				,@ProductoFK
				)
	END

	IF @op='E'
	BEGIN
		UPDATE Descuento SET
		 Nombre		=ISNULL  (@Nombre			,	Nombre)
		,Porcentaje	=ISNULL  (@Porcentaje		,	Porcentaje)
		,FechaINI	=ISNULL  (@FechaINI			,	FechaINI)
		,FechaFIN	=ISNULL  (@FechaFIN			,	FechaFIN)
		,ProductoFK	=ISNULL  (@ProductoFK		,	ProductoFK)

		WHERE @IDDescuento=IDDescuento;
	END

	IF @op='D' 
	BEGIN
		UPDATE Descuento SET
		 Estado=0
		 WHERE @IDDescuento=IDDescuento;
	END


	IF @op='S'
	--SELECT IDDescuento,D.Nombre [Descuento],Porcentaje,FechaINI,FechaFIN,P.Nombre [Producto] FROM Descuento AS D LEFT JOIN Producto AS p ON d.ProductoFK=P.IDProducto WHere Estado=1; 
	SELECT D.IDDescuento,D.Nombre,D.Porcentaje,D.FechaINI,D.FechaFIN,D.ProductoFK from Descuento AS D LEFT JOIN Producto AS P ON D.ProductoFK=P.IDProducto WHERE D.Estado =1 AND P.Estatus=1;
END
GO
---------------------------------------------------------------------------------------------------------SP_GET_COUNT
IF OBJECT_ID('sp_GetCountTable')IS NOT NULL
	DROP PROCEDURE sp_GetCountTable;
GO
Create procedure sp_GetCountTable(
		@op CHAR(4)
)AS
BEGIN
	IF @op='USER'
					SELECT COUNT(IDUsuario)			[COUNT] FROM Usuario;
	IF @op ='CAJA'									 
					SELECT COUNT(IDCaja)			[COUNT] FROM Caja ;
	IF @op='DPTO'									
					SELECT COUNT(IDDepartamento)	[COUNT] FROM Departamento ;
	IF @op='PROD'									 
					SELECT COUNT(IDProducto)		[COUNT] FROM Producto ;
	IF @op='DESC'									
					SELECT COUNT(IDDescuento)		[COUNT] FROM Descuento ;
	IF @op='RECV'									 
					SELECT COUNT(IDRecibo)			[COUNT] FROM ReciboDeVenta;
	IF @op='UNME'									 
					SELECT COUNT(IDUnidadDeMedida)	[COUNT] FROM UnidadDeMedida ;
	IF @op='OPPA'									 
					SELECT COUNT(IDOpcionDePago)	[COUNT] FROM OpcionDePago ;
	IF @op='NTCR'									 
					SELECT COUNT(IDNotaCredito)		[COUNT] FROM NotaCredito;
END
GO
---------------------------------------------------------------------------------------------------------SP_LoginCajaCajero
IF OBJECT_ID('sp_LoginCajeroACaja')IS NOT NULL
	DROP PROCEDURE sp_LoginCajeroACaja;
GO
Create procedure sp_LoginCajeroACaja(	@op		char(1),
										@UsuarioFK	smallint=null,
										@CajaFk		tinyint =null,
										@fecha		datetime=null
)AS
BEGIN
	if @op='i'
	Insert into Usuario_Caja(CajeroFK,CajaFK,Fecha) Values(@UsuarioFK,@CajaFk,@fecha);
	select IDCajero_Caja ,CajeroFK,CajaFK,fecha from Usuario_Caja where IDCajero_Caja=@@IDENTITY;

	if @op = 'l'
	select IDCajero_Caja ,CajeroFK,CajaFK,Fecha from Usuario_Caja where IDCajero_Caja=@@IDENTITY;

	if @op = 'i'
	select IDCajero_Caja ,CajeroFK,CajaFK from Usuario_Caja;
END
GO
---------------------------------------------------------------------------------------------------------SP_ProductosEnPuntoDeReorden
IF OBJECT_ID('sp_GetProductosEnPuntoDeReorden')IS NOT NULL
	DROP PROCEDURE sp_GetProductosEnPuntoDeReorden;
GO
Create PROCEDURE sp_GetProductosEnPuntoDeReorden(@op char(1)=NULL)
AS
BEGIN	
	IF EXISTS (Select IDProducto from v_Productos where Existencias<=PuntoDeReorden)
		Select IDProducto,Nombre, Descripcion,Existencias,PuntoDeReorden[Punto de Reorden],Departamento,[Unidad De Medida] from v_Productos where Existencias<=PuntoDeReorden;
	Else
		SELECT 'No hay ningun Producto en punto de reorden'[Mensaje]
END
GO
--------------------------------------------------------------------------------------------------------SP_BusquedaRapida
IF OBJECT_ID('sp_BusquedaRapida')IS NOT NULL
	DROP PROCEDURE sp_BusquedaRapida;
GO
Create Procedure sp_BusquedaRapida( @op Char(1)
									,@IDProducto INT=NULL
									,@Nombre VARCHAR(30)=NULL
)
AS
BEGIN
	if @op='N'
	--DECLARE @nombre varchar(30);
	--SET @Nombre ='cong'
		SELECT IDProducto,Nombre,Costo,Departamento,[Unidad De Medida] from v_Productos where Nombre like CONCAT('%',@Nombre,'%');

	if @op='C'
	--DECLARE @idproducto int
	--SET @idproducto= 2
		SELECT IDProducto,Nombre,Costo,Departamento,[Unidad De Medida] from v_Productos where IDProducto like CONCAT('%',@IDProducto,'%');
END
GO
--------------------------------------------------------------------------------------------------------SP_GestionarReciboVenta
IF OBJECT_ID('sp_GestionarReciboDeVenta')IS NOT NULL
	Drop procedure sp_GestionarReciboDeVenta;
GO
Create procedure sp_GestionarReciboDeVenta(  @op char(1)
											,@idrecibo int =null
											,@Total smallmoney	   =NULL
											,@SubTotal smallmoney   =NULL
										
)AS
BEGIN
	IF @op= 'i'
	begin
		Insert into ReciboDeVenta(Total,Subtotal) VALUES (@Total,@SubTotal)
		Select IDRecibo,Total,Subtotal from ReciboDeVenta where  idrecibo = @@IDENTITY;
	end

	IF @op='s'
		Select IDRecibo,Total,Subtotal from ReciboDeVenta where IDRecibo =@idrecibo;
END
GO
-------------------------------------------------------------------------------------------------------SP_GestionarDetalleDePago
IF OBJECT_ID('SP_GestionarDetalleDePago')IS NOT NULL
	Drop procedure SP_GestionarDetalleDePago;
GO
Create procedure SP_GestionarDetalleDePago(@op char(1)
											,@FKReciboVenta int			 =NULL
											,@FkOpcionDePago tinyint	 =NULL
											,@CantidadAPagar smallmoney	 =NULL
)AS
BEGIN
	IF @op= 'i'
		Insert into DetallePago(FkRecVenta,FKOpPago,Cantidad) VALUES (@FKReciboVenta,@FkOpcionDePago,@CantidadAPagar);

	IF @op='s'
		Select IDDetallePago,FkRecVenta,FkRecVenta,Cantidad  from DetallePago;
END
GO
-------------------------------------------------------------------------------------------------------SP_GestionarDetalleProductos
IF OBJECT_ID('SP_GestionarDetalleProductos')IS NOT NULL
	Drop procedure SP_GestionarDetalleProductos;
GO
Create procedure SP_GestionarDetalleProductos(@op char(1)
											,@FKReciboVenta int					=NULL
											,@FkProducto int					=NULL
											,@CantidadDeProducto DEcimal(7,3)	=NULL
)AS
BEGIN
	declare @completed bit;

	IF @op= 'i'
	begin
		Insert into DetalleProductos(ReciboVentaFK,ProductoFK,CantProd) VALUES (@FKReciboVenta,@FkProducto,@CantidadDeProducto);
		update Producto set Existencias = Existencias-@CantidadDeProducto where Producto.IDProducto=@FkProducto;
	end
	IF @op='s'
		Select IDRecVent_Prod,ReciboVentaFK,ProductoFK,CantProd  from DetalleProductos;
END
GO
--------------------------------------------------------------------------------------------------------SP_GestionarVentas
IF OBJECT_ID('SP_GestionarVentas')IS NOT NULL
	Drop procedure SP_GestionarVentas;
GO
Create procedure SP_GestionarVentas(		@op char(1)
											,@FKReciboVenta		int			=NULL
											,@CajeroLoginFK 	int			=NULL
											,@ReciboVentaFK		int			=null
											,@Fecha				datetime	=NULL

)AS
BEGIN

	IF @op= 'i'
	begin
		Insert into LogVenta(Cajero_CajaFK,ReciboVentaFK,Fecha) VALUES (@CajeroLoginFK,@ReciboVentaFK,@Fecha);
	end

	IF @op='s'
		Select  IDLogVenta,Cajero_CajaFK,ReciboVentaFK,Fecha from LogVenta;

END
GO
--------------------------------------------------------------------------------------------------------SP_BuscarProductoEnRecibo
IF OBJECT_ID('SP_BuscarProductoEnRecibo')IS NOT NULL
	DROP PROCEDURE SP_BuscarProductoEnRecibo;
GO
Create Procedure SP_BuscarProductoEnRecibo( @op Char(1))
AS
BEGIN
	if @op='s'
		SELECT 
			[Numero de recibo]   as IDRecibo,
			[Codigo de Producto] as ProductoFK,
			[Nombre de Producto] as NombreProd,
			[Cantidad en recibo] as CantProd,
			[Reembolsable]		 as Reembolsable
		from v_BuscarProductoEnRecibo
END
GO
---------------------------------------------------------------------------------------------------------SP_Gestionar_NotaDeCredito
IF OBJECT_ID('sp_GestionarNotaDeCredito')IS NOT NULL
	DROP PROCEDURE sp_GestionarNotaDeCredito;
GO
Create procedure sp_GestionarNotaDeCredito(	@op char(1)
											,@Total		smallmoney	=NULL
											,@SubTotal	smallmoney  =NULL
											,@ReciboFK	int			=NULL
											)
AS
BEGIN
	if @op='i'
	BEGIN
		Insert into NotaCredito(Cantidad,Subtotal,NumReciboFK) VALUES (@Total,@SubTotal,@ReciboFK)
		Select IDNotaCredito,Cantidad,Subtotal,NumReciboFK from NotaCredito where  [IDNotaCredito] = @@IDENTITY;
	END
END
GO
--------------------------------------------------------------------------------------------------------SP_Gestionar_Devolucion
IF OBJECT_ID('sp_GestionarDevolucion')IS NOT NULL
	DROP PROCEDURE sp_GestionarDevolucion;
GO
Create procedure sp_GestionarDevolucion(	@op char(1),
											@ProductoFK int		= NULL,
											@cantidad decimal	= NULL,
											@merma bit			=null
											)
AS
BEGIN
	if @op='i'
	BEGIN
		Insert into Devolucion(Cantidad,Merma,ProductoFK) VALUES (@cantidad,@merma,@ProductoFK)
		Select IDDevolucion,Cantidad,Merma,ProductoFK from Devolucion where  IDDevolucion= @@IDENTITY;
		if @merma=0
			update Producto set Existencias = Existencias + @cantidad where IDProducto=@ProductoFK;
	END
END
GO
--------------------------------------------------------------------------------------------------------SP_Header_NotaCreditoYDevolucion
IF OBJECT_ID('Sp_Header_NotaCreditoYDevolucion')IS NOT NULL
	DROP PROCEDURE Sp_Header_NotaCreditoYDevolucion;
GO
Create procedure Sp_Header_NotaCreditoYDevolucion(	@op char(1),@IDNotaCred_Devol int=NULL,	@notaCreditoFK int	 = NULL,@Devolucion int		 = NULL,@fecha Smalldatetime = NULL	)
AS
BEGIN
	if @op='i'
	BEGIN
		Insert into NotaCred_Devol(NotaCreditoFK,DevolucionFK,Fecha) VALUES (@notaCreditoFK,@Devolucion,@fecha)
		Select IDNotaCred_Devol,NotaCreditoFK,DevolucionFK,Fecha from NotaCred_Devol where  IDNotaCred_Devol= @@IDENTITY;
	END
	if @op='s'
		Select				
			[Numero De Nota De Credito] as IDNotaCred_Devol,
			[Recibo De Compra]			as NotaCreditoFK,
			[Codigo del Producto]		as DevolucionFK,
			[FechaDDvolucion]						as Fecha
		from v_NotaCreditoYDevol where @notaCreditoFK = [Recibo De Compra];
END	
GO	

--------------------------------------------------------------------------------------------------------Sp_ReporteDeVentas
IF OBJECT_ID('sp_ConsultaRecibos')IS NOT NULL
	DROP PROCEDURE sp_ConsultaRecibos;
GO
Create Procedure sp_ConsultaRecibos( @op Char(1)
									,@IDRecibo INT			=NULL
									,@fecha smalldatetime	=NULL
									,@IdCaja tinyint		=NULL
									
)
AS
BEGIN
	if @op='N'
	BEGIN
		IF EXISTS (Select [Numero de recibo] from v_ReciboDeVenta where [Numero de recibo] = @IDRecibo)
			Select 
				[Numero de recibo],
				MAX([Nombre del cajero])				as [Nombre del cajero],
				MAX([Fecha de Venta])					as [Fecha de Venta],
				MAX([Caja de la venta])					as [Caja de la Venta],
				COUNT(Distinct[Cantidad de productos])	as [Productos en recibo],
				COUNT([Opcion de pago])					as [Opciones de pago],
				MAX([Subtotal])							as [Subtotal de Recibo],
				MAX([Total])							as [Total de Recibo]
			from 
				v_ReciboDeVenta as Recibo 
			where 
				[Numero de recibo] = @IDRecibo
			group by [Numero de recibo];
		Else
			SELECT 'No hay Recibos con ese Numero de Recibo'[Mensaje];
	END

	if @op='D'
	BEGIN
	
		IF EXISTS (Select [Numero de recibo] from v_ReciboDeVenta where cast(v_ReciboDeVenta.[Fecha de Venta] as smalldatetime) =@fecha )

	--declare @fecha datetime
	--declare @IdCaja tinyint
	--set @IdCaja =1
	--set @fecha= GETDATE();
		IF EXISTS (Select [Numero de recibo] from v_ReciboDeVenta where cast(v_ReciboDeVenta.FechaDVenta as date) = cast(@fecha as date) AND [Caja de la venta]=@IdCaja )
			Select 
				[Numero de recibo],
				MAX([Nombre del cajero])				as [Nombre del cajero],
				MAX([Fecha de Venta])					as [Fecha de Venta],
				MAX([Caja de la venta])					as [Caja de la Venta],
				COUNT(Distinct[Cantidad de productos])	as [Productos en recibo],
				COUNT([Opcion de pago])					as [Opciones de pago],
				MAX([Subtotal])							as [Subtotal de Recibo],
				MAX([Total])							as [Total de Recibo]
			from 
				v_ReciboDeVenta as Recibo 
			where 
				CAst([Fecha de Venta]  as date) = cast(@fecha as date) AND [Caja de la venta]=@IdCaja
			group by [Numero de recibo];
		Else
			SELECT 'No hay Recibos con ese Numero de Recibo'[Mensaje];
		
	END

END
GO

IF OBJECT_ID('sp_ConsultaNotasDeCredito')IS NOT NULL
	DROP PROCEDURE sp_ConsultaNotasDeCredito;
GO
Create Procedure sp_ConsultaNotasDeCredito( @op Char(1)
											,@IDNotaCredito INT		=NULL
											,@fecha smalldatetime	=NULL
											,@IdCaja tinyint		=NULL
									
)
AS
BEGIN
	if @op='N'
	BEGIN
	--declare @IDNotaCredito INT	
	--set @IDNotaCredito =1000000
		IF EXISTS (Select [Numero De Nota De Credito] from v_NotaCreditoYDevol where [Numero De Nota De Credito] = @IDNotaCredito)
			Select 
				[Numero De Nota De Credito],
				MAX([Fecha de devolucion])				as [Fecha de Devolucion],
				MAX(Distinct [Producto Devuelto])		as [Producto regresado],
				MAX([Cantidad de Productos devueltos])  as [Cantidad de Productos devueltos],
				MAX([Subtotal del Recibo])				as [Subtotal de Nota],
				MAX([Total del Recibo])					as [Total de Nota]
			from 
				v_NotaCreditoYDevol as NotaCreditoYDevolucion 
			where 
				[Numero De Nota De Credito] = @IDNotaCredito
			group by [Numero De Nota De Credito];
		Else
			SELECT 'No hay notas con ese Numero de nota'[Mensaje];
	END
	if @op='D'
	BEGIN
		--declare @fecha datetime
		--declare @IdCaja tinyint
		--set @IdCaja =1
		--set @fecha= GETDATE();
	 		IF EXISTS (Select [Numero De Nota De Credito] from v_NotaCreditoYDevol where cast([FechaDDvolucion] as date) = cast(@fecha as date))
			Select 
				[Numero De Nota De Credito],
				MAX([Fecha de devolucion])				as [Fecha de Devolucion],
				MAX(Distinct [Producto Devuelto])		as [Producto regresado],
				MAX([Cantidad de Productos devueltos])  as [Cantidad de Productos devueltos],
				MAX([Subtotal del Recibo])				as [Subtotal de Nota],
				MAX([Total del Recibo])					as [Total de Nota]
			from 
				v_NotaCreditoYDevol as NotaCreditoYDevolucion 
			where 
				cast([FechaDDvolucion] as date) = cast(@fecha as date)
			group by [Numero De Nota De Credito];
		Else
			SELECT 'No hay notas en esa fecha'[Mensaje];
	END

END
GO

------------------------------------------------------------------------------------------------------SP_Inventario
IF OBJECT_ID('sp_inventario')IS NOT NULL
	DROP PROCEDURE sp_inventario;
GO
Create Procedure sp_inventario( @op Char(1)
											,@IDNotaCredito INT		=NULL
											,@fecha smalldatetime	=NULL
											,@IdCaja tinyint		=NULL
									
)
AS
BEGIN
 if @op='s'
 select
	 Departamento,
	 Producto,
	 [Unidad de Medida],
	 Costo,
	 [Precio Unitario],
	 Existencias,
	 [Unidades Vendidas],
	 Merma	
	 from v_Inventario;
END
GO
select * from LogVenta;
select * from ReciboDeVenta;
select * from DetalleProductos;
select * from DetallePago;