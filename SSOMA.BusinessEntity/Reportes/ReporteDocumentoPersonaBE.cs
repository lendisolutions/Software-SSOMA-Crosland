using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteDocumentoPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public string DescCarpeta { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String NombreArchivo { get; set; }
        [DataMember]
        public Int32 Lectura { get; set; }

        #endregion
    }
}
