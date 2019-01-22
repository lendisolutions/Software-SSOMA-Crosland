using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PlanAnualBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlanAnual { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdTipoCapacitacion { get; set; }
        [DataMember]
        public Int32 IdClaseCapacitacion { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        
        [DataMember]
        public Int32 IdLugar { get; set; }
        [DataMember]
        public Int32 IdResponsableCapacitacion { get; set; }
        [DataMember]
        public Int32 Duracion { get; set; }
        [DataMember]
        public DateTime? FechaCumplimiento { get; set; }
        [DataMember]
        public Decimal Costo { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String DescTipoCapacitacion { get; set; }
        [DataMember]
        public String DescClaseCapacitacion { get; set; }
        [DataMember]
        public String DescLugar { get; set; }
        [DataMember]
        public String DescResponsableCapacitacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion
    }
}
