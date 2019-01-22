using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class SctrBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSctr { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String TipoDocumento { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public String Nacionalidad { get; set; }
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
        public String DescMes { get; set; }
        [DataMember]
        public String Sexo { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion
    }
}
