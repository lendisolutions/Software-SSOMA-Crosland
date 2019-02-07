using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PreguntaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPregunta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdCuestionario { get; set; }
        [DataMember]
        public String DescPregunta { get; set; }
        [DataMember]
        public Int32 Puntaje { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }


        //DATOS EXTERNOS
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String DescCuestionario { get; set; }

        #endregion
    }
}
