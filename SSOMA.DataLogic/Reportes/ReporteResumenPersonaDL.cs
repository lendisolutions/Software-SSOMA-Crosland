using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteResumenPersonaDL
    {
        public List<ReporteResumenPersonaBE> Listado(int IdEmpresa, int IdTema, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.RazonSocial = reader["RazonSocial"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.DescTema = reader["DescTema"].ToString();
                ReporteResumenPersona.ApeNom = reader["ApeNom"].ToString();
                ReporteResumenPersona.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteResumenPersona.NotaFinal = Int32.Parse(reader["NotaFinal"].ToString());
                ReporteResumenPersona.Situacion = reader["Situacion"].ToString();
                ReporteResumenPersona.Firma1 = (byte[])reader["Firma1"];
                ReporteResumenPersona.Firma2 = (byte[])reader["Firma2"];
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }

        public List<ReporteResumenPersonaBE> ListadoAsistencia(int IdEmpresa, int IdTema, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersonaAsistencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.RazonSocial = reader["RazonSocial"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.DescTema = reader["DescTema"].ToString();
                ReporteResumenPersona.FechaIni = reader["FechaIni"].ToString().Substring(0, 10);
                ReporteResumenPersona.Horas = Int32.Parse(reader["Horas"].ToString());
                ReporteResumenPersona.Responsable = reader["Responsable"].ToString();
                ReporteResumenPersona.ResponsableCargo = reader["ResponsableCargo"].ToString();
                ReporteResumenPersona.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                ReporteResumenPersona.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteResumenPersona.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteResumenPersona.NotaFinal = Int32.Parse(reader["NotaFinal"].ToString());
                ReporteResumenPersona.Situacion = reader["Situacion"].ToString();
                ReporteResumenPersona.Dni = reader["Dni"].ToString();
                ReporteResumenPersona.ApeNom = reader["ApeNom"].ToString();
                ReporteResumenPersona.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteResumenPersona.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }

        public List<ReporteResumenPersonaBE> ListadoHorasAnualEmpresaResponsable()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersonaHorasAnualEmpresaResponsable");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.Periodo = reader["Periodo"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteResumenPersona.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }

        public List<ReporteResumenPersonaBE> ListadoHorasAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersonaHorasAnualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.Periodo = reader["Periodo"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteResumenPersona.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteResumenPersona.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }

        public List<ReporteResumenPersonaBE> ListadoHorasMensualEmpresaResponsable(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersonaHorasMensualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.Periodo = reader["Periodo"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.Mes = reader["Mes"].ToString();
                ReporteResumenPersona.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteResumenPersona.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }

        public List<ReporteResumenPersonaBE> ListadoHorasMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersonaHorasMensualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.Periodo = reader["Periodo"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.Mes = reader["Mes"].ToString();
                ReporteResumenPersona.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteResumenPersona.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteResumenPersona.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }
    }
}
