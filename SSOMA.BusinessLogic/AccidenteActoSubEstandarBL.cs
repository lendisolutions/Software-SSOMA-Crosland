using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteActoSubEstandarBL
    {
        public List<AccidenteActoSubEstandarBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                return AccidenteActoSubEstandar.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteActoSubEstandarBE Selecciona(int IdAccidenteActoSubEstandar)
        {
            try
            {
                AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                AccidenteActoSubEstandarBE objEmp = AccidenteActoSubEstandar.Selecciona(IdAccidenteActoSubEstandar);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteActoSubEstandarBE pItem)
        {
            try
            {
                AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                AccidenteActoSubEstandar.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteActoSubEstandarBE pItem)
        {
            try
            {
                AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                AccidenteActoSubEstandar.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteActoSubEstandarBE pItem)
        {
            try
            {
                AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                AccidenteActoSubEstandar.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
