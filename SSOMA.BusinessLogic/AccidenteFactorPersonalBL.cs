using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteFactorPersonalBL
    {
        public List<AccidenteFactorPersonalBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                return AccidenteFactorPersonal.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteFactorPersonalBE Selecciona(int IdAccidenteFactorPersonal)
        {
            try
            {
                AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                AccidenteFactorPersonalBE objEmp = AccidenteFactorPersonal.Selecciona(IdAccidenteFactorPersonal);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteFactorPersonalBE pItem)
        {
            try
            {
                AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                AccidenteFactorPersonal.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteFactorPersonalBE pItem)
        {
            try
            {
                AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                AccidenteFactorPersonal.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteFactorPersonalBE pItem)
        {
            try
            {
                AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                AccidenteFactorPersonal.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
