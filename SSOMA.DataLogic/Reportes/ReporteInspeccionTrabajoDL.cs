using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;



namespace SSOMA.DataLogic
{
    public class ReporteInspeccionTrabajoDL
    {
        public List<ReporteInspeccionTrabajoBE> Listado(int IdInspeccionTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajo");
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, IdInspeccionTrabajo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Ruc = reader["Ruc"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.Direccion = reader["Direccion"].ToString();
                ReporteInspeccionTrabajo.ActividadEconomica = reader["ActividadEconomica"].ToString();
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                ReporteInspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                ReporteInspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                ReporteInspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ReporteInspeccionTrabajo.Numero = reader["Numero"].ToString();
                ReporteInspeccionTrabajo.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteInspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteInspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                ReporteInspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                ReporteInspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ReporteInspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                ReporteInspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                ReporteInspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                ReporteInspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                ReporteInspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                ReporteInspeccionTrabajo.Item = Int32.Parse(reader["Item"].ToString());
                ReporteInspeccionTrabajo.Foto = (byte[])reader["Foto"];
                ReporteInspeccionTrabajo.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                ReporteInspeccionTrabajo.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                ReporteInspeccionTrabajo.Responsable = reader["Responsable"].ToString();
                ReporteInspeccionTrabajo.FechaEjecucion = reader["FechaEjecucion"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                ReporteInspeccionTrabajo.Observacion = reader["Observacion"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoPendiente(int IdInspeccionTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoPendiente");
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, IdInspeccionTrabajo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Ruc = reader["Ruc"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.Direccion = reader["Direccion"].ToString();
                ReporteInspeccionTrabajo.ActividadEconomica = reader["ActividadEconomica"].ToString();
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                ReporteInspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                ReporteInspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ReporteInspeccionTrabajo.Numero = reader["Numero"].ToString();
                ReporteInspeccionTrabajo.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                ReporteInspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                ReporteInspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                ReporteInspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ReporteInspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                ReporteInspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                ReporteInspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                ReporteInspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                ReporteInspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                ReporteInspeccionTrabajo.Item = Int32.Parse(reader["Item"].ToString());
                ReporteInspeccionTrabajo.Foto = (byte[])reader["Foto"];
                ReporteInspeccionTrabajo.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                ReporteInspeccionTrabajo.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                ReporteInspeccionTrabajo.Responsable = reader["Responsable"].ToString();
                ReporteInspeccionTrabajo.FechaEjecucion = reader["FechaEjecucion"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                ReporteInspeccionTrabajo.Observacion = reader["Observacion"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacion(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.Numero = reader["Numero"].ToString();
                ReporteInspeccionTrabajo.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.Item = Int32.Parse(reader["Item"].ToString());
                ReporteInspeccionTrabajo.Foto = (byte[])reader["Foto"];
                ReporteInspeccionTrabajo.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                ReporteInspeccionTrabajo.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                ReporteInspeccionTrabajo.Responsable = reader["Responsable"].ToString();
                ReporteInspeccionTrabajo.FechaEjecucion = reader["FechaEjecucion"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                ReporteInspeccionTrabajo.Observacion = reader["Observacion"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualEmpresa(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionAnualEmpresa");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo= reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionMesualEmpresa(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionMensualEmpresa");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo = reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.Mes = reader["Mes"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualSede(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionAnualSede");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo = reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionMesualSede(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionMensualSede");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo = reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.Mes = reader["Mes"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoTipoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoTipoFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionSede(int IdEmpresa, int IdUnidadMinera, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionSede");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.Numero = reader["Numero"].ToString();
                ReporteInspeccionTrabajo.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.Item = Int32.Parse(reader["Item"].ToString());
                ReporteInspeccionTrabajo.Foto = (byte[])reader["Foto"];
                ReporteInspeccionTrabajo.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                ReporteInspeccionTrabajo.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                ReporteInspeccionTrabajo.Responsable = reader["Responsable"].ToString();
                ReporteInspeccionTrabajo.FechaEjecucion = reader["FechaEjecucion"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                ReporteInspeccionTrabajo.Observacion = reader["Observacion"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoConsolidado(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoConsolidado");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo = reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.Mes = reader["Mes"].ToString();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualEmpresaContratista(int IdEmpresaContratista)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionAnualEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, IdEmpresaContratista);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.Periodo = reader["Periodo"].ToString();
                ReporteInspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoTipoFechaEmpresaContratista(int IdEmpresaContratista, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoTipoFechaEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ReporteInspeccionTrabajo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionEmpresaContratista(int IdEmpresaContratista, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInspeccionTrabajoSituacionEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInspeccionTrabajoBE> ReporteInspeccionTrabajolist = new List<ReporteInspeccionTrabajoBE>();
            ReporteInspeccionTrabajoBE ReporteInspeccionTrabajo;
            while (reader.Read())
            {
                ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoBE();
                ReporteInspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                ReporteInspeccionTrabajo.Logo = (byte[])reader["Logo"];
                ReporteInspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteInspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                ReporteInspeccionTrabajo.Numero = reader["Numero"].ToString();
                ReporteInspeccionTrabajo.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.Item = Int32.Parse(reader["Item"].ToString());
                ReporteInspeccionTrabajo.Foto = (byte[])reader["Foto"];
                ReporteInspeccionTrabajo.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                ReporteInspeccionTrabajo.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                ReporteInspeccionTrabajo.Responsable = reader["Responsable"].ToString();
                ReporteInspeccionTrabajo.FechaEjecucion = reader["FechaEjecucion"].ToString().Substring(0, 10);
                ReporteInspeccionTrabajo.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                ReporteInspeccionTrabajo.Observacion = reader["Observacion"].ToString();
                ReporteInspeccionTrabajo.DescSituacion = reader["DescSituacion"].ToString();
                ReporteInspeccionTrabajolist.Add(ReporteInspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return ReporteInspeccionTrabajolist;
        }
    }
}
