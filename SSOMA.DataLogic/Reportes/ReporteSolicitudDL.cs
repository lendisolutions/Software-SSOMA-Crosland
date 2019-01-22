using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteSolicitudDL
    {
        public List<ReporteSolicitudBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudBE> ReporteSolicitudlist = new List<ReporteSolicitudBE>();
            ReporteSolicitudBE ReporteSolicitud;
            while (reader.Read())
            {
                ReporteSolicitud = new ReporteSolicitudBE();
                ReporteSolicitud.RazonSocial = reader["RazonSocial"].ToString();
                ReporteSolicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteSolicitud.DescArea = reader["DescArea"].ToString();
                ReporteSolicitud.Numero = reader["Numero"].ToString();
                ReporteSolicitud.Solicitante = reader["Solicitante"].ToString();
                ReporteSolicitud.Cargo = reader["Cargo"].ToString();
                ReporteSolicitud.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteSolicitud.FechaIngreso = reader["FechaIngreso"].ToString().Substring(0, 10);
                ReporteSolicitud.DescSituacion = reader["DescSituacion"].ToString();
                ReporteSolicitudlist.Add(ReporteSolicitud);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSolicitudlist;
        }
    }
}
