using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class LugarBL
    {
        public List<LugarBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                return Lugar.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LugarBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                return Lugar.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public LugarBE Selecciona(int IdEmpresa, int IdLugar)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                LugarBE objEmp = Lugar.Selecciona(IdEmpresa, IdLugar);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public LugarBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                LugarBE objEmp = Lugar.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(LugarBE pItem)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                Lugar.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(LugarBE pItem)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                Lugar.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(LugarBE pItem)
        {
            try
            {
                LugarDL Lugar = new LugarDL();
                Lugar.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
