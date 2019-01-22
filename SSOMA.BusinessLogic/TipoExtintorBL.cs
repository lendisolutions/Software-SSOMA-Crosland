using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoExtintorBL
    {
        public List<TipoExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                return TipoExtintor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoExtintorBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                return TipoExtintor.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoExtintorBE Selecciona(int IdTipoExtintor)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                TipoExtintorBE objEmp = TipoExtintor.Selecciona(IdTipoExtintor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoExtintorBE pItem)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                TipoExtintor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoExtintorBE pItem)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                TipoExtintor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoExtintorBE pItem)
        {
            try
            {
                TipoExtintorDL TipoExtintor = new TipoExtintorDL();
                TipoExtintor.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
