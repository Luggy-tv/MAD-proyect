using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using MAD3_ventanas.Administrador;
using System.Reflection;
//using System.Reflection;

namespace MAD3_ventanas 
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }

        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();

        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();

        private static void conectar()
        {
            //string cnn = ConfigurationManager.AppSettings["desarrollo1"];
            string cnn = ConfigurationManager.ConnectionStrings["Tienda01"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }
        private static void desconectar()
        {
            _conexion.Close();
        }
        public List<ObjetoDB.Departamento> ConsultaDepartamentos()
        {
            var msg = "";
            List<ObjetoDB.Departamento> lista = new List<ObjetoDB.Departamento>();
            try
            {
                conectar();
                string qry = "sp_GestionarDepartamento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
               
                lista = GetList<ObjetoDB.Departamento>(dataReader);
              
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return lista;
        }
        public List<ObjetoDB.UnidadDeMedida> ConsultaUnidadDeMedida()
        {
            var msg = "";
            List<ObjetoDB.UnidadDeMedida> lista = new List<ObjetoDB.UnidadDeMedida>();
            try
            {
                conectar();
                string qry = "sp_GestionarUnidadDeMedida";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.UnidadDeMedida>(dataReader);
              
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return lista;
        }
        public List<ObjetoDB.Usuario> ConsultaUsuarios()
        {
            var msg = "";
            List<ObjetoDB.Usuario> lista = new List<ObjetoDB.Usuario>();
            try
            {
                conectar();
                string qry = "sp_GestionarUsuario";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Usuario>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return lista;
        }
        public List<ObjetoDB.DatosDeTienda> ConsultaDatosDeTienda()
        {
            var msg = "";
            List<ObjetoDB.DatosDeTienda> datosDeTienda = new List<ObjetoDB.DatosDeTienda>();
            try
            {
                conectar();
                string qry = "sp_GestionarTienda";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                datosDeTienda = GetList<ObjetoDB.DatosDeTienda>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return datosDeTienda;
        }
        public List<ObjetoDB.Caja> ConsultaCajas()
        {
            var msg = "";
            List<ObjetoDB.Caja> lista = new List<ObjetoDB.Caja>();
            try
            {
                conectar();
                string qry = "sp_GestionarCaja";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Caja>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        }
        public List<ObjetoDB.Caja> ConsultaCajasl()
        {
            var msg = "";
            List<ObjetoDB.Caja> lista = new List<ObjetoDB.Caja>();
            try
            {
                conectar();
                string qry = "sp_GestionarCaja";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "l";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Caja>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        }
        public List<ObjetoDB.Descuento> ConsultaDescuentos()
        {
            var msg = "";
            List<ObjetoDB.Descuento> lista = new List<ObjetoDB.Descuento>();
            try
            {
                conectar();
                string qry = "sp_GestionarDescuento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Descuento>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        } 
        public List<ObjetoDB.Producto> ConsultaProductos()
        {
            var msg = "";
            List<ObjetoDB.Producto> lista = new List<ObjetoDB.Producto>();
            try
            {
                conectar();
                string qry = "sp_GestionarProducto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Producto>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        }
        public List<ObjetoDB.Producto_En_Recibo> ConsultaProductoEnRecibos()
        {
            var msg = "";
            List<ObjetoDB.Producto_En_Recibo> lista = new List<ObjetoDB.Producto_En_Recibo>();
            try
            {
                conectar();
                string qry = "SP_BuscarProductoEnRecibo";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();


                lista = GetList<ObjetoDB.Producto_En_Recibo>(dataReader);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        }
        public List<ObjetoDB.Inventario> ConsultaInventario()
        {
            var msg = "";
            List<ObjetoDB.Inventario> lista = new List<ObjetoDB.Inventario>();
            try
            {
                conectar();
                string qry = "sp_GestionarInventario"; // crear stored procedure
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.Inventario>(dataReader);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        } 
        public List<ObjetoDB.OpcionDePago> ConsultaOpcionDePago()
        {
            var msg = "";
            List<ObjetoDB.OpcionDePago> lista = new List<ObjetoDB.OpcionDePago>();
            try
            {
                conectar();
                string qry = "sp_GestionarOpcionDePago";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = "s";
                var dataReader = _comandosql.ExecuteReader();
                lista = GetList<ObjetoDB.OpcionDePago>(dataReader);
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return lista;
        } 
        public List<ObjetoDB.ReciboDeVenta> ConsultaReciboDeVenta(string op,int IDRecibo, decimal Total, decimal Subtotal)
        {
            var msg = "";
            List<ObjetoDB.ReciboDeVenta> obj = new List<ObjetoDB.ReciboDeVenta>();
            //ObjetoDB.ReciboDeVenta obj2 = new ObjetoDB.ReciboDeVenta();
            try
            {
                conectar();
                string qry = "sp_GestionarReciboDeVenta";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value =op;
                var parametro2 = _comandosql.Parameters.Add("@idRecibo", SqlDbType.Int, 4);
                parametro2.Value = IDRecibo;
                var parametro3 = _comandosql.Parameters.Add("@Total", SqlDbType.SmallMoney, 4);
                parametro3.Value = Total;
                var parametro4 = _comandosql.Parameters.Add("@SubTotal", SqlDbType.SmallMoney, 4);
                parametro4.Value = Subtotal;
                var dataReader = _comandosql.ExecuteReader();
                obj = GetList<ObjetoDB.ReciboDeVenta>(dataReader);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return obj;
        }  
        public List<ObjetoDB.NotaCredito> ConsultaNotaCredito(string op, int NumReciboFK, decimal Cantidad, decimal Subtotal)
        {
            var msg = "";
            List<ObjetoDB.NotaCredito> obj = new List<ObjetoDB.NotaCredito>();
            //ObjetoDB.ReciboDeVenta obj2 = new ObjetoDB.ReciboDeVenta();
            try
            {
                conectar();
                string qry = "sp_GestionarNotaDeCredito";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@Total", SqlDbType.SmallMoney, 4);
                parametro2.Value = Cantidad;
                var parametro3 = _comandosql.Parameters.Add("@SubTotal", SqlDbType.SmallMoney, 4);
                parametro3.Value = Subtotal;
                var parametro4 = _comandosql.Parameters.Add("@ReciboFK", SqlDbType.Int, 4);
                parametro4.Value = NumReciboFK;
                var dataReader = _comandosql.ExecuteReader();
                
                obj = GetList<ObjetoDB.NotaCredito>(dataReader);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return obj;
        }
        public List<ObjetoDB.Devolucion> ConsultaDevolucion(string op,int proudctoFK,decimal cantidad,bool merma)
        {
            var msg = "";
            List<ObjetoDB.Devolucion> obj = new List<ObjetoDB.Devolucion>();

            try
            {
                conectar();
                string qry = "sp_GestionarDevolucion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@ProductoFK", SqlDbType.Int, 4);
                parametro2.Value = proudctoFK;
                var parametro3 = _comandosql.Parameters.Add("@cantidad", SqlDbType.Decimal, 4);
                parametro3.Value = cantidad;
                var parametro4 = _comandosql.Parameters.Add("@merma", SqlDbType.Bit, 4);
                parametro4.Value = merma;

                var dataReader = _comandosql.ExecuteReader();

                obj = GetList<ObjetoDB.Devolucion>(dataReader);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return obj;
        }
        public List<ObjetoDB.NotaCred_Devol> ConsultaNotaCreditoYDevolucion(string op,int IdNotaCredito_Devol, int notaCreditoFK, int Devolucion, DateTime fecha)
        {
            var msg = "";
            List<ObjetoDB.NotaCred_Devol> obj = new List<ObjetoDB.NotaCred_Devol>();
            try
            {
                conectar();
                string qry = "Sp_Header_NotaCreditoYDevolucion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;

                var parametro2 = _comandosql.Parameters.Add("@IDNotaCred_Devol", SqlDbType.Int, 4);
                parametro2.Value = IdNotaCredito_Devol;
  
                var parametro3 = _comandosql.Parameters.Add("@notaCreditoFK", SqlDbType.Int, 4);
                parametro3.Value = notaCreditoFK;
                
                var parametro4 = _comandosql.Parameters.Add("@Devolucion", SqlDbType.Int, 4);
                parametro4.Value = Devolucion;
                
                var parametro5 = _comandosql.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4);
                parametro5.Value = fecha;

                var dataReader = _comandosql.ExecuteReader();

                obj = GetList<ObjetoDB.NotaCred_Devol>(dataReader);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return obj;
        }
        
        public DataTable ConsultaTablaDatosDeTienda()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            string opc = "s";
            try
            {
                conectar();
                string qry = "sp_GestionarTienda"; //nombre del stored procedure
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure; // Hay tres tipos de comandos: SP, tabla o text(query, cualquier clausula del DML). 
                                                                       // -> Para este proyecto siempre debe ser un Stored Procedure     
                _comandosql.CommandTimeout = 1200;                     //Tiempo antes de determinar error
                                                                       //Los parámtros deben llamarse exactamente igual que en SP
                var parametro1 = _comandosql.Parameters.Add("@Op", SqlDbType.Char, 1); //Orden: (Nombre, tipo de dato, longitud)


                parametro1.Value = opc; //Qué valor le voy a mandar. Se inicializa en el primer string (en el public)
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public DataTable ConsultaProductosEnReorden()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            string opc = "s";
            try
            {
                conectar();
                string qry = "SP_GetProductosEnPuntoDeReorden"; //nombre del stored procedure
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure; // Hay tres tipos de comandos: SP, tabla o text(query, cualquier clausula del DML). 
                                                                       // -> Para este proyecto siempre debe ser un Stored Procedure     
                _comandosql.CommandTimeout = 1200; //Tiempo antes de determinar error
                //Los parámtros deben llamarse exactamente igual que en SP
                var parametro1 = _comandosql.Parameters.Add("@Op", SqlDbType.Char, 1); //Orden: (Nombre, tipo de dato, longitud)
                parametro1.Value = opc; //Qué valor le voy a mandar. Se inicializa en el primer string (en el public)
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public DataTable ConsultaRapidaPrecio(string opc,int IDProducto,string nombre)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_BusquedaRapida"; //nombre del stored procedure
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure; // Hay tres tipos de comandos: SP, tabla o text(query, cualquier clausula del DML). 
                                                                       // -> Para este proyecto siempre debe ser un Stored Procedure     
                _comandosql.CommandTimeout = 1200; //Tiempo antes de determinar error
                //Los parámtros deben llamarse exactamente igual que en SP
                var parametro1 = _comandosql.Parameters.Add("@Op", SqlDbType.Char, 1); 
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@IDProducto", SqlDbType.Int, 4);
                parametro2.Value = IDProducto;
                var parametro3 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro3.Value = nombre;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;

        }
        public DataTable ConsultaRecibo(string opc, int idRecibo)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_ConsultaRecibos"; //nombre del stored procedure
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure; // Hay tres tipos de comandos: SP, tabla o text(query, cualquier clausula del DML). 
                                                                       // -> Para este proyecto siempre debe ser un Stored Procedure     
                _comandosql.CommandTimeout = 1200; //Tiempo antes de determinar error
                //Los parámtros deben llamarse exactamente igual que en SP
                var parametro1 = _comandosql.Parameters.Add("@Op", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@IDProducto", SqlDbType.Int, 4);
                parametro2.Value = idRecibo;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;

        }
        public List<ObjetoDB.CurrentLogin> ConsultaLogin(string op, Int16 IDUsuario, byte caja, DateTime date)
        {
            var msg = "";
            bool add;
            var lista = new List<ObjetoDB.CurrentLogin>();
            try
            {
                conectar();
                string qry = "sp_LoginCajeroACaja";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@UsuarioFK", SqlDbType.SmallInt, 16);
                parametro2.Value = IDUsuario;
                var parametro3 = _comandosql.Parameters.Add("@CajaFk", SqlDbType.TinyInt, 30);
                parametro3.Value = caja;
                var parametro4 = _comandosql.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4);
                parametro4.Value = date;
                var dataReader = _comandosql.ExecuteReader();

                //T MapToClass<T>(SqlDataReader reader)
                lista = GetList<ObjetoDB.CurrentLogin>(dataReader);

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return lista;
        }
        public bool GestLogin(string op, Int16 IDUsuario, byte caja, DateTime date)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_LoginCajeroACaja";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@UsuarioFK", SqlDbType.SmallInt, 16);
                parametro2.Value = IDUsuario;
                var parametro3 = _comandosql.Parameters.Add("@CajaFk", SqlDbType.TinyInt, 30);
                parametro3.Value = caja;
                var parametro4 = _comandosql.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4);
                parametro4.Value = date;


                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestVenta(string op, int idVenta ,Int16 IDLoginCaja, int IDReciboVenta, DateTime date)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "SP_GestionarVentas";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@FKReciboVenta", SqlDbType.Int, 4);
                parametro2.Value = idVenta;
                var parametro3 = _comandosql.Parameters.Add("@CajeroLoginFK", SqlDbType.SmallInt, 2);
                parametro3.Value =IDLoginCaja;
                var parametro4 = _comandosql.Parameters.Add("@ReciboVentaFK", SqlDbType.Int, 4);
                parametro4.Value = IDReciboVenta;
                var parametro5 = _comandosql.Parameters.Add("@Fecha", SqlDbType.DateTime, 8);
                parametro5.Value = date;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestDept(string op  ,Int16 IDDepartamento, string nombreDept,  bool reembolsable ) 
        {
            var msg = "";
            var add = true;

            try
            {
                conectar();
                string qry = "sp_GestionarDepartamento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@IDDepartamento", SqlDbType.SmallInt, 16);
                parametro2.Value = IDDepartamento;
                var parametro3 = _comandosql.Parameters.Add("@nombreDept", SqlDbType.VarChar, 30);
                parametro3.Value = nombreDept;
                var parametro4 = _comandosql.Parameters.Add("@Reembolsable", SqlDbType.Bit, 1);
                parametro4.Value = reembolsable;


                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestUsuarios(string op  , Int16 IDUsuario ,string contraseña , string nombres , string apellidoPat  , string apellidoMat  , string CURP  ,DateTime fechaNac , string numNomina , string email , bool esAdmin ) 
        {
            var msg = "";
            var add = true;

            try
            {
                conectar();
                string qry = "sp_GestionarUsuario";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@IDUsuario", SqlDbType.SmallInt, 16);
                parametro2.Value = IDUsuario;
                var parametro3 = _comandosql.Parameters.Add("@contraseña", SqlDbType.VarChar, 20);
                parametro3.Value = contraseña;
                var parametro4 = _comandosql.Parameters.Add("@nombres", SqlDbType.VarChar, 30);
                parametro4.Value = nombres;
                var parametro5 = _comandosql.Parameters.Add("@apellidoPat", SqlDbType.VarChar, 30);
                parametro5.Value = apellidoPat;
                var parametro6 = _comandosql.Parameters.Add("@apellidoMat", SqlDbType.VarChar, 30);
                parametro6.Value = apellidoMat;
                var parametro7 = _comandosql.Parameters.Add("@CURP", SqlDbType.Char, 18);
                parametro7.Value = CURP;
                var parametro8 = _comandosql.Parameters.Add("@fechNac", SqlDbType.Date, 3);
                parametro8.Value = fechaNac;
                var parametro9 = _comandosql.Parameters.Add("@numNomina", SqlDbType.Char, 16);
                parametro9.Value = numNomina;
                var parametro10 = _comandosql.Parameters.Add("@email", SqlDbType.VarChar, 30);
                parametro10.Value = email;
                var parametro11 = _comandosql.Parameters.Add("@esAdmin", SqlDbType.Bit, 1);
                parametro11.Value = esAdmin;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestProd(string op  , int IDProducto, string     Nombre, string  Descripcion,decimal Costo, decimal    PrecioUnitario  , decimal   Existencias,decimal PuntoDeReorden  ,  short DepartamentoFK  ,  short      UnidadMedidaFK  )
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_GestionarProducto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@IDProducto", SqlDbType.Int, 4);
                parametro2.Value = IDProducto;
                var parametro3 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 32);
                parametro3.Value = Nombre;
                var parametro4 = _comandosql.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50);
                parametro4.Value = Descripcion;
                var parametro5 = _comandosql.Parameters.Add("@Costo", SqlDbType.SmallMoney, 4);
                parametro5.Value = Costo;
                var parametro6 = _comandosql.Parameters.Add("@PrecioUnitario", SqlDbType.SmallMoney, 4);
                parametro6.Value = PrecioUnitario;
                var parametro7 = _comandosql.Parameters.Add("@Existencias", SqlDbType.Int,4);
                parametro7.Value = Existencias;
                var parametro8 = _comandosql.Parameters.Add("@PuntoDeReorden", SqlDbType.Int,4);
                parametro8.Value = PuntoDeReorden;
                var parametro9 = _comandosql.Parameters.Add("@DepartamentoFK", SqlDbType.SmallInt,2);
                parametro9.Value = DepartamentoFK;
                var parametro10 = _comandosql.Parameters.Add("@UnidadMedidaFK", SqlDbType.SmallInt,2);
                parametro10.Value = UnidadMedidaFK;


                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestTienda(string op,string NombreTienda,byte Sucursal,string RFC,string Domicilio,string CodigoPostal,string email,string numTel)
        {


            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_GestionarTienda";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@NombreTienda", SqlDbType.VarChar, 30);
                parametro2.Value = NombreTienda;
                var parametro3 = _comandosql.Parameters.Add("@Sucursal", SqlDbType.TinyInt, 1);
                parametro3.Value = Sucursal;
                var parametro4 = _comandosql.Parameters.Add("@RFC", SqlDbType.Char, 13);
                parametro4.Value = RFC;
                var parametro5 = _comandosql.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100);
                parametro5.Value = Domicilio;
                var parametro6 = _comandosql.Parameters.Add("@CodigoPostal", SqlDbType.Char, 6);
                parametro6.Value = CodigoPostal;
                var parametro7 = _comandosql.Parameters.Add("@email", SqlDbType.VarChar, 40);
                parametro7.Value = email;
                var parametro8 = _comandosql.Parameters.Add("@numTel", SqlDbType.Char, 10);
                parametro8.Value = numTel;

                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestCajas(string op,  byte IDCaja,   bool disponible)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_GestionarCaja";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@IDCaja", SqlDbType.TinyInt, 8);
                parametro2.Value = IDCaja;
                var parametro3 = _comandosql.Parameters.Add("@Disponible", SqlDbType.Bit, 1);
                parametro3.Value = disponible;

                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestDescuento(string op ,int IDDescuento ,string Nombre	,byte Porcentaje,DateTime FechaINI,DateTime FechaFIN,int ProductoFK)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "sp_GestionarDescuento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@IDDescuento", SqlDbType.Int, 4);
                parametro2.Value = IDDescuento;
                var parametro3 = _comandosql.Parameters.Add("@Nombre",      SqlDbType.VarChar, 20);
                parametro3.Value = Nombre;
                var parametro4 = _comandosql.Parameters.Add("@Porcentaje",  SqlDbType.TinyInt, 1);
                parametro4.Value = Porcentaje;
                var parametro5 = _comandosql.Parameters.Add("@FechaINI",    SqlDbType.Date, 3);
                parametro5.Value = FechaINI;
                var parametro6 = _comandosql.Parameters.Add("@FechaFIN",    SqlDbType.Date, 3);
                parametro6.Value = FechaFIN;
                var parametro7 = _comandosql.Parameters.Add("@ProductoFK",  SqlDbType.VarChar, 40);
                parametro7.Value = ProductoFK;

                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }//Agregado
        public bool GestDetalleProd(string op, int FkRecVent, int FkProd,  decimal CantProd)
        {
            var msg = "";
            var add = true;

            try
            {
                conectar();
                string qry = "SP_GestionarDetalleProductos";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@FKReciboVenta", SqlDbType.Int, 4);
                parametro2.Value = FkRecVent;
                var parametro3 = _comandosql.Parameters.Add("@FkProducto", SqlDbType.Int, 4);
                parametro3.Value = FkProd;
                var parametro4 = _comandosql.Parameters.Add("@CantidadDeProducto", SqlDbType.Decimal, 7);
                parametro4.Value = CantProd;
                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public bool GestDetallePago(string op,int FkRecVent,byte FKOpPago,decimal Cantidad)
        {
            var msg = "";
            var add = true;

            try
            {
                conectar();
                string qry = "SP_GestionarDetalleDePago";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 1);
                parametro1.Value = op;
                var parametro2 = _comandosql.Parameters.Add("@FKReciboVenta", SqlDbType.Int, 4);
                parametro2.Value = FkRecVent;
                var parametro3 = _comandosql.Parameters.Add("@FkOpcionDePago", SqlDbType.TinyInt, 1);
                parametro3.Value = FKOpPago;
                var parametro4 = _comandosql.Parameters.Add("@CantidadAPagar", SqlDbType.Decimal, 17);
                parametro4.Value = Cantidad;
                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }
        public int GetCount(string op)
        {
            int cantidad = 0;
            var msg = "";
            try
            {
                conectar();
                string qry = "sp_GetCountTable";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@op", SqlDbType.Char, 4);
                parametro1.Value = op;
                var dataReader = _comandosql.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        cantidad = dataReader.GetInt32(0);
                    }
                }
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return cantidad;
        }
        public List<T> GetList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach(var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
            return list;
        }
    }  
}      

