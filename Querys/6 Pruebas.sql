USE Tienda01;

EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Cheque';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Efectivo';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Tarjeta de Credito';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Tarjeta de Debito';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Vale de Despensa';

EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Kilo',@Descripcion ='Unidad de masa del sistema internacional.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Gramo',@Descripcion ='Unidad de masa, milésima parte de un kilogramo.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Miligramo',@Descripcion ='Unidad de masa, milesima parte de un gramo.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Litro',@Descripcion ='Unidad de volumen del Sistema Internacional,ue equivale a 1 decímetro cúbico.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Mililitro',@Descripcion ='Unidad de volumen, la milésima parte de un litro.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=1000,@nombre='Pieza',@Descripcion ='Ejemplos: 1pza de platano, 1pza de pan (Enteros).'

EXEC sp_GestionarTienda  @op='s',@NombreTienda	='Tienda Velponch',@Sucursal= 3,@RFC='MAML000123UK7',@Domicilio='Tucson 261 Cumbres san agustin',@CodigoPostal	='64346',@email	='ponchvel@mail.com',@numTel='8183060619'

EXEC sp_GestionarCaja @op='i';
EXEC sp_GestionarCaja @op='i';
EXEC sp_GestionarCaja @op='i';

--yyyy-mm-dd

 sp_GestionarDescuento	 @op			= 'i'
						,@IDDescuento	= 0
						,@Nombre 		= 'CocaCola_30'
						,@Porcentaje	= 30
						,@FechaINI		= '2022-11-20'
						,@FechaFIN		= '2022-12-1'
						,@ProductoFK	= 1000000;

sp_GestionarDescuento	 @op			= 'i'
						,@IDDescuento	= 0
						,@Nombre 		= 'pepsi_30'
						,@Porcentaje	= 30
						,@FechaINI		= '2022-11-20'
						,@FechaFIN		= '2022-12-1'
						,@ProductoFK	= 1000001;

sp_GestionarDescuento	 @op			= 'i'
						,@IDDescuento	= 0
						,@Nombre 		= 'Manzanas_30'
						,@Porcentaje	= 30
						,@FechaINI		= '2022-11-20'
						,@FechaFIN		= '2022-12-1'
						,@ProductoFK	= 1000002;