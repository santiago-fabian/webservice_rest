using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TradingJS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "Isvc_Operaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface Isvc_Operaciones
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerOperaciones", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Operacion> ObtenerOperaciones();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GuardarOperacion", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool GuardarOperacion(DateTime FechaCompra, string Moneda, string Intercambio, double Inversion, double Cantidad, double PrecioCompra, double Comision);
    }

    [DataContract]
    public class Operacion
    {
        [DataMember]
        public int IdOperacion { get; set; }

        [DataMember]
        public string FechaCompra { get; set; }

        [DataMember]
        public string Moneda { get; set; }

        [DataMember]
        public string Intercambio { get; set; }

        [DataMember]
        public string Inversion { get; set; }

        [DataMember]
        public string Cantidad { get; set; }

        [DataMember]
        public string PrecioCompra { get; set; }

        [DataMember]
        public string PrecioActual { get; set; }

        [DataMember]
        public string Comision { get; set; }

        [DataMember]
        public string Total { get; set; }

        [DataMember]
        public string Rentabilidad { get; set; }

        [DataMember]
        public string Modificacion { get; set; }

        [DataMember]
        public bool Estatus { get; set; }
    }
}
