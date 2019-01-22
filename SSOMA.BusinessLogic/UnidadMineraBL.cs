using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class UnidadMineraBL
    {
        public List<UnidadMineraBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                return UnidadMinera.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UnidadMineraBE> ListaCombo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                return UnidadMinera.ListaCombo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UnidadMineraBE Selecciona(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMineraBE objEmp = UnidadMinera.Selecciona(IdEmpresa, IdUnidadMinera);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UnidadMineraBE SeleccionaDescripcion(int IdEmpresa, string DescUnidadMinera)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMineraBE objEmp = UnidadMinera.SeleccionaDescripcion(IdEmpresa, DescUnidadMinera);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UnidadMineraBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMineraBE objEmp = UnidadMinera.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(UnidadMineraBE pItem)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMinera.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(UnidadMineraBE pItem)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMinera.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(UnidadMineraBE pItem)
        {
            try
            {
                UnidadMineraDL UnidadMinera = new UnidadMineraDL();
                UnidadMinera.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
