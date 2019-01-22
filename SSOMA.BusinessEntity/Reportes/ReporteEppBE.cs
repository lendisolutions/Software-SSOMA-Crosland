using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteEppBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescNegocio { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String NumeroSolicitud { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String EmpresaResponsable { get; set; }
        [DataMember]
        public String UnidadMineraResponsable { get; set; }
        [DataMember]
        public String AreaResponsable { get; set; }
        [DataMember]
        public String SectorResponsable { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Periodo { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String DescEquipo { get; set; }
        [DataMember]
        public String FechaVencimiento { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescTipoEntrega { get; set; }
    }
}
