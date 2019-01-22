using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class SolicitudBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitud { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
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
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        #endregion
    }
}
