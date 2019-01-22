using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PeligroBL
    {
        public List<PeligroBE> ListaTodosActivo(int IdEmpresa, int IdTipoPeligro)
        {
            try
            {
                PeligroDL Peligro = new PeligroDL();
                return Peligro.ListaTodosActivo(IdEmpresa, IdTipoPeligro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PeligroBE Selecciona(int IdPeligro)
        {
            try
            {
                PeligroDL Peligro = new PeligroDL();
                PeligroBE objEmp = Peligro.Selecciona(IdPeligro);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(PeligroBE pItem)
        {
            try
            {
                PeligroDL Peligro = new PeligroDL();
                Peligro.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PeligroBE pItem)
        {
            try
            {
                PeligroDL Peligro = new PeligroDL();
                Peligro.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PeligroBE pItem)
        {
            try
            {
                PeligroDL Peligro = new PeligroDL();
                Peligro.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
