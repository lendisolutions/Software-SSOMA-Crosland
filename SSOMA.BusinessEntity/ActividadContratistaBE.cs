using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ActividadContratistaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdActividadContratista { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescActvidad { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public String ResponsableContratista { get; set; }
        [DataMember]
        public String EmailContratista { get; set; }
        [DataMember]
        public String ResponsableEmpresa { get; set; }
        [DataMember]
        public String EmailEmpresa { get; set; }
        [DataMember]
        public DateTime FechaSctrIni { get; set; }
        [DataMember]
        public DateTime FechaSctrFin { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion
    }
}
