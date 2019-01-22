using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class UsuarioUnidadMineraBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdUsuarioUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUser { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }


        #endregion
    }
}
