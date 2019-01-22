using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CondicionDescansoMedicoBL
    {
        public List<CondicionDescansoMedicoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                return CondicionDescansoMedico.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CondicionDescansoMedicoBE> ListaCombo(int IdEmpresa, int IdCondicionDescansoMedico)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                return CondicionDescansoMedico.ListaCombo(IdEmpresa, IdCondicionDescansoMedico);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CondicionDescansoMedicoBE Selecciona(int IdEmpresa, int IdCondicionDescansoMedico)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                CondicionDescansoMedicoBE objEmp = CondicionDescansoMedico.Selecciona(IdEmpresa, IdCondicionDescansoMedico);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CondicionDescansoMedicoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                CondicionDescansoMedicoBE objEmp = CondicionDescansoMedico.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CondicionDescansoMedicoBE pItem)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                CondicionDescansoMedico.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CondicionDescansoMedicoBE pItem)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                CondicionDescansoMedico.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CondicionDescansoMedicoBE pItem)
        {
            try
            {
                CondicionDescansoMedicoDL CondicionDescansoMedico = new CondicionDescansoMedicoDL();
                CondicionDescansoMedico.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
