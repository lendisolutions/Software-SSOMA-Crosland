using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteExtintorBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String AbreviaturaClasificacion { get; set; }
        [DataMember]
        public String AbreviaturaTipo { get; set; }
        [DataMember]
        public String Proveedor { get; set; }
        [DataMember]
        public String Marca { get; set; }
        [DataMember]
        public String Capacidad { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public String Ubicacion { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }

        #endregion
    }
}
