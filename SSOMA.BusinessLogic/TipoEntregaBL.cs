using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoEntregaBL
    {
        public List<TipoEntregaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                return TipoEntrega.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoEntregaBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                return TipoEntrega.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoEntregaBE Selecciona(int IdEmpresa, int IdTipoEntrega)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                TipoEntregaBE objEmp = TipoEntrega.Selecciona(IdEmpresa, IdTipoEntrega);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoEntregaBE pItem)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                TipoEntrega.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoEntregaBE pItem)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                TipoEntrega.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoEntregaBE pItem)
        {
            try
            {
                TipoEntregaDL TipoEntrega = new TipoEntregaDL();
                TipoEntrega.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
