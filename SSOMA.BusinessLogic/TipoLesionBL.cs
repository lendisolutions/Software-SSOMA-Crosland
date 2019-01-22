using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoLesionBL
    {
        public List<TipoLesionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                return TipoLesion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoLesionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                return TipoLesion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoLesionBE Selecciona(int IdTipoLesion)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                TipoLesionBE objEmp = TipoLesion.Selecciona(IdTipoLesion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoLesionBE pItem)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                TipoLesion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoLesionBE pItem)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                TipoLesion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoLesionBE pItem)
        {
            try
            {
                TipoLesionDL TipoLesion = new TipoLesionDL();
                TipoLesion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
