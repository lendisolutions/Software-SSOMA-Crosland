using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteEppDL
    {
        public List<ReporteEppBE> Listado(int IdEpp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEpp");
            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, IdEpp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.RazonSocial = reader["RazonSocial"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteEpp.DescArea = reader["DescArea"].ToString();
                ReporteEpp.Numero = reader["Numero"].ToString();
                ReporteEpp.Responsable = reader["Responsable"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                ReporteEpp.Cargo = reader["Cargo"].ToString();
                ReporteEpp.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteEpp.Observacion = reader["Observacion"].ToString();
                ReporteEpp.Item = Int32.Parse(reader["Item"].ToString());
                ReporteEpp.Codigo = reader["Codigo"].ToString();
                ReporteEpp.DescEquipo = reader["DescEquipo"].ToString();
                ReporteEpp.FechaVencimiento = reader["FechaVencimiento"].ToString().Substring(0,10);
                ReporteEpp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteEpp.Precio = Decimal.Parse(reader["Precio"].ToString());
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpp.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoPorPersona(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppPersona");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdPersonaResponsable", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.RazonSocial = reader["RazonSocial"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteEpp.DescArea = reader["DescArea"].ToString();
                ReporteEpp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                ReporteEpp.Numero = reader["Numero"].ToString();
                ReporteEpp.Responsable = reader["Responsable"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Cargo = reader["Cargo"].ToString();
                ReporteEpp.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteEpp.Observacion = reader["Observacion"].ToString();
                ReporteEpp.Item = Int32.Parse(reader["Item"].ToString());
                ReporteEpp.Codigo = reader["Codigo"].ToString();
                ReporteEpp.DescEquipo = reader["DescEquipo"].ToString();
                ReporteEpp.FechaVencimiento = reader["FechaVencimiento"].ToString().Substring(0,10);
                ReporteEpp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteEpp.Precio = Decimal.Parse(reader["Precio"].ToString());
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpp.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoPersonaConsumo(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppPersonaConsumo");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Responsable = reader["Responsable"].ToString();
                ReporteEpp.Cargo = reader["Cargo"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoPorTipoEntrega(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoEntrega, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppTipoEntrega");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, IdTipoEntrega);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.RazonSocial = reader["RazonSocial"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteEpp.DescArea = reader["DescArea"].ToString();
                ReporteEpp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                ReporteEpp.Numero = reader["Numero"].ToString();
                ReporteEpp.Responsable = reader["Responsable"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Cargo = reader["Cargo"].ToString();
                ReporteEpp.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteEpp.Observacion = reader["Observacion"].ToString();
                ReporteEpp.Item = Int32.Parse(reader["Item"].ToString());
                ReporteEpp.Codigo = reader["Codigo"].ToString();
                ReporteEpp.DescEquipo = reader["DescEquipo"].ToString();
                ReporteEpp.FechaVencimiento = reader["FechaVencimiento"].ToString().Substring(0,10);
                ReporteEpp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteEpp.Precio = Decimal.Parse(reader["Precio"].ToString());
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpp.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoEmpresaResponsable(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppEmpresaResponsable");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoUnidadMineraResponsable(int IdEmpresaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppAreaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoEquipo(int IdEmpresaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppEquipo");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescEquipo = reader["DescEquipo"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoRegistroEntrega(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppRegistroEntrega");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                ReporteEpp.Numero = reader["Numero"].ToString();
                ReporteEpp.Responsable = reader["Responsable"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Cargo = reader["Cargo"].ToString();
                ReporteEpp.Fecha = reader["Fecha"].ToString().Substring(0,10);
                ReporteEpp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoAnualEmpresaResponsable()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoAnualEmpresaResponsable");
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoAnualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoAnualNegocio(int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoAnualNegocio");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescNegocio = reader["DescNegocio"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoAnualAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoAnualAreaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoAnualSectorResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoAnualSectorResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoMensualEmpresaResponsable(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoMensualEmpresaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.Mes = reader["Mes"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoMensualUnidadMineraResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.Mes = reader["Mes"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoMensualNegocio(int Periodo, int IdEmpresaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoMensualNegocio");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.Mes = reader["Mes"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.DescNegocio = reader["DescNegocio"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        

        public List<ReporteEppBE> ListadoConsumoMensualAreaResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoMensualAreaResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.Mes = reader["Mes"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoMensualSectorResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoMensualSectorResponsable");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.Periodo = reader["Periodo"].ToString();
                ReporteEpp.Mes = reader["Mes"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }

        public List<ReporteEppBE> ListadoConsumoResumen(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEppConsumoResumen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEppBE> ReporteEpplist = new List<ReporteEppBE>();
            ReporteEppBE ReporteEpp;
            while (reader.Read())
            {
                ReporteEpp = new ReporteEppBE();
                ReporteEpp.DescNegocio = reader["DescNegocio"].ToString();
                ReporteEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                ReporteEpp.Logo = (byte[])reader["Logo"];
                ReporteEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                ReporteEpp.Total = Decimal.Parse(reader["Total"].ToString());
                ReporteEpplist.Add(ReporteEpp);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEpplist;
        }
    }
}
