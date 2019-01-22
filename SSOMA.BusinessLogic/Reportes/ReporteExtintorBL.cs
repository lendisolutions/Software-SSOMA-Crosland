using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteExtintorBL
    {
        public List<ReporteExtintorBE> ListaVencido(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ReporteExtintorDL Extintor = new ReporteExtintorDL();
                return Extintor.ListaVencido(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteExtintorBE> ListaUbicacion(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ReporteExtintorDL Extintor = new ReporteExtintorDL();
                return Extintor.ListaUbicacion(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
