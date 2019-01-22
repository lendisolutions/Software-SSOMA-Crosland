using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ActividadContratistaDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdActividadContratistaDetalle { get; set; }
        [DataMember]
        public Int32 IdActividadContratista { get; set; }
        [DataMember]
        public byte[] Archivo { get; set; }
        [DataMember]
        public String NombreArchivo { get; set; }
        [DataMember]
        public String Extension { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        //ATRIBUTOS EXTERNOS
        [DataMember]
        public Int32 TipoOper { get; set; }


        #endregion
    }
}
