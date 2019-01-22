using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteCostoBL
    {
        public List<AccidenteCostoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                return AccidenteCosto.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteCostoBE Selecciona(int IdAccidenteCosto)
        {
            try
            {
                AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                AccidenteCostoBE objEmp = AccidenteCosto.Selecciona(IdAccidenteCosto);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteCostoBE pItem)
        {
            try
            {
                AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                AccidenteCosto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteCostoBE pItem)
        {
            try
            {
                AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                AccidenteCosto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteCostoBE pItem)
        {
            try
            {
                AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                AccidenteCosto.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
