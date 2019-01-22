using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class HoraTrabajadaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdHoraTrabajada { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public Int32 Hora { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public Int32 CROSLAND_LOGISTICA_SAC { get; set; }
        [DataMember]
        public Int32 CROSLAND_FINANZAS_SAC { get; set; }
        [DataMember]
        public Int32 CROSLAND_REPUESTOS_SAC { get; set; }
        [DataMember]
        public Int32 CROSLAND_AUTOMOTRIZ_SAC { get; set; }
        [DataMember]
        public Int32 CROSLAND_TECNICA_SAC { get; set; }

        #endregion
    }
}
