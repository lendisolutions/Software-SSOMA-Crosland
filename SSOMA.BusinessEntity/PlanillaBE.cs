using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PlanillaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlanilla { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32 IdSector { get; set; }
        [DataMember]
        public Int32 IdActividad { get; set; }
        [DataMember]
        public Boolean FlagRutinaria { get; set; }
        [DataMember]
        public Boolean FlagNoRutinaria { get; set; }
        [DataMember]
        public Boolean FlagEmergencia { get; set; }
        [DataMember]
        public Boolean FlagPropio { get; set; }
        [DataMember]
        public Boolean FlagTercero { get; set; }
        [DataMember]
        public Int32 IdPeligro { get; set; }
        [DataMember]
        public String DetallePeligro { get; set; }
        [DataMember]
        public String TipoPeligro { get; set; }
        [DataMember]
        public String DescRiesgo { get; set; }
        [DataMember]
        public Int32 IndicePersona { get; set; }
        [DataMember]
        public Int32 IndiceProcedimiento { get; set; }
        [DataMember]
        public Int32 IndiceCapacitacion { get; set; }
        [DataMember]
        public Int32 IndiceFrecuencia { get; set; }
        [DataMember]
        public Int32 Severidad { get; set; }
        [DataMember]
        public Int32 ValoracionRiesgo { get; set; }
        [DataMember]
        public String CalificacionRiesgo { get; set; }
        [DataMember]
        public String Significativo { get; set; }
        [DataMember]
        public String Eliminacion { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public String Tratamiento { get; set; }
        [DataMember]
        public String ControlAdministrativo { get; set; }
        [DataMember]
        public String EquipoProteccion { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public Int32 IndicePersonaRR { get; set; }
        [DataMember]
        public Int32 IndiceProcedimientoRR { get; set; }
        [DataMember]
        public Int32 IndiceCapacitacionRR { get; set; }
        [DataMember]
        public Int32 IndiceFrecuenciaRR { get; set; }
        [DataMember]
        public Int32 SeveridadRR { get; set; }
        [DataMember]
        public Int32 ValoracionRiesgoRR { get; set; }
        [DataMember]
        public String CalificacionRiesgoRR { get; set; }
        [DataMember]
        public String SignificativoRR { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String DescActividad { get; set; }
        [DataMember]
        public String DescPeligro { get; set; }

        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
