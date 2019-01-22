using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteEquipoBL
    {
        public List<ReporteEquipoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteEquipoDL Equipo = new ReporteEquipoDL();
                return Equipo.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
