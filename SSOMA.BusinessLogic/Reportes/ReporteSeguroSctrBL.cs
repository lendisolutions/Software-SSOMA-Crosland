using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;
namespace SSOMA.BusinessLogic
{
    public class ReporteSeguroSctrBL
    {
        public List<ReporteSeguroSctrBE> ListaFecha(int IdEmpresa, int IdPersona, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSeguroSctrDL ReporteSeguroSctr = new ReporteSeguroSctrDL();
                return ReporteSeguroSctr.ListaFecha(IdEmpresa, IdPersona, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
