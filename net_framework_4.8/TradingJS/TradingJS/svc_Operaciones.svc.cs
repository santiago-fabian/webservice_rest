using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using TradingJS.src;
namespace TradingJS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "svc_Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione svc_Operaciones.svc o svc_Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class svc_Operaciones : Isvc_Operaciones
    {
        public List<Operacion> ObtenerOperaciones()
        {
            Datos Datos = new Datos();
            List<Operacion> ListaOperaciones = new List<Operacion>();

            try
            {
                ListaOperaciones = Datos.ObtenerOperaciones();
            }
            catch (Exception)
            {
                ListaOperaciones = null;
            }

            return ListaOperaciones;
        }

        public bool GuardarOperacion(DateTime FechaCompra, string Moneda, string Intercambio, double Inversion, double Cantidad, double PrecioCompra, double Comision)
        {
            bool Resultado = false;
            Datos Datos = new Datos();

            try
            {
                Resultado = Datos.GuardarOperacion(FechaCompra, Moneda, Intercambio, Inversion, Cantidad, PrecioCompra, Comision);
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
    }
}
