using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ClasificacionExtintorBL
    {
        public List<ClasificacionExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                return ClasificacionExtintor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClasificacionExtintorBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                return ClasificacionExtintor.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClasificacionExtintorBE Selecciona(int IdClasificacionExtintor)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                ClasificacionExtintorBE objEmp = ClasificacionExtintor.Selecciona(IdClasificacionExtintor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClasificacionExtintorBE pItem)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                ClasificacionExtintor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClasificacionExtintorBE pItem)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                ClasificacionExtintor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClasificacionExtintorBE pItem)
        {
            try
            {
                ClasificacionExtintorDL ClasificacionExtintor = new ClasificacionExtintorDL();
                ClasificacionExtintor.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
