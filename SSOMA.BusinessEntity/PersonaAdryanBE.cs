using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class PersonaAdryanBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 SECUENCIA { get; set; }
        public String DNI { get; set; }
        [DataMember]
        public String RUC_EMPRESA { get; set; }
        [DataMember]
        public String UNIDAD { get; set; }
        [DataMember]
        public String SEDE { get; set; }
        [DataMember]
        public String AREA { get; set; }
        [DataMember]
        public String APENOM { get; set; }
        [DataMember]
        public DateTime FECHA_NACIMIENTO { get; set; }
        [DataMember]
        public Int32 EDAD { get; set; }
        [DataMember]
        public DateTime FECHA_INGRESO { get; set; }
        [DataMember]
        public DateTime? FECHA_RETIRO { get; set; }
        [DataMember]
        public String PUESTO { get; set; }
        [DataMember]
        public String SEXO { get; set; }
        [DataMember]
        public String TIPO_CONTRATO { get; set; }
        [DataMember]
        public String ESTADO_CIVIL { get; set; }
        [DataMember]
        public String EMAIL_TRABAJO { get; set; }
        [DataMember]
        public String SITUACION { get; set; }
        #endregion
    }
}
