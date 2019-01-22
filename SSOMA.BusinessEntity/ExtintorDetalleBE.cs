using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ExtintorDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdExtintorDetalle { get; set; }
        [DataMember]
        public Int32 IdExtintor { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdServicioExtintor { get; set; }
        [DataMember]
        public String DescServicioExtintor { get; set; }
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
