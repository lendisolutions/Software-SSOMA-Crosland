using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ExpositorBL
    {
        public List<ExpositorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                return Expositor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExpositorBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                return Expositor.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExpositorBE Selecciona(int IdEmpresa, int IdExpositor)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                ExpositorBE objEmp = Expositor.Selecciona(IdEmpresa, IdExpositor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExpositorBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                ExpositorBE objEmp = Expositor.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ExpositorBE pItem)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                Expositor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ExpositorBE pItem)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                Expositor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ExpositorBE pItem)
        {
            try
            {
                ExpositorDL Expositor = new ExpositorDL();
                Expositor.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
