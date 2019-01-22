using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class MovimientoExtintorBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMovimientoExtintor { get; set; }
        [DataMember]
        public Int32 IdExtintor { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Ubicacion { get; set; }
        [DataMember]
        public String HechoPor { get; set; }
        [DataMember]
        public String AutorizadoPor { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        

        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String AbreviaturaClasificacion { get; set; }
        [DataMember]
        public String AbreviaturaTipo { get; set; }
        [DataMember]
        public String Capacidad { get; set; }

        #endregion
    }
}
