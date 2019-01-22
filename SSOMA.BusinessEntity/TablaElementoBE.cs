using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class TablaElementoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTablaElemento { get; set; }
        [DataMember]
        public Int32 IdTabla { get; set; }
        [DataMember]
        public String DescTabla { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescTablaElemento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        #endregion
    }
}
