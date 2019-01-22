using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PlanAnualDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlanAnualDetalle { get; set; }
        [DataMember]
        public Int32 IdPlanAnual { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public Int32 Semana { get; set; }
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
