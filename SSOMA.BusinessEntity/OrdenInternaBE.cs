using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class OrdenInternaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdOrdenInterna { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public String DescOrdenInterna { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String DescUnidadMinera { get; set; }

        #endregion
    }
}
