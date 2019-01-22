using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteAccionCorrectivaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidenteAccionCorrectiva { get; set; }
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public String DescAccionCorrectiva { get; set; }
        [DataMember]
        public Int32 IdResponsable { get; set; }
        [DataMember]
        public DateTime FechaCumplimiento { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        #endregion
    }
}
