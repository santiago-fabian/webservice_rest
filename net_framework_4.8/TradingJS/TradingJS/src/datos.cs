using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TradingJS.src
{
    public class Datos
    {
        private string CadenaConexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_trading;";

        public List<Operacion> ObtenerOperaciones()
        {
            List<Operacion> ListaOperaciones = new List<Operacion>();
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

            try
            {
                string Query = "SELECT int_id, dt_compra, var_moneda, var_intercambio, dbl_inversion, dbl_cantidad, dbl_precio_compra, dbl_precio_actual, " +
                    "dbl_comision, dbl_total, dbl_rentabilidad, dt_modificacion, bol_estatus " +
                    "FROM tbl_operacion;";

                Conexion.Open();
                MySqlCommand Cmd = new MySqlCommand(Query, Conexion) { CommandTimeout = 180 };
                MySqlDataReader dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    Operacion Obj = new Operacion();

                    Obj.IdOperacion = Convert.ToInt32(dr["int_id"]);

                    if (!string.IsNullOrEmpty(dr["dt_compra"].ToString()))
                        Obj.FechaCompra = Convert.ToDateTime(dr["dt_compra"]).ToString("yyyy-MM-dd hh:mm:ss");

                    if (!string.IsNullOrEmpty(dr["var_moneda"].ToString()))
                        Obj.Moneda = dr["var_moneda"].ToString();

                    if (!string.IsNullOrEmpty(dr["var_intercambio"].ToString()))
                        Obj.Intercambio = dr["var_intercambio"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_inversion"].ToString()))
                        Obj.Inversion = dr["dbl_inversion"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_cantidad"].ToString()))
                        Obj.Cantidad = dr["dbl_cantidad"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_precio_compra"].ToString()))
                        Obj.PrecioCompra = dr["dbl_precio_compra"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_precio_actual"].ToString()))
                        Obj.PrecioActual = dr["dbl_precio_actual"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_comision"].ToString()))
                        Obj.Comision = dr["dbl_comision"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_total"].ToString()))
                        Obj.Total = dr["dbl_total"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_rentabilidad"].ToString()))
                        Obj.Rentabilidad = dr["dbl_rentabilidad"].ToString();

                    if (!string.IsNullOrEmpty(dr["dt_modificacion"].ToString()))
                        Obj.Modificacion = Convert.ToDateTime(dr["dt_modificacion"]).ToString("yyyy-MM-dd hh:mm:ss");

                    if (!string.IsNullOrEmpty(dr["bol_estatus"].ToString()))
                        Obj.Estatus = Convert.ToBoolean(dr["bol_estatus"]);

                    ListaOperaciones.Add(Obj);
                }

                dr.Close();
                Cmd.Dispose();
                Conexion.Close();
            }
            catch (Exception Ex)
            {
                ListaOperaciones = null;
            }
            finally
            {
                if (Conexion.State == System.Data.ConnectionState.Open)
                    Conexion.Close();
            }

            return ListaOperaciones;
        }

        public bool GuardarOperacion(DateTime _FechaCompra, string _Moneda, string _Intercambio, double _Inversion, double _Cantidad, double _PrecioCompra, double _Comision)
        {
            bool Resultado = false;
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

            try
            {
                string Query = "INSERT INTO tbl_operacion(dt_compra, var_moneda, var_intercambio, dbl_inversion, dbl_cantidad, dbl_precio_compra, " +
                    "dbl_precio_actual, dbl_comision, dbl_total, dbl_rentabilidad, dt_modificacion, bol_estatus) " +
                    $"VALUES ('{_FechaCompra.ToString("yyyy-MM-dd hh:mm:ss")}','{_Moneda}','{_Intercambio}', {_Inversion}, " +
                    $"{_Cantidad}, {_PrecioCompra}, 0, {_Comision}, 0, 0, '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}', true)";

                Conexion.Open();
                MySqlCommand Cmd = new MySqlCommand(Query, Conexion) { CommandTimeout = 180 };
                int Filas = Cmd.ExecuteNonQuery();
                if (Filas > 0)
                    Resultado = true;

                Cmd.Dispose();
                Conexion.Close();
            }
            catch (Exception Ex)
            {
                Resultado = false;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }

            return Resultado;
        }
    }
}