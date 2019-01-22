using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class SustitucionBL
    {
        public List<SustitucionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                return Sustitucion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SustitucionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                return Sustitucion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SustitucionBE Selecciona(int IdSustitucion)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                SustitucionBE objEmp = Sustitucion.Selecciona(IdSustitucion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SustitucionBE pItem)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                Sustitucion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SustitucionBE pItem)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                Sustitucion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SustitucionBE pItem)
        {
            try
            {
                SustitucionDL Sustitucion = new SustitucionDL();
                Sustitucion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
