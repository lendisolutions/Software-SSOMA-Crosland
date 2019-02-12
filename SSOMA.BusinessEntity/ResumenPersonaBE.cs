using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ResumenPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdResumenPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 NotaFinal { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        

        #endregion
    }
}
