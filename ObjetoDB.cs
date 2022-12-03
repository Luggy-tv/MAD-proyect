using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAD3_ventanas
{
	public class ObjetoDB
	{
		//Smallmoney es decimal
		//smalldatetime es datetime en c#

		public class CurrentLogin
        {
			public Int16 IDCajero_Caja { get; set; }
			public Int16 CajeroFK { get; set; }
			public byte CajaFK { get; set; }
			public DateTime fecha { get; set; }

        }
		public class DatosDeTienda
		{
			public byte IDTienda { get; set; }
			public string NombreTienda { get; set; }
			public byte Sucursal { get; set; }
			public string RFC { get; set; }
			public string Domicilio { get; set; }
			public string CodigoPostal { get; set; }
			public string email { get; set; }
			public string numTel { get; set; }
		}
		public class Departamento
		{
			public short IDDepartamento { get; set; }
			public string nombreDept { get; set; }
			public bool Reembolsable { get; set; }
		}
		public class Usuario
		{
			public short IDUsuario { get; set; }
			public string contraseña { get; set; }
			public string nombres { get; set; }
			public string apellidoPat { get; set; }
			public string apellidoMat { get; set; }
			public string CURP { get; set; }
			public DateTime fechNac { get; set; }
			public string numNomina { get; set; }
			public string email { get; set; }
			public DateTime fechaAlta { get; set; }
			public bool esAdmin { get; set; }
		}
		public class OpcionDePago
		{
			public byte IDOpcionDePago { get; set; }
			public string Nombre { get; set; }
		}
		public class UnidadDeMedida
		{
			public short IDUnidadDeMedida { get; set; }
			public string Nombre { get; set; }
			public string Descripcion { get; set; }
		}
		public class Caja
		{
			public byte IDCaja { get; set; }
			public bool Disponible { get; set; }
		}
		public class Descuento
		{
			public int		IDDescuento		{ get; set; }
			public string	Nombre		{ get; set; }
			public byte Porcentaje		{ get; set; }
			public DateTime FechaINI	{ get; set; }
			public DateTime FechaFIN	{ get; set; }
			public int ProductoFK		{ get; set; }
		}
		public class NotaCredito
		{
			public int IDNotaCredito { get; set; }
			public decimal Cantidad { get; set; }
			public decimal Subtotal { get; set; }
			public int NumReciboFK { get; set; }
		}
		public class ReciboDeVenta
		{
			//[Mapping(ColumnName = "IDRecibo")]
			public int IDRecibo { get; set; }
			//[Mapping(ColumnName = "Total")]
			public decimal Total { get; set; }
			//[Mapping(ColumnName = "Subtotal")]
			public decimal Subtotal { get; set; }
		}
		public class Devolucion
		{
			public int IDDevolucion { get; set; }
			public int ProductoFK { get; set; }
			public short Cantidad { get; set; }
			public bool Merma { get; set; }
		}
		public class DetalleProductos
		{
			public int IDRecVent_Prod { get; set; }
			public int ReciboVentaFK { get; set; }
			public int ProductoFK { get; set; }
			public decimal CantProd { get; set; }
		}
		public class Producto
		{
			public int IDProducto { get; set; }
			public string Nombre { get; set; }
			public string Descripcion { get; set; }
			public decimal Costo { get; set; }
			public decimal PrecioUnitario { get; set; }
			public DateTime FechaAlta { get; set; }
			public decimal Existencias { get; set; }
			public decimal PuntoDeReorden { get; set; }
			public short DepartamentoFK { get; set; }
			public short UnidadMedidaFK { get; set; }
		}
		public class ProductosEnVenta
        {
			public int IDProducto { get; set; }
			public string Nombre { get; set; }
			public decimal Costo { get; set; }
			public decimal Existencias { get; set; }
			public decimal CantProd { get; set; }
			public decimal PrecioProds { get; set; }
			public decimal descuento { get; set; }

		}
		public class DetallePago
		{
			public int IDDetallePago { get; set; }
			public int FkRecVenta { get; set; }
			public byte		FKOpPago { get; set; }
			public decimal Cantidad { get; set; }
		}

        public class Inventario
        {
            public string DepartamentoID { get; set; }
			public decimal cantMin { get; set; }
			public bool agotados { get; set; }
			public bool merma { get; set; }

        }


    }
}
