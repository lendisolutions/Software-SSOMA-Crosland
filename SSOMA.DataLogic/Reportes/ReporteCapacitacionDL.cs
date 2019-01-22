using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteCapacitacionDL
    {
        public List<ReporteCapacitacionBE> Listado(int IdCapacitacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacion");
            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, IdCapacitacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescEmpresa = reader["DescEmpresa"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.CargoExpositor = reader["CargoExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionPersonaFecha");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoProveedorFecha(int IdProveedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionProveedorFecha");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoExpositorFecha(int IdExpositor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionExpositorFecha");
            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, IdExpositor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoTemaFecha(int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionTemaFecha");
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoTipoFecha(int IdEmpresa, int IdTipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionTipoFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoClasificacionFecha(int IdClasificacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionClasificacionFecha");
            db.AddInParameter(dbCommand, "pIdClasificacion", DbType.Int32, IdClasificacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoAprobadaFecha(int IdEmpresa, int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionAprobadaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.EmpresaPersona = reader["EmpresaPersona"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoDesaprobadaFecha(int IdEmpresa, int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionDesaprobadaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Ruc = reader["Ruc"].ToString();
                ReporteCapacitacion.Direccion = reader["Direccion"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescProveedor = reader["DescProveedor"].ToString();
                ReporteCapacitacion.Numero = reader["Numero"].ToString();
                ReporteCapacitacion.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteCapacitacion.FechaIni = Right(reader["FechaIni"].ToString(), 8);
                ReporteCapacitacion.FechaFin = Right(reader["FechaFin"].ToString(), 8);
                ReporteCapacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                ReporteCapacitacion.DescLugar = reader["DescLugar"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.DescTema = reader["DescTema"].ToString();
                ReporteCapacitacion.DescExpositor = reader["DescExpositor"].ToString();
                ReporteCapacitacion.Item = Int32.Parse(reader["Item"].ToString());
                ReporteCapacitacion.Codigo = reader["Codigo"].ToString();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.EmpresaPersona = reader["EmpresaPersona"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualEmpresaResponsable()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualEmpresaResponsable");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualNegocio(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualNegocio");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescNegocio = reader["DescNegocio"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualAreaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteCapacitacion.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualTipo(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualTipo");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualClasificacion(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasAnualClasificacion");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualEmpresaResponsable(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualNegocio(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualNegocio");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescNegocio = reader["DescNegocio"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualAreaResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualAreaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteCapacitacion.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualTipo(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualTipo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualClasificacion(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionHorasMensualClasificacion");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.Periodo = reader["Periodo"].ToString();
                ReporteCapacitacion.Mes = reader["Mes"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteCapacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                ReporteCapacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }

        public List<ReporteCapacitacionBE> ListadoInasistencia(int IdEmpresa, int Periodo, int IdTipoCapacitacion, int IdClasificacionCapacitacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCapacitacionInasistencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdClasificacionCapacitacion", DbType.Int32, IdClasificacionCapacitacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCapacitacionBE> ReporteCapacitacionlist = new List<ReporteCapacitacionBE>();
            ReporteCapacitacionBE ReporteCapacitacion;
            while (reader.Read())
            {
                ReporteCapacitacion = new ReporteCapacitacionBE();
                ReporteCapacitacion.ApeNom = reader["ApeNom"].ToString();
                ReporteCapacitacion.RazonSocial = reader["RazonSocial"].ToString();
                ReporteCapacitacion.Logo = (byte[])reader["Logo"];
                ReporteCapacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteCapacitacion.DescArea = reader["DescArea"].ToString();
                ReporteCapacitacion.Cargo = reader["Cargo"].ToString();
                ReporteCapacitacionlist.Add(ReporteCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCapacitacionlist;
        }


        public  string Right(string sValue, int iMaxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return sValue;
        }
    }
}
