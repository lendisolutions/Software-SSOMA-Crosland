using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteCapacitacionBE
    {
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public String FechaIni { get; set; }
        [DataMember]
        public String FechaFin { get; set; }
        [DataMember]
        public Int32 Participantes { get; set; }
        [DataMember]
        public String DescLugar { get; set; }
        [DataMember]
        public String DescTipoCapacitacion { get; set; }
        [DataMember]
        public String DescClasificacionCapacitacion { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String DescEmpresa { get; set; }
        [DataMember]
        public String DescExpositor { get; set; }
        [DataMember]
        public String CargoExpositor { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String EmpresaPersona { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Cargo { get; set; }
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
