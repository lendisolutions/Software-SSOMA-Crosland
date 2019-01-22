using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class SeguroViajeBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSeguroViaje { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }
        [DataMember]
        public DateTime FechaLlegada { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public String Pais { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String Pasaporte { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String EmailPersonal { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String Contacto { get; set; }
        [DataMember]
        public String TelefonoContacto1 { get; set; }
        [DataMember]
        public String TelefonoContacto2 { get; set; }
        [DataMember]
        public String EmpresaBoleta { get; set; }
        [DataMember]
        public String EmpresaFactura { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String Autoriza { get; set; }
        [DataMember]
        public String Oiseco { get; set; }
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
        public String DescSituacion { get; set; }
        #endregion
    }
}
