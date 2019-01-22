using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class NegocioBL
    {
        public List<NegocioBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                return Negocio.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<NegocioBE> ListaCombo(int IdEmpresa, int IdNegocio)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                return Negocio.ListaCombo(IdEmpresa, IdNegocio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public NegocioBE Selecciona(int IdEmpresa, int IdNegocio)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                NegocioBE objEmp = Negocio.Selecciona(IdEmpresa, IdNegocio);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public NegocioBE SeleccionaDescripcion(int IdEmpresa, string DescNegocio)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                NegocioBE objEmp = Negocio.SeleccionaDescripcion(IdEmpresa, DescNegocio);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public NegocioBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                NegocioBE objEmp = Negocio.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(NegocioBE pItem)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                Negocio.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(NegocioBE pItem)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                Negocio.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(NegocioBE pItem)
        {
            try
            {
                NegocioDL Negocio = new NegocioDL();
                Negocio.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
