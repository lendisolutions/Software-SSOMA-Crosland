using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteRespuestaPersonaBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String DescCuestionario { get; set; }
        [DataMember]
        public String DescPregunta { get; set; }
        [DataMember]
        public String DescRespuesta { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 Puntaje { get; set; }
        
        
    }
}
