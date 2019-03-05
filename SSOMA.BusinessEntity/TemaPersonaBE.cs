using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    public class TemaPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTemaPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Boolean FlagMatricula { get; set; }
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
        public String DescArea { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Boolean FlagAsigna { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        #endregion
    }
}
