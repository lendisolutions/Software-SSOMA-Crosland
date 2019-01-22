using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteCondicionSubEstandarBL
    {
        public List<AccidenteCondicionSubEstandarBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                return AccidenteCondicionSubEstandar.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteCondicionSubEstandarBE Selecciona(int IdAccidenteCondicionSubEstandar)
        {
            try
            {
                AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                AccidenteCondicionSubEstandarBE objEmp = AccidenteCondicionSubEstandar.Selecciona(IdAccidenteCondicionSubEstandar);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteCondicionSubEstandarBE pItem)
        {
            try
            {
                AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                AccidenteCondicionSubEstandar.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteCondicionSubEstandarBE pItem)
        {
            try
            {
                AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                AccidenteCondicionSubEstandar.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteCondicionSubEstandarBE pItem)
        {
            try
            {
                AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                AccidenteCondicionSubEstandar.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
