using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CondicionSubEstandarBL
    {
        public List<CondicionSubEstandarBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                return CondicionSubEstandar.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CondicionSubEstandarBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                return CondicionSubEstandar.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CondicionSubEstandarBE Selecciona(int IdCondicionSubEstandar)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                CondicionSubEstandarBE objEmp = CondicionSubEstandar.Selecciona(IdCondicionSubEstandar);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CondicionSubEstandarBE pItem)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                CondicionSubEstandar.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CondicionSubEstandarBE pItem)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                CondicionSubEstandar.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CondicionSubEstandarBE pItem)
        {
            try
            {
                CondicionSubEstandarDL CondicionSubEstandar = new CondicionSubEstandarDL();
                CondicionSubEstandar.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
