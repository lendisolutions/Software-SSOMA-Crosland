using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteMedidaPrevencionBL
    {
        public List<AccidenteMedidaPrevencionBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                return AccidenteMedidaPrevencion.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteMedidaPrevencionBE Selecciona(int IdAccidenteMedidaPrevencion)
        {
            try
            {
                AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                AccidenteMedidaPrevencionBE objEmp = AccidenteMedidaPrevencion.Selecciona(IdAccidenteMedidaPrevencion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteMedidaPrevencionBE pItem)
        {
            try
            {
                AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                AccidenteMedidaPrevencion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteMedidaPrevencionBE pItem)
        {
            try
            {
                AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                AccidenteMedidaPrevencion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteMedidaPrevencionBE pItem)
        {
            try
            {
                AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                AccidenteMedidaPrevencion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
