using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReportePlanAnualBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Item { get; set; }
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
        public Int32 Periodo { get; set; }
        [DataMember]
        public String DescLugar { get; set; }
        [DataMember]
        public String DescResponsableCapacitacion { get; set; }
        [DataMember]
        public String FechaCumplimiento { get; set; }
        [DataMember]
        public Decimal Costo { get; set; }

        #endregion
    }
}
