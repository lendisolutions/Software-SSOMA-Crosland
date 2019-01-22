using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class CapacitacionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCapacitacion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Int32 Participantes { get; set; }
        [DataMember]
        public Int32 IdLugar { get; set; }
        [DataMember]
        public Int32 IdTipoCapacitacion { get; set; }
        [DataMember]
        public Int32 IdClasificacionCapacitacion { get; set; }
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdExpositor { get; set; }
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
        public String DescProveedor { get; set; }
        [DataMember]
        public String DescLugar { get; set; }
        [DataMember]
        public String DescTipoCapacitacion { get; set; }
        [DataMember]
        public String DescClasificacionCapacitacion { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public String DescExpositor { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public Decimal Horas { get; set; }
        [DataMember]
        public Int32 Nota { get; set; }

        #endregion
    }
}
