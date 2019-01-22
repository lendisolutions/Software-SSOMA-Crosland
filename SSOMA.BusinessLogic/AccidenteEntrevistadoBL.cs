using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteEntrevistadoBL
    {
        public List<AccidenteEntrevistadoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                return AccidenteEntrevistado.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteEntrevistadoBE Selecciona(int IdAccidenteEntrevistado)
        {
            try
            {
                AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                AccidenteEntrevistadoBE objEmp = AccidenteEntrevistado.Selecciona(IdAccidenteEntrevistado);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteEntrevistadoBE pItem)
        {
            try
            {
                AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                AccidenteEntrevistado.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteEntrevistadoBE pItem)
        {
            try
            {
                AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                AccidenteEntrevistado.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteEntrevistadoBE pItem)
        {
            try
            {
                AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                AccidenteEntrevistado.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
