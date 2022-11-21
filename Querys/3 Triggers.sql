USE Tienda01

IF OBJECT_ID('t_UpdateDepartamento') IS NOT NULL
	DROP TRIGGER t_UpdateDepartamento;
GO
CREATE TRIGGER t_UpdateDepartamento
ON dbo.Departamento
FOR UPDATE
AS
IF(UPDATE(Estatus))
BEGIN
	SET NOCOUNT ON;
		UPDATE P SET P.Estatus=0 FROM Producto AS P LEFT JOIN inserted AS D ON P.DepartamentoFK=D.IDDepartamento WHERE p.DepartamentoFK=d.IDDepartamento;
	SET NOCOUNT OFF;
END

IF OBJECT_ID('t_UpdateProducto') IS NOT NULL
	DROP TRIGGER t_UpdateProducto;
GO
CREATE TRIGGER t_UpdateProducto
ON dbo.Producto
FOR UPDATE
AS
IF(UPDATE(Estatus))
BEGIN
	SET NOCOUNT ON;
		UPDATE Descuento SET Estado=0 FROM Descuento AS DE LEFT JOIN inserted AS PR ON DE.ProductoFK=PR.IDProducto WHERE DE.ProductoFK=PR.IDProducto;
	SET NOCOUNT OFF;
END


