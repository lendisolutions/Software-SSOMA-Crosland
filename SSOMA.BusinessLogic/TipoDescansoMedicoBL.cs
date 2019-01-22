using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoDescansoMedicoBL
    {
        public List<TipoDescansoMedicoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                return TipoDescansoMedico.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoDescansoMedicoBE> ListaCombo(int IdEmpresa, int IdTipoDescansoMedico)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                return TipoDescansoMedico.ListaCombo(IdEmpresa, IdTipoDescansoMedico);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoDescansoMedicoBE Selecciona(int IdEmpresa, int IdTipoDescansoMedico)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                TipoDescansoMedicoBE objEmp = TipoDescansoMedico.Selecciona(IdEmpresa, IdTipoDescansoMedico);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoDescansoMedicoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                TipoDescansoMedicoBE objEmp = TipoDescansoMedico.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoDescansoMedicoBE pItem)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                TipoDescansoMedico.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoDescansoMedicoBE pItem)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                TipoDescansoMedico.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoDescansoMedicoBE pItem)
        {
            try
            {
                TipoDescansoMedicoDL TipoDescansoMedico = new TipoDescansoMedicoDL();
                TipoDescansoMedico.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
