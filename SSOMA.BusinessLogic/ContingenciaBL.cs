using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ContingenciaBL
    {
        public List<ContingenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                return Contingencia.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ContingenciaBE> ListaCombo(int IdEmpresa, int IdContingencia)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                return Contingencia.ListaCombo(IdEmpresa, IdContingencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ContingenciaBE Selecciona(int IdEmpresa, int IdContingencia)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                ContingenciaBE objEmp = Contingencia.Selecciona(IdEmpresa, IdContingencia);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ContingenciaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                ContingenciaBE objEmp = Contingencia.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ContingenciaBE pItem)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                Contingencia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ContingenciaBE pItem)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                Contingencia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ContingenciaBE pItem)
        {
            try
            {
                ContingenciaDL Contingencia = new ContingenciaDL();
                Contingencia.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
