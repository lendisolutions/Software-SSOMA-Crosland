using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class InspeccionTrabajoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInspeccionTrabajoDetalle { get; set; }
        [DataMember]
        public Int32 IdInspeccionTrabajo { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public String CondicionSubEstandar { get; set; }
        [DataMember]
        public String AccionCorrectiva { get; set; }
        [DataMember]
        public Int32 IdResponsable { get; set; }
       
        [DataMember]
        public DateTime? FechaEjecucion { get; set; }
        [DataMember]
        public byte[] FotoCumplimiento { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String Lugar { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescTipoInspeccion { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime Hora { get; set; }
        [DataMember]
        public String Objetivo { get; set; }
        [DataMember]
        public String InspeccionadoPor { get; set; }
        [DataMember]
        public String EmpresaContratista { get; set; }
        #endregion
    }
}
