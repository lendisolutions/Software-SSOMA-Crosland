using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class KardexBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdKardex { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public String DescOrdenInterna { get; set; }
        [DataMember]
        public Int32 IdEquipo { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public DateTime FechaMovimiento { get; set; }
        [DataMember]
        public Decimal Cantidad { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
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
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String DescEquipo { get; set; }
        [DataMember]
        public Decimal Ingresos { get; set; }
        [DataMember]
        public Decimal Salidas { get; set; }
        [DataMember]
        public Decimal Stock { get; set; }
        
        #endregion
    }
}
