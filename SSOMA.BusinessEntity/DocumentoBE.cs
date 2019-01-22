using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class DocumentoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDocumento { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCarpeta { get; set; }
        [DataMember]
        public byte[] Archivo { get; set; }
        [DataMember]
        public String Ruta { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String NombreArchivo { get; set; }
        [DataMember]
        public String Revision { get; set; }
        [DataMember]
        public DateTime FechaAprobacion { get; set; }
        [DataMember]
        public Boolean FlagContabilidad { get; set; }
        [DataMember]
        public Boolean FlagSistemas { get; set; }
        [DataMember]
        public Boolean FlagLegal { get; set; }
        [DataMember]
        public Boolean FlagTesoreria { get; set; }
        [DataMember]
        public Boolean FlagAtraccion { get; set; }
        [DataMember]
        public Boolean FlagAdministracion { get; set; }
        [DataMember]
        public Boolean FlagComercial { get; set; }
        [DataMember]
        public Boolean FlagDesarrolloNegocio { get; set; }
        [DataMember]
        public Boolean FlagControlGestion { get; set; }
        [DataMember]
        public Boolean FlagAlmacen { get; set; }
        [DataMember]
        public Boolean FlagDespacho { get; set; }
        [DataMember]
        public Boolean FlagGerenciaGeneral { get; set; }
        [DataMember]
        public Boolean FlagMarketing { get; set; }
        [DataMember]
        public Boolean FlagOperacion { get; set; }
        [DataMember]
        public Boolean FlagProyecto { get; set; }
        [DataMember]
        public Boolean FlagServicioGeneral { get; set; }
        [DataMember]
        public Boolean FlagPlaneamiento { get; set; }
        [DataMember]
        public Boolean FlagCompensacion { get; set; }
        [DataMember]
        public Boolean FlagBienestar { get; set; }
        [DataMember]
        public Boolean FlagAlquiler { get; set; }
        [DataMember]
        public Boolean FlagDesarrolloOrganizacional { get; set; }
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
        public String DescCarpeta { get; set; }

        #endregion
    }
}
