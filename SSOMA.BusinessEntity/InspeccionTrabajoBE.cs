using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class InspeccionTrabajoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInspeccionTrabajo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdEmpresaContratista { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32 IdSector { get; set; }
        [DataMember]
        public Int32 IdTipoInspeccion { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime Hora { get; set; }
        [DataMember]
        public String Objetivo { get; set; }
        [DataMember]
        public String Lugar { get; set; }
        [DataMember]
        public Int32 IdInspeccionadoPor { get; set; }
        [DataMember]
        public Int32? IdResponsableArea { get; set; }
        [DataMember]
        public Int32? IdResponsableSector { get; set; }
        [DataMember]
        public Int32 NumeroTrabajadores { get; set; }
        [DataMember]
        public String PersonaRegistro { get; set; }
        [DataMember]
        public String PersonaCargo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        //DATOS EXTERNOS
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String EmpresaContratista { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String DescTipoInspeccion { get; set; }
        [DataMember]
        public String InspeccionadoPor { get; set; }
        [DataMember]
        public String ResponsableArea { get; set; }
        [DataMember]
        public String MailAreaResponsable { get; set; }
        [DataMember]
        public String ResponsableSector { get; set; }
        [DataMember]
        public String MailSectorResponsable { get; set; }
        #endregion
    }
}
