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
    public class ReporteDocumentoPersonaBL
    {
        public List<ReporteDocumentoPersonaBE> ListadoResponsable(int IdEmpresa, int IdPersona)
        {
            try
            {
                ReporteDocumentoPersonaDL Documento = new ReporteDocumentoPersonaDL();
                return Documento.ListadoResponsable(IdEmpresa, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
