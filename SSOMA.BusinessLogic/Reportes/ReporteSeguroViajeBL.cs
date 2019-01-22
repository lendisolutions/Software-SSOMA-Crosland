using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class ReporteSeguroViajeBL
    {
        public List<ReporteSeguroViajeBE> ListaFecha(int IdEmpresa, int IdPersona,  int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSeguroViajeDL ReporteSeguroViaje = new ReporteSeguroViajeDL();
                return ReporteSeguroViaje.ListaFecha(IdEmpresa, IdPersona, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
