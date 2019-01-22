using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteFotoBL
    {
        public List<AccidenteFotoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                return AccidenteFoto.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteFotoBE Selecciona(int IdAccidenteFoto)
        {
            try
            {
                AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                AccidenteFotoBE objEmp = AccidenteFoto.Selecciona(IdAccidenteFoto);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteFotoBE pItem)
        {
            try
            {
                AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                AccidenteFoto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteFotoBE pItem)
        {
            try
            {
                AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                AccidenteFoto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteFotoBE pItem)
        {
            try
            {
                AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                AccidenteFoto.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
