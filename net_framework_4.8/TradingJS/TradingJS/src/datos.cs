using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                string Query = "SELECT int_id, dt_compra, var_criptomoneda, dbl_inversion, int_cantidad, dbl_precio_compra,	dbl_precio_actual, dbl_total, " +
                    "dbl_rentabilidad, dt_modificacion,	bol_estatus " +
                    "FROM tbl_operacion;";

                Conexion.Open();
                MySqlCommand Cmd = new MySqlCommand(Query, Conexion) { CommandTimeout = 180 };
                MySqlDataReader dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    Operacion Obj = new Operacion();

                    Obj.IdOperacion = Convert.ToInt32(dr["int_id"]);

                    if (!string.IsNullOrEmpty(dr["dt_compra"].ToString()))
                        Obj.FechaCompra = dr["dt_compra"].ToString();

                    if (!string.IsNullOrEmpty(dr["var_criptomoneda"].ToString()))
                        Obj.Criptomoneda = dr["var_criptomoneda"].ToString();

                    if (!string.IsNullOrEmpty(dr["dbl_inversion"].ToString()))
                        Obj.Inversion = Convert.ToDouble(dr["dbl_inversion"]);

                    if (!string.IsNullOrEmpty(dr["int_cantidad"].ToString()))
                        Obj.Cantidad = Convert.ToInt32(dr["int_cantidad"]);

                    if (!string.IsNullOrEmpty(dr["dbl_precio_compra"].ToString()))
                        Obj.PrecioCompra = Convert.ToDouble(dr["dbl_precio_compra"]);

                    if (!string.IsNullOrEmpty(dr["dbl_precio_actual"].ToString()))
                        Obj.PrecioActual = Convert.ToDouble(dr["dbl_precio_actual"]);

                    if (!string.IsNullOrEmpty(dr["dbl_total"].ToString()))
                        Obj.Total = Convert.ToDouble(dr["dbl_total"]);

                    if (!string.IsNullOrEmpty(dr["dbl_rentabilidad"].ToString()))
                        Obj.Rentabilidad = Convert.ToDouble(dr["dbl_rentabilidad"]);

                    if (!string.IsNullOrEmpty(dr["dt_modificacion"].ToString()))
                        Obj.Modificacion = dr["dt_modificacion"].ToString();

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
    }
}