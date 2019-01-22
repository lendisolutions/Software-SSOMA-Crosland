﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class EppDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEppDetalle { get; set; }
        [DataMember]
        public Int32 IdEpp { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdEquipo { get; set; }
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
        public Int32 IdTipoEntrega { get; set; }
        [DataMember]
        public Int32 IdKardex { get; set; }
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
        public String DescTipoEntrega { get; set; }

        #endregion
    }
}
