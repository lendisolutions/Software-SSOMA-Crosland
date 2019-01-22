using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class DescansoMedicoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDescansoMedico { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdUnidadMinera { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdTipoDescansoMedico { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public Int32 Horas { get; set; }
        [DataMember]
        public Decimal Sueldo { get; set; }
        [DataMember]
        public Decimal Kpi { get; set; }
        [DataMember]
        public Int32 IdContingencia { get; set; }
        [DataMember]
        public String Diagnostico { get; set; }
        [DataMember]
        public String CentroMedico { get; set; }
        [DataMember]
        public Int32 IdCategoriaDiagnostico { get; set; }
        [DataMember]
        public Int32 IdCondicionDescansoMedico { get; set; }
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
        public String DescUnidadMinera { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public String DescTipoDescansoMedico { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public String DescContingencia { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescCondicionDescansoMedico { get; set; }
        [DataMember]
        public Int32 DiasVencimiento { get; set; }
        #endregion
    }
}
