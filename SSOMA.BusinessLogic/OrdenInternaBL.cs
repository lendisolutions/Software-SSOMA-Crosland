using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class OrdenInternaBL
    {
        public List<OrdenInternaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                return OrdenInterna.ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public OrdenInternaBE Selecciona(int IdEmpresa, int IdUnidadMinera, int IdOrdenInterna)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                OrdenInternaBE objEmp = OrdenInterna.Selecciona(IdEmpresa, IdUnidadMinera, IdOrdenInterna);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public OrdenInternaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                OrdenInternaBE objEmp = OrdenInterna.SeleccionaDescripcion(IdEmpresa, IdUnidadMinera, DescOrdenInterna);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(OrdenInternaBE pItem)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                OrdenInterna.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(OrdenInternaBE pItem)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                OrdenInterna.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(OrdenInternaBE pItem)
        {
            try
            {
                OrdenInternaDL OrdenInterna = new OrdenInternaDL();
                OrdenInterna.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
