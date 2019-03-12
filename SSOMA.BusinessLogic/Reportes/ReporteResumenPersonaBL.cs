using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteResumenPersonaBL
    {
        public List<ReporteResumenPersonaBE> Listado(int IdEmpresa, int IdTema, int IdPersona)
        {
            try
            {
                ReporteResumenPersonaDL ReporteResumenPersona = new ReporteResumenPersonaDL();
                return ReporteResumenPersona.Listado(IdEmpresa,IdTema,IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
