using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteDocumentoBL
    {
        public List<AccidenteDocumentoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                return AccidenteDocumento.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteDocumentoBE Selecciona(int IdAccidenteDocumento)
        {
            try
            {
                AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                AccidenteDocumentoBE objEmp = AccidenteDocumento.Selecciona(IdAccidenteDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteDocumentoBE pItem)
        {
            try
            {
                AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                AccidenteDocumento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteDocumentoBE pItem)
        {
            try
            {
                AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                AccidenteDocumento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteDocumentoBE pItem)
        {
            try
            {
                AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                AccidenteDocumento.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
