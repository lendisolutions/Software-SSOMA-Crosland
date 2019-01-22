using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteExtintorServicioBL
    {
        public List<ReporteExtintorServicioBE> ListaServicio(int IdEmpresa, int IdUnidadMinera, int IdTipoServicio)
        {
            try
            {
                ReporteExtintorServicioDL Extintor = new ReporteExtintorServicioDL();
                return Extintor.ListaServicio(IdEmpresa, IdUnidadMinera, IdTipoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
