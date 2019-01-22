using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class KardexBL
    {
        public List<KardexBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, string TipoMovimiento)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaTodosActivo(IdEmpresa, IdUnidadMinera, DescOrdenInterna, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public KardexBE Selecciona(int IdKardex)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                KardexBE objEmp = Kardex.Selecciona(IdKardex);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaInventario(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, int IdEquipo, DateTime Fecha)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaInventario(IdEmpresa, IdUnidadMinera, DescOrdenInterna, IdEquipo, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaInventarioDetalle(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, int IdEquipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaInventarioDetalle(IdEmpresa, IdUnidadMinera, DescOrdenInterna, IdEquipo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public void Inserta(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
