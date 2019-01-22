using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class ReporteEquipoBE
    {
        #region "Atributos"

        [DataMember]
        public byte[] Logo { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String DescEquipo { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        

        #endregion
    }
}
