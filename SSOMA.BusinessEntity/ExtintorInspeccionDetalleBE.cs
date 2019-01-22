﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ExtintorInspeccionDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdExtintorInspeccionDetalle { get; set; }
        [DataMember]
        public Int32 IdExtintorInspeccion { get; set; }
        [DataMember]
        public Int32 IdExtintor { get; set; }
        [DataMember]
        public Boolean Uno { get; set; }
        [DataMember]
        public Boolean Dos { get; set; }
        [DataMember]
        public Boolean Tres { get; set; }
        [DataMember]
        public Boolean Cuatro { get; set; }
        [DataMember]
        public Boolean Cinco { get; set; }
        [DataMember]
        public Boolean Seis { get; set; }
        [DataMember]
        public Boolean Siete { get; set; }
        [DataMember]
        public Boolean Ocho { get; set; }
        [DataMember]
        public Boolean Nueve { get; set; }
        [DataMember]
        public Boolean Diez { get; set; }
        [DataMember]
        public Boolean Once { get; set; }
        [DataMember]
        public Boolean Doce { get; set; }
        [DataMember]
        public Boolean Trece { get; set; }
        [DataMember]
        public Boolean Catorce { get; set; }
        [DataMember]
        public Boolean Quince { get; set; }
        [DataMember]
        public Boolean Diecisies { get; set; }
        [DataMember]
        public Boolean Diecisiete { get; set; }
        [DataMember]
        public String RecargadoPor { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }


        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String Capacidad { get; set; }
        [DataMember]
        public String Ubicacion { get; set; }
        [DataMember]
        public String Marca { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public DateTime FechaVencimientoPruebaHidrostatica { get; set; }
        #endregion
    }
}
