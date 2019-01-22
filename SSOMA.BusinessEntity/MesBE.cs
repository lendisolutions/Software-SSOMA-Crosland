using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class MesBE
    {
        #region "Atributos"
        
        [DataMember]
        public String Descripcion { get; set; }
       
        #endregion
    }
}
