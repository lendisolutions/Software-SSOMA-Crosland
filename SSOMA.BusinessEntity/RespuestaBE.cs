using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class RespuestaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdRespuesta { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdCuestionario { get; set; }
        [DataMember]
        public Int32 IdPregunta { get; set; }
        [DataMember]
        public String DescRespuesta { get; set; }
        [DataMember]
        public Boolean FlagCorrecto { get; set; }
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
        public Int32 TipoOper { get; set; }

        #endregion

    }
}
