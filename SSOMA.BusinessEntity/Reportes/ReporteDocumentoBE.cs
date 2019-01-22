using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteDocumentoBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescCarpeta { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String NombreArchivo { get; set; }
        [DataMember]
        public String Revision { get; set; }
        [DataMember]
        public string FechaAprobacion { get; set; }
        
        #endregion
    }
}
