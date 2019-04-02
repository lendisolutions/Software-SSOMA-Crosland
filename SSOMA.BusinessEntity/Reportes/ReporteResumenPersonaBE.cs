using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteResumenPersonaBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public Int32 NotaFinal { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public byte[] Firma1 { get; set; }
        [DataMember]
        public byte[] Firma2 { get; set; }
        [DataMember]
        public Decimal Horas { get; set; }
        [DataMember]
        public Int32 Nota { get; set; }
        [DataMember]
        public String Periodo { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public String DescNegocio { get; set; }
        [DataMember]
        public String EmpresaResponsable { get; set; }
        [DataMember]
        public String UnidadMineraResponsable { get; set; }
        [DataMember]
        public String AreaResponsable { get; set; }
    }
}
