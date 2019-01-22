using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CategoriaDiagnosticoBL
    {
        public List<CategoriaDiagnosticoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                return CategoriaDiagnostico.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CategoriaDiagnosticoBE> ListaCombo(int IdEmpresa, int IdCategoriaDiagnostico)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                return CategoriaDiagnostico.ListaCombo(IdEmpresa, IdCategoriaDiagnostico);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CategoriaDiagnosticoBE Selecciona(int IdEmpresa, int IdCategoriaDiagnostico)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                CategoriaDiagnosticoBE objEmp = CategoriaDiagnostico.Selecciona(IdEmpresa, IdCategoriaDiagnostico);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CategoriaDiagnosticoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                CategoriaDiagnosticoBE objEmp = CategoriaDiagnostico.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CategoriaDiagnosticoBE pItem)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                CategoriaDiagnostico.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CategoriaDiagnosticoBE pItem)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                CategoriaDiagnostico.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CategoriaDiagnosticoBE pItem)
        {
            try
            {
                CategoriaDiagnosticoDL CategoriaDiagnostico = new CategoriaDiagnosticoDL();
                CategoriaDiagnostico.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
