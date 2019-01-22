using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteSolicitudEppDL
    {
        public List<ReporteSolicitudEppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudEppPorVencer");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudEppBE> ReporteSolicitudEpplist = new List<ReporteSolicitudEppBE>();
            ReporteSolicitudEppBE ReporteSolicitudEpp;
            while (reader.Read())
            {
                ReporteSolicitudEpp = new ReporteSolicitudEppBE();
                ReporteSolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                ReporteSolicitudEpp.Logo = (byte[])reader["Logo"];
                ReporteSolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteSolicitudEpp.DescArea = reader["DescArea"].ToString();
                ReporteSolicitudEpp.Numero = reader["Numero"].ToString();
                ReporteSolicitudEpp.Jefe = reader["Jefe"].ToString();
                ReporteSolicitudEpp.Responsable = reader["Responsable"].ToString();
                ReporteSolicitudEpp.Cargo = reader["Cargo"].ToString();
                ReporteSolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteSolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteSolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteSolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                ReporteSolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ReporteSolicitudEpp.Situacion = reader["Situacion"].ToString();
                ReporteSolicitudEpp.Dias = Int32.Parse(reader["Dias"].ToString());
                ReporteSolicitudEpplist.Add(ReporteSolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSolicitudEpplist;
        }

        public List<ReporteSolicitudEppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudEppVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudEppBE> ReporteSolicitudEpplist = new List<ReporteSolicitudEppBE>();
            ReporteSolicitudEppBE ReporteSolicitudEpp;
            while (reader.Read())
            {
                ReporteSolicitudEpp = new ReporteSolicitudEppBE();
                ReporteSolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                ReporteSolicitudEpp.Logo = (byte[])reader["Logo"];
                ReporteSolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteSolicitudEpp.DescArea = reader["DescArea"].ToString();
                ReporteSolicitudEpp.Numero = reader["Numero"].ToString();
                ReporteSolicitudEpp.Jefe = reader["Jefe"].ToString();
                ReporteSolicitudEpp.Responsable = reader["Responsable"].ToString();
                ReporteSolicitudEpp.Cargo = reader["Cargo"].ToString();
                ReporteSolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteSolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteSolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteSolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                ReporteSolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ReporteSolicitudEpp.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteSolicitudEpp.Situacion = reader["Situacion"].ToString();
                ReporteSolicitudEpp.Dias = Int32.Parse(reader["Dias"].ToString());
                ReporteSolicitudEpplist.Add(ReporteSolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSolicitudEpplist;
        }
    }
}
