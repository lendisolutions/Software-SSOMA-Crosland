using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteSolicitudBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Numero { get; set; }
        public String Solicitante { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public string Fecha { get; set; }
        [DataMember]
        public string FechaIngreso { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion
    }
}
