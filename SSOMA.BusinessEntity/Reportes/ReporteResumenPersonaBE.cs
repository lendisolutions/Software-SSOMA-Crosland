using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteResumenPersonaBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public Int32 NotaFinal { get; set; }
        [DataMember]
        public String Situacion { get; set; }
    }
}
