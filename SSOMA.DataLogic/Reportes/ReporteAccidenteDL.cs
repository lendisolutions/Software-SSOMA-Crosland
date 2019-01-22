using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteAccidenteDL
    {
        public List<ReporteAccidenteBE> ListadoResponsable(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteResponsable");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio =reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoPotencialDanio(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPotencialDanio, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidentePotencialDanio");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdPotencialDanio", DbType.Int32, IdPotencialDanio);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoTipoAccidente(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoAccidente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteTipoAccidente");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, IdTipoAccidente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoParteLesionada(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdParteLesionada, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteParteLesionada");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, IdParteLesionada);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoTipoLesion(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoLesion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteTipoLesion");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, IdTipoLesion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoFuenteLesion(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFuenteLesion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteFuenteLesion");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, IdFuenteLesion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoActoSubEstandar(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdActoSubEstandar, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteActoSubEstandar");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidente.DescActoSubEstandar = reader["DescActoSubEstandar"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCondicionSubEstandar(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdCondicionSubEstandar, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCondicionSubEstandar");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidente.DescCondicionSubEstandar = reader["DescCondicionSubEstandar"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoFactorPersonal(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFactorPersonal, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteFactorPersonal");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, IdFactorPersonal);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidente.DescFactorPersonal = reader["DescFactorPersonal"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoFactorTrabajo(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFactorTrabajo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteFactorTrabajo");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0,10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidente.DescFactorTrabajo = reader["DescFactorTrabajo"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectiva(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteAccionCorrectiva");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0, 10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                ReporteAccidente.ResponsableAccionCorrectiva = reader["ResponsableAccionCorrectiva"].ToString();
                ReporteAccidente.FechaCumplimiento = reader["FechaCumplimiento"].ToString().Substring(0, 10);
                ReporteAccidente.DescSituacion = reader["DescSituacion"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectivaVencida()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteAccionCorrectivaVencida");
            

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.DescDanio = reader["DescDanio"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.TipoMaterial = reader["TipoMaterial"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteAccidente.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                ReporteAccidente.DniResponsableAccionCorrectiva = reader["DniResponsableAccionCorrectiva"].ToString();
                ReporteAccidente.ResponsableAccionCorrectiva = reader["ResponsableAccionCorrectiva"].ToString();
                ReporteAccidente.FechaCumplimiento = reader["FechaCumplimiento"].ToString().Substring(0, 10);
                ReporteAccidente.DescSituacion = reader["DescSituacion"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectivaVencidaResponsable(string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteAccionCorrectivaVencidaResponsable");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.DescDanio = reader["DescDanio"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.TipoMaterial = reader["TipoMaterial"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteAccidente.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                ReporteAccidente.DniResponsableAccionCorrectiva = reader["DniResponsableAccionCorrectiva"].ToString();
                ReporteAccidente.ResponsableAccionCorrectiva = reader["ResponsableAccionCorrectiva"].ToString();
                ReporteAccidente.FechaCumplimiento = reader["FechaCumplimiento"].ToString().Substring(0, 10);
                ReporteAccidente.DescSituacion = reader["DescSituacion"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualNegocio(int IdTipo , int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoAnualNegocio");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescNegocio = reader["DescNegocio"].ToString();
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualEmpresaResponsable(int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoAnualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualUnidadMineraResponsable(int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoAnualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualNegocio(int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadAnualNegocio");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescNegocio = reader["DescNegocio"].ToString();
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualEmpresaResponsable(int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadAnualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualUnidadMineraResponsable(int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadAnualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualNegocio(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoMensualNegocio");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescNegocio = reader["DescNegocio"].ToString();
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualEmpresaResponsable(int Periodo, int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoMensualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualUnidadMineraResponsable(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoMensualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualNegocio(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadMensualNegocio");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.DescNegocio = reader["DescNegocio"].ToString();
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualEmpresaResponsable(int Periodo, int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadMensualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualUnidadMineraResponsable(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadMensualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.Mes = reader["Mes"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoEmpresaContratista(int IdTipo, int IdEmpresaContratista,  DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Numero = reader["Numero"].ToString();
                ReporteAccidente.Responsable = reader["Responsable"].ToString();
                ReporteAccidente.Dni = reader["Dni"].ToString();
                ReporteAccidente.Edad = Int32.Parse(reader["Edad"].ToString());
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ReporteAccidente.Cargo = reader["Cargo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteAccidente.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteAccidente.JefeDirecto = reader["JefeDirecto"].ToString();
                ReporteAccidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                ReporteAccidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                ReporteAccidente.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteAccidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteAccidente.FechaInicio = reader["FechaInicio"].ToString().Substring(0, 10);
                ReporteAccidente.Lugar = reader["Lugar"].ToString();
                ReporteAccidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                ReporteAccidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                ReporteAccidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                ReporteAccidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                ReporteAccidente.Porque = reader["Porque"].ToString();
                ReporteAccidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                ReporteAccidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                ReporteAccidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                ReporteAccidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                ReporteAccidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                ReporteAccidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                ReporteAccidente.Descripcion = reader["Descripcion"].ToString();
                ReporteAccidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                ReporteAccidente.RevisadoPor = reader["RevisadoPor"].ToString();
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualEmpresaContratista(int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCostoAnualEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualEmpresaContratista(int IdTipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidenteCantidadAnualEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccidenteBE> ReporteAccidentelist = new List<ReporteAccidenteBE>();
            ReporteAccidenteBE ReporteAccidente;
            while (reader.Read())
            {
                ReporteAccidente = new ReporteAccidenteBE();
                ReporteAccidente.DescTipo = reader["DescTipo"].ToString();
                ReporteAccidente.Periodo = reader["Periodo"].ToString();
                ReporteAccidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteAccidente.Logo = (byte[])reader["Logo"];
                ReporteAccidente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteAccidentelist.Add(ReporteAccidente);
            }
            reader.Close();
            reader.Dispose();
            return ReporteAccidentelist;
        }
    }
}
