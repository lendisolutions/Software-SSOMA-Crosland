using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ServicioExtintorBL
    {
        public List<ServicioExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                return ServicioExtintor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ServicioExtintorBE> ListaCombo(int IdEmpresa, int IdServicioExtintor)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                return ServicioExtintor.ListaCombo(IdEmpresa, IdServicioExtintor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ServicioExtintorBE Selecciona(int IdEmpresa, int IdServicioExtintor)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                ServicioExtintorBE objEmp = ServicioExtintor.Selecciona(IdEmpresa, IdServicioExtintor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ServicioExtintorBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                ServicioExtintorBE objEmp = ServicioExtintor.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ServicioExtintorBE pItem)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                ServicioExtintor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ServicioExtintorBE pItem)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                ServicioExtintor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ServicioExtintorBE pItem)
        {
            try
            {
                ServicioExtintorDL ServicioExtintor = new ServicioExtintorDL();
                ServicioExtintor.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
