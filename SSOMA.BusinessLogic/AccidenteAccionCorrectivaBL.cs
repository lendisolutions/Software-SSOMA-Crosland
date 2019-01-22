using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteAccionCorrectivaBL
    {
        public List<AccidenteAccionCorrectivaBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                return AccidenteAccionCorrectiva.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteAccionCorrectivaBE Selecciona(int IdAccidenteAccionCorrectiva)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                AccidenteAccionCorrectivaBE objEmp = AccidenteAccionCorrectiva.Selecciona(IdAccidenteAccionCorrectiva);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteAccionCorrectivaBE pItem)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                AccidenteAccionCorrectiva.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteAccionCorrectivaBE pItem)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                AccidenteAccionCorrectiva.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdAccidenteAccionCorrectiva, int IdSituacion)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                AccidenteAccionCorrectiva.ActualizaSituacion(IdAccidenteAccionCorrectiva, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteAccionCorrectivaBE pItem)
        {
            try
            {
                AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                AccidenteAccionCorrectiva.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
