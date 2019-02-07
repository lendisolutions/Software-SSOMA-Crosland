using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    public class ReportePreguntaBE
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
        public Int32 Puntaje { get; set; }
        [DataMember]
        public String DescRespuesta { get; set; }
        [DataMember]
        public Boolean FlagCorrecto { get; set; }
    }
}
