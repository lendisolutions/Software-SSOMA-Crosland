using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EppDL
    {
        public EppDL() { }

        public Int32 Inserta(EppBE pItem)
        {
            Int32 intIdEpp = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_Inserta");

            db.AddOutParameter(dbCommand, "pIdEpp", DbType.Int32, pItem.IdEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdEpp = (int)db.GetParameterValue(dbCommand, "pIdEpp");

            return intIdEpp;

        }

        public void Actualiza(EppBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_Actualiza");

            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, pItem.IdEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdEpp, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, IdEpp);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(EppBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_Elimina");

            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, pItem.IdEpp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public EppBE Selecciona(int idEpp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_Selecciona");
            db.AddInParameter(dbCommand, "pidEpp", DbType.Int32, idEpp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EppBE Epp = null;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Epp;
        }

        public EppBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EppBE Epp = null;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Epp;
        }

        public List<EppBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable,  int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaFechaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                Epp.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea, int Dias)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaPorVencer");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, Dias);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.Item = Int32.Parse(reader["Item"].ToString());
                Epp.Codigo = reader["Codigo"].ToString();
                Epp.DescEquipo = reader["DescEquipo"].ToString();
                Epp.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Epp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Epp.Precio = Decimal.Parse(reader["Precio"].ToString());
                Epp.Total = Decimal.Parse(reader["Total"].ToString());
                Epp.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                Epp.Dias = Int32.Parse(reader["Dias"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }

        public List<EppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Epp_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppBE> Epplist = new List<EppBE>();
            EppBE Epp;
            while (reader.Read())
            {
                Epp = new EppBE();
                Epp.RazonSocial = reader["RazonSocial"].ToString();
                Epp.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Epp.DescArea = reader["DescArea"].ToString();
                Epp.Numero = reader["Numero"].ToString();
                Epp.NumeroSolicitud = reader["NumeroSolicitud"].ToString();
                Epp.Responsable = reader["Responsable"].ToString();
                Epp.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Epp.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Epp.AreaResponsable = reader["AreaResponsable"].ToString();
                Epp.SectorResponsable = reader["SectorResponsable"].ToString();
                Epp.Cargo = reader["Cargo"].ToString();
                Epp.DescNegocio = reader["DescNegocio"].ToString();
                Epp.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Epp.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Epp.Observacion = reader["Observacion"].ToString();
                Epp.Item = Int32.Parse(reader["Item"].ToString());
                Epp.Codigo = reader["Codigo"].ToString();
                Epp.DescEquipo = reader["DescEquipo"].ToString();
                Epp.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Epp.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Epp.Precio = Decimal.Parse(reader["Precio"].ToString());
                Epp.Total = Decimal.Parse(reader["Total"].ToString());
                Epp.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                Epp.Dias = Int32.Parse(reader["Dias"].ToString());
                Epplist.Add(Epp);
            }
            reader.Close();
            reader.Dispose();
            return Epplist;
        }
    }
}
