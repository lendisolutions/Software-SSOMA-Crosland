using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CapacitacionDL
    {
        public CapacitacionDL() { }

        public Int32 Inserta(CapacitacionBE pItem)
        {
            Int32 intIdCapacitacion = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_Inserta");

            db.AddOutParameter(dbCommand, "pIdCapacitacion", DbType.Int32, pItem.IdCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pParticipantes", DbType.Int32, pItem.Participantes);
            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdClasificacionCapacitacion", DbType.Int32, pItem.IdClasificacionCapacitacion);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, pItem.IdExpositor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCapacitacion = (int)db.GetParameterValue(dbCommand, "pIdCapacitacion");

            return intIdCapacitacion;

        }

        public void Actualiza(CapacitacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, pItem.IdCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pParticipantes", DbType.Int32, pItem.Participantes);
            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdClasificacionCapacitacion", DbType.Int32, pItem.IdClasificacionCapacitacion);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, pItem.IdExpositor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdCapacitacion, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, IdCapacitacion);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(CapacitacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_Elimina");

            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, pItem.IdCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CapacitacionBE Selecciona(int idCapacitacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_Selecciona");
            db.AddInParameter(dbCommand, "pidCapacitacion", DbType.Int32, idCapacitacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CapacitacionBE Capacitacion = null;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Capacitacion;
        }

        public CapacitacionBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CapacitacionBE Capacitacion = null;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Capacitacion;
        }

        public List<CapacitacionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }

        public List<CapacitacionBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.DescProveedor = reader["DescProveedor"].ToString();
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }

        public List<CapacitacionBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }

        //public List<CapacitacionBE> ListaPersonaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaPersonaFecha");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
        //    db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
        //    db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
        //    db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
        //    db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
        //    CapacitacionBE Capacitacion;
        //    while (reader.Read())
        //    {
        //        Capacitacion = new CapacitacionBE();
        //        Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
        //        Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
        //        Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdEmpresa"].ToString());
        //        Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
        //        Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
        //        Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
        //        Capacitacion.Numero = reader["Numero"].ToString();
        //        Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
        //        Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
        //        Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
        //        Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
        //        Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
        //        Capacitacion.DescLugar = reader["DescLugar"].ToString();
        //        Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
        //        Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
        //        Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
        //        Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
        //        Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
        //        Capacitacion.DescTema = reader["DescTema"].ToString();
        //        Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
        //        Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
        //        Capacitacion.Codigo = reader["Codigo"].ToString();
        //        Capacitacion.ApeNom = reader["ApeNom"].ToString();
        //        Capacitacion.DescArea = reader["DescArea"].ToString();
        //        Capacitacion.Horas = Int32.Parse(reader["Horas"].ToString());
        //        Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
        //        Capacitacionlist.Add(Capacitacion);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return Capacitacionlist;
        //}

        public List<CapacitacionBE> ListaPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaPersonaFecha");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.Codigo = reader["Codigo"].ToString();
                Capacitacion.ApeNom = reader["ApeNom"].ToString();
                Capacitacion.DescArea = reader["DescArea"].ToString();
                Capacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }

        public List<CapacitacionBE> ListaAprobado(int IdEmpresa, int IdTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaAprobado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.Codigo = reader["Codigo"].ToString();
                Capacitacion.ApeNom = reader["ApeNom"].ToString();
                Capacitacion.DescArea = reader["DescArea"].ToString();
                Capacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                Capacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }

        public List<CapacitacionBE> ListaDesaprobado(int IdEmpresa, int IdTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Capacitacion_ListaDesaprobado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionBE> Capacitacionlist = new List<CapacitacionBE>();
            CapacitacionBE Capacitacion;
            while (reader.Read())
            {
                Capacitacion = new CapacitacionBE();
                Capacitacion.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                Capacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Capacitacion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Capacitacion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Capacitacion.RazonSocial = reader["RazonSocial"].ToString();
                Capacitacion.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Capacitacion.Numero = reader["Numero"].ToString();
                Capacitacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Capacitacion.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Capacitacion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Capacitacion.Participantes = Int32.Parse(reader["Participantes"].ToString());
                Capacitacion.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                Capacitacion.DescLugar = reader["DescLugar"].ToString();
                Capacitacion.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Capacitacion.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Capacitacion.IdClasificacionCapacitacion = Int32.Parse(reader["IdClasificacionCapacitacion"].ToString());
                Capacitacion.DescClasificacionCapacitacion = reader["DescClasificacionCapacitacion"].ToString();
                Capacitacion.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Capacitacion.DescTema = reader["DescTema"].ToString();
                Capacitacion.IdExpositor = Int32.Parse(reader["IdExpositor"].ToString());
                Capacitacion.DescExpositor = reader["DescExpositor"].ToString();
                Capacitacion.Codigo = reader["Codigo"].ToString();
                Capacitacion.ApeNom = reader["ApeNom"].ToString();
                Capacitacion.DescArea = reader["DescArea"].ToString();
                Capacitacion.Nota = Int32.Parse(reader["Nota"].ToString());
                Capacitacion.Horas = Decimal.Parse(reader["Horas"].ToString());
                Capacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Capacitacionlist.Add(Capacitacion);
            }
            reader.Close();
            reader.Dispose();
            return Capacitacionlist;
        }
    }
}
