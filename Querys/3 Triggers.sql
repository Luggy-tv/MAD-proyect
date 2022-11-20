USE Tienda01

IF OBJECT_ID('t_TriggerUDepartamento') IS NOT NULL
	DROP TRIGGER t_TriggerUDepartamento;
GO
CREATE TRIGGER t_TriggerUDepartamento
ON dbo.Departamento
FOR UPDATE
AS
IF(UPDATE(Estatus))
BEGIN
	SET NOCOUNT ON;
		UPDATE P SET P.Estatus=0 FROM Producto AS P LEFT JOIN inserted AS D ON P.DepartamentoFK=D.IDDepartamento WHERE p.DepartamentoFK=d.IDDepartamento;
	SET NOCOUNT OFF;
END

IF OBJECT_ID('t_TriggerUProducto') IS NOT NULL
	DROP TRIGGER t_TriggerUProducto;
GO
CREATE TRIGGER t_TriggerUProducto
ON dbo.Producto
FOR UPDATE
AS
IF(UPDATE(Estatus))
BEGIN
	SET NOCOUNT ON;
		UPDATE Descuento SET Estado=0 FROM Descuento AS DE LEFT JOIN inserted AS PR ON DE.ProductoFK=PR.IDProducto WHERE DE.ProductoFK=PR.IDProducto;
	SET NOCOUNT OFF;
END


