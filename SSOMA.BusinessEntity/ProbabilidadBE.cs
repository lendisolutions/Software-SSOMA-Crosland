using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ProbabilidadBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProbabilidad { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 ValorProbabilidad { get; set; }
        [DataMember]
        public String IndicePersona { get; set; }
        [DataMember]
        public String IndiceProcedimiento { get; set; }
        [DataMember]
        public String IndiceCapacitacion { get; set; }
        [DataMember]
        public String IndiceFrecuencia { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        #endregion

    }
}
