using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteSeguroSctrBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public String TipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String Sexo { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String FechaNacimiento { get; set; }
        [DataMember]
        public String Nacionalidad { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        #endregion
    }
}
