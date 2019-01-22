using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteSolicitudBL
    {
        public List<ReporteSolicitudBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSolicitudDL ReporteSolicitud = new ReporteSolicitudDL();
                return ReporteSolicitud.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
