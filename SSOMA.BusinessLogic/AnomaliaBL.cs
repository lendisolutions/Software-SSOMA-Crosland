using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AnomaliaBL
    {
        public List<AnomaliaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                return Anomalia.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AnomaliaBE> ListaCombo(int IdEmpresa, int IdAnomalia)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                return Anomalia.ListaCombo(IdEmpresa, IdAnomalia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AnomaliaBE Selecciona(int IdEmpresa, int IdAnomalia)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                AnomaliaBE objEmp = Anomalia.Selecciona(IdEmpresa, IdAnomalia);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AnomaliaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                AnomaliaBE objEmp = Anomalia.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AnomaliaBE pItem)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                Anomalia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AnomaliaBE pItem)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                Anomalia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AnomaliaBE pItem)
        {
            try
            {
                AnomaliaDL Anomalia = new AnomaliaDL();
                Anomalia.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
