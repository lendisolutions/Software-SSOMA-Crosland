using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteTestigoBL
    {
        public List<AccidenteTestigoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                return AccidenteTestigo.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteTestigoBE Selecciona(int IdAccidenteTestigo)
        {
            try
            {
                AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                AccidenteTestigoBE objEmp = AccidenteTestigo.Selecciona(IdAccidenteTestigo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteTestigoBE pItem)
        {
            try
            {
                AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                AccidenteTestigo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteTestigoBE pItem)
        {
            try
            {
                AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                AccidenteTestigo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteTestigoBE pItem)
        {
            try
            {
                AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                AccidenteTestigo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
