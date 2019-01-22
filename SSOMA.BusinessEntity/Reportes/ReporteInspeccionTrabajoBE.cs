using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteInspeccionTrabajoBE
    {
        #region "Atributos"
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String ActividadEconomica { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String EmpresaContratista { get; set; }
        [DataMember]
        public String DescTipoInspeccion { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public DateTime Hora { get; set; }
        [DataMember]
        public String Objetivo { get; set; }
        [DataMember]
        public String Lugar { get; set; }
        [DataMember]
        public String InspeccionadoPor { get; set; }
        [DataMember]
        public String ResponsableArea { get; set; }
        [DataMember]
        public String ResponsableSector { get; set; }
        [DataMember]
        public Int32 NumeroTrabajadores { get; set; }
        [DataMember]
        public String PersonaRegistro { get; set; }
        [DataMember]
        public String PersonaCargo { get; set; }
        public Int32 Item { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public String CondicionSubEstandar { get; set; }
        [DataMember]
        public String AccionCorrectiva { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String FechaEjecucion { get; set; }
        [DataMember]
        public byte[] FotoCumplimiento { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        [DataMember]
        public string Periodo  { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }

        #endregion
    }
}
