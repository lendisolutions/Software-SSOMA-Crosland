using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteAccidenteBE
    {
        #region "Atributos"

        [DataMember]
        public String DescTipo { get; set; }
        [DataMember]
        public String DescDanio { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public Int32 Edad { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
        public String EmpresaResponsable { get; set; }
        [DataMember]
        public String UnidadMineraResponsable { get; set; }
        [DataMember]
        public String AreaResponsable { get; set; }
        [DataMember]
        public String SectorResponsable { get; set; }
        [DataMember]
        public String JefeDirecto { get; set; }
        [DataMember]
        public String TiempoExperiencia { get; set; }
        [DataMember]
        public String TipoMaterial { get; set; }
        [DataMember]
        public String ResponsableArea { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public DateTime Hora { get; set; }
        [DataMember]
        public String FechaInicio { get; set; }
        [DataMember]
        public String Lugar { get; set; }
        [DataMember]
        public String HoraTrabajada { get; set; }
        [DataMember]
        public String DescPotencialDanio { get; set; }
        [DataMember]
        public String DescGradoAccidente { get; set; }
        [DataMember]
        public String DescProbabilidadOcurrencia { get; set; }
        [DataMember]
        public String Porque { get; set; }
        [DataMember]
        public String TrabajoOrdenadoPor { get; set; }
        [DataMember]
        public String DescTipoAccidente { get; set; }
        [DataMember]
        public String DescParteLesionada { get; set; }
        [DataMember]
        public String DescTipoLesion { get; set; }
        [DataMember]
        public String DescFuenteLesion { get; set; }
        [DataMember]
        public Int32 DiasPerdido { get; set; }
        [DataMember]
        public Decimal CostoTotal { get; set; }
        [DataMember]
        public Int32 TrabajadoresAfectado { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String InvestigadoPor { get; set; }
        [DataMember]
        public String RevisadoPor { get; set; }
        [DataMember]
        public String DescActoSubEstandar { get; set; }
        [DataMember]
        public String DescCondicionSubEstandar { get; set; }
        [DataMember]
        public String DescFactorPersonal { get; set; }
        [DataMember]
        public String DescFactorTrabajo { get; set; }
        [DataMember]
        public String DescAccionCorrectiva { get; set; }
        [DataMember]
        public String ResponsableAccionCorrectiva { get; set; }
        [DataMember]
        public String DniResponsableAccionCorrectiva { get; set; }
        [DataMember]
        public String FechaCumplimiento { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String Periodo { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public String DescNegocio { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String EmpresaContratista { get; set; }

        #endregion
    }
}
