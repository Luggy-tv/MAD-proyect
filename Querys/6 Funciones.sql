IF DB_ID(N'Tienda01')IS NOT NULL
	USE Tienda01;
GO

IF OBJECT_ID('fn_UsuarioExists') IS NOT NULL
	DROP Function fn_UsuarioExists;
GO
CREATE FUNCTION fn_UsuarioExists(@IDUsuario SMALLINT)
RETURNS BIT
BEGIN
	Declare @res bit;
	IF EXISTS ( SELECT 1 FROM Usuario WHERE IDUsuario= @IDUsuario )
	BEGIN
		SET @res=1;
	END
	ELSE
		SET @res=0;

	Return @res;
END
GO

IF OBJECT_ID('fn_UsuarioIsAdmin')IS NOT NULL
	Drop Function fn_UsuarioIsAdmin;
GO
Create function fn_UsuarioIsAdmin(@IDUsuario smallint)
returns bit
begin
	Declare @res bit;
	set @res= (Select esAdmin from Usuario where IDUsuario=@IDUsuario)
	return @res;
end