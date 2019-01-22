using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SolicitudEppDL
    {
        public SolicitudEppDL() { }

        public Int32 Inserta(SolicitudEppBE pItem)
        {
            Int32 intIdSolicitudEpp = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdJefe", DbType.Int32, pItem.IdJefe);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdSolicitudEpp = (int)db.GetParameterValue(dbCommand, "pIdSolicitudEpp");

            return intIdSolicitudEpp;

        }

        public void Actualiza(SolicitudEppBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdJefe", DbType.Int32, pItem.IdJefe);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdSolicitudEpp, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            
            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdSolicitudEpp, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(SolicitudEppBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SolicitudEppBE Selecciona(int idSolicitudEpp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_Selecciona");
            db.AddInParameter(dbCommand, "pidSolicitudEpp", DbType.Int32, idSolicitudEpp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEppBE SolicitudEpp = null;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpp;
        }

        public SolicitudEppBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEppBE SolicitudEpp = null;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpp;
        }

        public List<SolicitudEppBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaFechaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaPorVencer");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpp.Dias = Int32.Parse(reader["Dias"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }

        public List<SolicitudEppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEpp_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppBE> SolicitudEpplist = new List<SolicitudEppBE>();
            SolicitudEppBE SolicitudEpp;
            while (reader.Read())
            {
                SolicitudEpp = new SolicitudEppBE();
                SolicitudEpp.IdSolicitudEpp = Int32.Parse(reader["idSolicitudEpp"].ToString());
                SolicitudEpp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEpp.RazonSocial = reader["RazonSocial"].ToString();
                SolicitudEpp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                SolicitudEpp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                SolicitudEpp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                SolicitudEpp.DescArea = reader["DescArea"].ToString();
                SolicitudEpp.Numero = reader["Numero"].ToString();
                SolicitudEpp.IdJefe = Int32.Parse(reader["IdJefe"].ToString());
                SolicitudEpp.Jefe = reader["Jefe"].ToString();
                SolicitudEpp.CargoJefe = reader["CargoJefe"].ToString();
                SolicitudEpp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEpp.Responsable = reader["Responsable"].ToString();
                SolicitudEpp.Cargo = reader["Cargo"].ToString();
                SolicitudEpp.DescNegocio = reader["DescNegocio"].ToString();
                SolicitudEpp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                SolicitudEpp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                SolicitudEpp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                SolicitudEpp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                SolicitudEpp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                SolicitudEpp.AreaResponsable = reader["AreaResponsable"].ToString();
                SolicitudEpp.SectorResponsable = reader["SectorResponsable"].ToString();
                SolicitudEpp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudEpp.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEpp.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEpp.Situacion = reader["Situacion"].ToString();
                SolicitudEpp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEpp.Dias = Int32.Parse(reader["Dias"].ToString());
                SolicitudEpplist.Add(SolicitudEpp);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEpplist;
        }
    }
}
