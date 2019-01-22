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
    public class ReporteDocumentoBL
    {
        public List<ReporteDocumentoBE> ListadoResponsable(int IdEmpresa, int IdCarpeta)
        {
            try
            {
                ReporteDocumentoDL Documento = new ReporteDocumentoDL();
                return Documento.ListadoResponsable(IdEmpresa,IdCarpeta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
