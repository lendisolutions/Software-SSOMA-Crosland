using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteCondicionSubEstandarBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidenteCondicionSubEstandar { get; set; }
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public Int32 IdCondicionSubEstandar { get; set; }
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
        public String DescCondicionSubEstandar { get; set; }

        #endregion
    }
}
