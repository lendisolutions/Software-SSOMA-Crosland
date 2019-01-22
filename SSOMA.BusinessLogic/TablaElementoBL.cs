using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TablaElementoBL
    {
        public List<TablaElementoBE> ListaTodosActivo(int IdRegional, int IdTabla)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaTodosActivo(IdRegional, IdTabla);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TablaElementoBE SeleccionaDescripcion(int IdTabla, string DescTablaElemento)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElementoBE objEmp = TablaElemento.SeleccionaDescripcion(IdTabla, DescTablaElemento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElemento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElemento.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
