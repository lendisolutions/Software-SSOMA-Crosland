using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class SolicitudEppDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudEppDetalle { get; set; }
        [DataMember]
        public Int32 IdSolicitudEpp { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdEquipo { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String DescEquipo { get; set; }
        
        [DataMember]
        public Int32 Cantidad { get; set; }
        
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
