using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class CapacitacionDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCapacitacionDetalle { get; set; }
        [DataMember]
        public Int32 IdCapacitacion { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public Int32 Nota { get; set; }
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
        #endregion
    }
}
