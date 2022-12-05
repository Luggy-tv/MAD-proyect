IF DB_ID(N'Tienda01')IS NOT NULL
	USE Tienda01;
GO

if object_id('dbo.fn_GetProductDiscount') is not null
	drop function dbo.fn_GetProductDiscount;
GO
Create function dbo.fn_GetProductDiscount(@PrecioProducto decimal, @PorcentajeDescuento tinyint)
returns decimal
begin
	RETURN @PrecioProducto*@PorcentajeDescuento*0.01;
end
GO