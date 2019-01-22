using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class ReporteSolicitudEppBL
    {
        public List<ReporteSolicitudEppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                ReporteSolicitudEppDL ReporteSolicitudEpp = new ReporteSolicitudEppDL();
                return ReporteSolicitudEpp.ListaPorVencer(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSolicitudEppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                ReporteSolicitudEppDL ReporteSolicitudEpp = new ReporteSolicitudEppDL();
                return ReporteSolicitudEpp.ListaVencido(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
