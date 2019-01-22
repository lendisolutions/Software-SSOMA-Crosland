using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteSeguroSctrDL
    {
        public List<ReporteSeguroSctrBE> ListaFecha(int IdEmpresa, int IdPersona, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSctrListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSeguroSctrBE> ReporteSeguroSctrlist = new List<ReporteSeguroSctrBE>();
            ReporteSeguroSctrBE ReporteSeguroSctr;
            while (reader.Read())
            {
                ReporteSeguroSctr = new ReporteSeguroSctrBE();
                ReporteSeguroSctr.RazonSocial = reader["RazonSocial"].ToString();
                ReporteSeguroSctr.Numero = reader["Numero"].ToString();
                ReporteSeguroSctr.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteSeguroSctr.Mes = Int32.Parse(reader["Mes"].ToString());
                ReporteSeguroSctr.DescMes = reader["DescMes"].ToString();
                ReporteSeguroSctr.TipoDocumento = reader["TipoDocumento"].ToString();
                ReporteSeguroSctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteSeguroSctr.Solicitante = reader["Solicitante"].ToString();
                ReporteSeguroSctr.Sexo = reader["Sexo"].ToString();
                ReporteSeguroSctr.Cargo = reader["Cargo"].ToString();
                ReporteSeguroSctr.FechaNacimiento = reader["FechaNacimiento"].ToString().Substring(0,10);
                ReporteSeguroSctr.Nacionalidad = reader["Nacionalidad"].ToString();
                ReporteSeguroSctr.DescSituacion = reader["DescSituacion"].ToString();
                ReporteSeguroSctrlist.Add(ReporteSeguroSctr);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSeguroSctrlist;
        }
    }
}
