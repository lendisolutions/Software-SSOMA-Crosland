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
    public class ReportePreguntaBL
    {
        public List<ReportePreguntaBE> Listado(int IdCuestionario)
        {
            try
            {
                ReportePreguntaDL Pregunta = new ReportePreguntaDL();
                return Pregunta.Listado(IdCuestionario);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
