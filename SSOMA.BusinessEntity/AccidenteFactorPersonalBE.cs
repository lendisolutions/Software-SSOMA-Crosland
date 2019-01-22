using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteFactorPersonalBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidenteFactorPersonal { get; set; }
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public Int32 IdFactorPersonal { get; set; }
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
        public String DescFactorPersonal { get; set; }

        #endregion
    }
}
