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
    public class ReporteRespuestaPersonaBL
    {
        public List<ReporteRespuestaPersonaBE> Listado(int IdTema, int IdPersona)
        {
            try
            {
                ReporteRespuestaPersonaDL Pregunta = new ReporteRespuestaPersonaDL();
                return Pregunta.Listado(IdTema,IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
