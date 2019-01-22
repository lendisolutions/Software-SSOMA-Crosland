using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class FactorPersonalBL
    {
        public List<FactorPersonalBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                return FactorPersonal.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FactorPersonalBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                return FactorPersonal.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FactorPersonalBE Selecciona(int IdFactorPersonal)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                FactorPersonalBE objEmp = FactorPersonal.Selecciona(IdFactorPersonal);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FactorPersonalBE pItem)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                FactorPersonal.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FactorPersonalBE pItem)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                FactorPersonal.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FactorPersonalBE pItem)
        {
            try
            {
                FactorPersonalDL FactorPersonal = new FactorPersonalDL();
                FactorPersonal.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
