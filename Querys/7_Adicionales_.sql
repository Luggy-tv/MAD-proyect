USE Tienda01;

EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Cheque';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Efectivo';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Tarjeta de Credito';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Tarjeta de Debito';
EXEC sp_GestionarOpcionDePago  @op='i', @Nombre ='Vale de Despensa';

EXEC sp_GestionarUsuario @op='i',@IDUsuario	=10000 ,@contrase?a	='Marinas117', @nombres='Luis Alfonso', @apellidoPat='Martinez',@apellidoMat='Martinez',@CURP='MAML000123HNLRRSA7', @fechNac='2000-01-23', @numNomina='9364867774537734'		, @email='luis@mail.com'		, @esAdmin=1

EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=10,@nombre='Kilo',@Descripcion ='Unidad de masa del sistema internacional.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=11,@nombre='Gramo',@Descripcion ='Unidad de masa, mil?sima parte de un kilogramo.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=12,@nombre='Miligramo',@Descripcion ='Unidad de masa, milesima parte de un gramo.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=13,@nombre='Litro',@Descripcion ='Unidad de volumen del Sistema Internacional,ue equivale a 1 dec?metro c?bico.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=14,@nombre='Mililitro',@Descripcion ='Unidad de volumen, la mil?sima parte de un litro.'
EXEC sp_GestionarUnidadDeMedida @op ='i',@IDUnidadMedida=15,@nombre='Pieza',@Descripcion ='Ejemplos: 1pza de platano, 1pza de pan (Enteros).'

EXEC sp_GestionarTienda  @op='i',@NombreTienda	='Tienda Velponch',@Sucursal= 3,@RFC='MAML000123UK7',@Domicilio='Tucson 261 Cumbres san agustin',@CodigoPostal	='64346',@email	='ponchvel@mail.com',@numTel='8183060619'

EXEC sp_GestionarCaja @op='i';
EXEC sp_GestionarCaja @op='i';
EXEC sp_GestionarCaja @op='i';