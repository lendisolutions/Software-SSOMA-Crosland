using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class EliminacionBL
    {
        public List<EliminacionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                return Eliminacion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EliminacionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                return Eliminacion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EliminacionBE Selecciona(int IdEliminacion)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                EliminacionBE objEmp = Eliminacion.Selecciona(IdEliminacion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EliminacionBE pItem)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                Eliminacion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EliminacionBE pItem)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                Eliminacion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EliminacionBE pItem)
        {
            try
            {
                EliminacionDL Eliminacion = new EliminacionDL();
                Eliminacion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
