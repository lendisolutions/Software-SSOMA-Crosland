using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReportePlanAnualDL
    {
        public ReportePlanAnualDL() { }

        public List<ReportePlanAnualBE> Listado(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPlanAnual");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePlanAnualBE> ReportePlanAnuallist = new List<ReportePlanAnualBE>();
            ReportePlanAnualBE ReportePlanAnual;
            while (reader.Read())
            {
                ReportePlanAnual = new ReportePlanAnualBE();
                ReportePlanAnual.Item = Int32.Parse(reader["Item"].ToString());
                ReportePlanAnual.RazonSocial = reader["RazonSocial"].ToString();
                ReportePlanAnual.Logo = (byte[])reader["Logo"];
                ReportePlanAnual.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReportePlanAnual.DescTema = reader["DescTema"].ToString();
                ReportePlanAnual.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReportePlanAnual.DescClaseCapacitacion = reader["DescClaseCapacitacion"].ToString();
                ReportePlanAnual.Periodo = Int32.Parse(reader["Periodo"].ToString());
                ReportePlanAnual.DescLugar = reader["DescLugar"].ToString();
                ReportePlanAnual.DescResponsableCapacitacion = reader["DescResponsableCapacitacion"].ToString();
                ReportePlanAnual.FechaCumplimiento = reader["FechaCumplimiento"].ToString();
                ReportePlanAnual.Costo = Decimal.Parse(reader["Costo"].ToString());
              
                ReportePlanAnuallist.Add(ReportePlanAnual);
            }
            reader.Close();
            reader.Dispose();
            return ReportePlanAnuallist;
        }

    }
}
