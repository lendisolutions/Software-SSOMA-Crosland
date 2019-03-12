using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class RespuestaPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdRespuestaPersona { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdCuestionario { get; set; }
        [DataMember]
        public Int32 IdPregunta { get; set; }
        [DataMember]
        public Int32 IdRespuesta { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Boolean FlagRespuesta { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 Puntaje { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        //ATRIBUTOS EXTERNOS
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

        #endregion
    }
}
