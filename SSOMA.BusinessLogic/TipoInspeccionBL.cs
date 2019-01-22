using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoInspeccionBL
    {
        public List<TipoInspeccionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                return TipoInspeccion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoInspeccionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                return TipoInspeccion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoInspeccionBE Selecciona(int IdTipoInspeccion)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                TipoInspeccionBE objEmp = TipoInspeccion.Selecciona(IdTipoInspeccion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoInspeccionBE pItem)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                TipoInspeccion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoInspeccionBE pItem)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                TipoInspeccion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoInspeccionBE pItem)
        {
            try
            {
                TipoInspeccionDL TipoInspeccion = new TipoInspeccionDL();
                TipoInspeccion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
