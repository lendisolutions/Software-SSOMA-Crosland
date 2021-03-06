﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class TemaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTema { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCategoriaTema { get; set; }
        [DataMember]
        public Int32 IdTipoTema { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Objetivo { get; set; }
        [DataMember]
        public String DescTema { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Int32 Horas { get; set; }
        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public byte[] Firma1 { get; set; }
        [DataMember]
        public byte[] Firma2 { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String ResponsableCargo { get; set; }
        [DataMember]
        public String ResponsableEmpresa { get; set; }
        [DataMember]
        public Int32 IdTipoCapacitacion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
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
        public String DescCategoriaTema { get; set; }
        [DataMember]
        public String DescTipoTema { get; set; }
        [DataMember]
        public String DescTipoCapacitacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        #endregion
    }
}
