using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteEntrevistadoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidenteEntrevistado { get; set; }
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public Int32 IdEntrevistado { get; set; }
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
        public String Entrevistado { get; set; }

        #endregion
    }
}
