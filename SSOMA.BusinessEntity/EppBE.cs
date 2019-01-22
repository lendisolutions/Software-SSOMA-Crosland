using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class EppBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEpp { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdSolicitudEpp { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresaResponsable { get; set; }
        [DataMember]
        public Int32 IdUnidadMineraResponsable { get; set; }
        [DataMember]
        public Int32 IdAreaResponsable { get; set; }
        [DataMember]
        public Int32 IdSectorResponsable { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescOrdenInterna { get; set; }
        [DataMember]
        public String Observacion { get; set; }
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
        public String DescArea { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String NumeroSolicitud { get; set; }
        [DataMember]
        public String DescNegocio { get; set; }
        [DataMember]
        public String EmpresaResponsable { get; set; }
        [DataMember]
        public String UnidadMineraResponsable { get; set; }
        [DataMember]
        public String AreaResponsable { get; set; }
        [DataMember]
        public String SectorResponsable { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Int32 Item { get; set; }

        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String DescEquipo { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescTipoEntrega { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }

        [DataMember]
        public List<EppDetalleBE> EppDetalle { get; set; }



        #endregion
    }
}
