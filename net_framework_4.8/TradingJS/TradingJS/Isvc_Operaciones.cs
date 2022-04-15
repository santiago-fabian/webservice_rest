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
    }

    [DataContract]
    public class Operacion
    {
        [DataMember]
        public int IdOperacion { get; set; }
        [DataMember]
        public string FechaCompra { get; set; }
        [DataMember]
        public string Criptomoneda { get; set; }
        [DataMember]
        public double Inversion { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public double PrecioCompra { get; set; }
        [DataMember]
        public double PrecioActual { get; set; }
        [DataMember]
        public double Total { get; set; }
        [DataMember]
        public double Rentabilidad { get; set; }
        [DataMember]
        public string Modificacion { get; set; }
        [DataMember]
        public bool Estatus { get; set; }
    }
}
