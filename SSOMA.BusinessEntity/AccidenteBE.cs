using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public Int32 IdTipo { get; set; }
        [DataMember]
        public Int32 IdDanio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdEmpresaResponsable { get; set; }
        [DataMember]
        public Int32 IdUnidadMineraResponsable { get; set; }
        [DataMember]
        public Int32 IdAreaResponsable { get; set; }
        [DataMember]
        public Int32 IdSectorResponsable { get; set; }
        [DataMember]
        public Int32? IdPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresaContratista { get; set; }
        [DataMember]
        public Int32? IdJefeDirecto { get; set; }
        [DataMember]
        public String TiempoExperiencia { get; set; }
        [DataMember]
        public String TipoMaterial { get; set; }
        [DataMember]
        public Int32? IdResponsableArea { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime Hora { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public String Lugar { get; set; }
        [DataMember]
        public String HoraTrabajada { get; set; }
        [DataMember]
        public Int32 IdPotencialDanio { get; set; }
        [DataMember]
        public Int32 IdGradoAccidente { get; set; }
        [DataMember]
        public Int32 IdProbabilidadOcurrencia { get; set; }
        [DataMember]
        public String Porque { get; set; }
        [DataMember]
        public Int32 IdTrabajoOrdenadoPor { get; set; }
        [DataMember]
        public Int32 IdTipoAccidente { get; set; }
        [DataMember]
        public Int32 IdParteLesionada { get; set; }
        [DataMember]
        public Int32 IdTipoLesion { get; set; }
        [DataMember]
        public Int32 IdFuenteLesion { get; set; }
        [DataMember]
        public Int32 DiasPerdido { get; set; }
        [DataMember]
        public Int32 TrabajadoresAfectado { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Int32 IdInvestigadoPor { get; set; }
        [DataMember]
        public Int32 IdRevisadoPor { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescTipo { get; set; }
        [DataMember]
        public String DescDanio { get; set; }
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
        public String CorreoJefeDirecto { get; set; }
        [DataMember]
        public String ResponsableArea { get; set; }
        [DataMember]
        public String CorreoResponsableArea { get; set; }
        [DataMember]
        public String DescPotencialDanio { get; set; }
        [DataMember]
        public String DescGradoAccidente { get; set; }
        [DataMember]
        public String DescProbabilidadOcurrencia { get; set; }
        public String DescTipoAccidente { get; set; }
        [DataMember]
        public String DescParteLesionada { get; set; }
        [DataMember]
        public String DescTipoLesion { get; set; }
        [DataMember]
        public String DescFuenteLesion { get; set; }
        [DataMember]
        public String TrabajoOrdenadoPor { get; set; }
        [DataMember]
        public String InvestigadoPor { get; set; }
        [DataMember]
        public String CorreoInvestigadoPor { get; set; }
        [DataMember]
        public String RevisadoPor { get; set; }
        [DataMember]
        public String CorreoRevisadoPor { get; set; }
        [DataMember]
        public Decimal CostoTotal { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String ActividadEconomica { get; set; }
        [DataMember]
        public Int32 NumeroTrabajadores { get; set; }
        [DataMember]
        public String DescAccionCorrectiva { get; set; }
        [DataMember]
        public String FechaCumplimiento { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String EmpresaContratista { get; set; }
        #endregion
    }
}
