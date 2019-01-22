using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ActoSubEstandarBL
    {
        public List<ActoSubEstandarBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                return ActoSubEstandar.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ActoSubEstandarBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                return ActoSubEstandar.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActoSubEstandarBE Selecciona(int IdActoSubEstandar)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                ActoSubEstandarBE objEmp = ActoSubEstandar.Selecciona(IdActoSubEstandar);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ActoSubEstandarBE pItem)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                ActoSubEstandar.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ActoSubEstandarBE pItem)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                ActoSubEstandar.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ActoSubEstandarBE pItem)
        {
            try
            {
                ActoSubEstandarDL ActoSubEstandar = new ActoSubEstandarDL();
                ActoSubEstandar.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
