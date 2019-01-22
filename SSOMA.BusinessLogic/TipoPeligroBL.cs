using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class TipoPeligroBL
    {
        public List<TipoPeligroBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                return TipoPeligro.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoPeligroBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                return TipoPeligro.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoPeligroBE Selecciona(int IdTipoPeligro)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                TipoPeligroBE objEmp = TipoPeligro.Selecciona(IdTipoPeligro);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoPeligroBE pItem)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                TipoPeligro.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoPeligroBE pItem)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                TipoPeligro.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoPeligroBE pItem)
        {
            try
            {
                TipoPeligroDL TipoPeligro = new TipoPeligroDL();
                TipoPeligro.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
