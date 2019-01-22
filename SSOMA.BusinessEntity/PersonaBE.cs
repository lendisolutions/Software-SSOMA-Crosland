using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdNegocio { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32? IdContratista { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public DateTime? FechaCese { get; set; }
        [DataMember]
        public Int32 Edad { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String Sexo { get; set; }
        [DataMember]
        public Int32 IdTipoContrato { get; set; }
        [DataMember]
        public Int32 IdEstadoCivil { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Boolean FlagCapacitacion { get; set; }
        [DataMember]
        public String Sctr { get; set; }
        [DataMember]
        public DateTime FechaSctrIni { get; set; }
        [DataMember]
        public DateTime FechaSctrFin { get; set; }
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

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescNegocio { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescEmpresaContratista { get; set; }
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
        public String DescEstadoCivil { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion
    }
}
