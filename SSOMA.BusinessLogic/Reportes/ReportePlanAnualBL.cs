using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class ReportePlanAnualBL
    {
        public List<ReportePlanAnualBE> Listado(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            try
            {
                ReportePlanAnualDL PlanAnual = new ReportePlanAnualDL();
                return PlanAnual.Listado(IdEmpresa, IdUnidadMinera, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
