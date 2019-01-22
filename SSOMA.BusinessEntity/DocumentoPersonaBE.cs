using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class DocumentoPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDocumentoPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdDocumento { get; set; }
        [DataMember]
        public Boolean FlagImpresion { get; set; }
        [DataMember]
        public Int32 Lectura { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String NombreArchivo { get; set; }
        [DataMember]
        public Boolean FlagAsigna { get; set; }
        [DataMember]
        public String Revision { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public Int32 IdCarpeta { get; set; }
        [DataMember]
        public String DescCarpeta { get; set; }
        #endregion
    }
}
