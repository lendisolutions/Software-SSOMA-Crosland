using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class MesBL
    {
        public List<MesBE> ListaTodosActivo()
        {
            try
            {
                MesDL Mes = new MesDL();
                return Mes.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
