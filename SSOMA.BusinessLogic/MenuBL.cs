using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class MenuBL
    {
        public List<MenuBE> ListaTodosActivo()
        {
            try
            {
                MenuDL menu = new MenuDL();
                List<MenuBE> lista = menu.ListaTodosActivo();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
