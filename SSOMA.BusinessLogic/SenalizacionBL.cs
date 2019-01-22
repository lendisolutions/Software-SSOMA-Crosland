using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class SenalizacionBL
    {
        public List<SenalizacionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                return Senalizacion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SenalizacionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                return Senalizacion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SenalizacionBE Selecciona(int IdSenalizacion)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                SenalizacionBE objEmp = Senalizacion.Selecciona(IdSenalizacion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SenalizacionBE pItem)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                Senalizacion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SenalizacionBE pItem)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                Senalizacion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SenalizacionBE pItem)
        {
            try
            {
                SenalizacionDL Senalizacion = new SenalizacionDL();
                Senalizacion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
