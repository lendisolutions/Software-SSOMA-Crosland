using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PersonaAdryanBL
    {
        public List<PersonaAdryanBE> ListaTodosActivo()
        {
            try
            {
                PersonaAdryanDL PersonaAdryan = new PersonaAdryanDL();
                return PersonaAdryan.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
