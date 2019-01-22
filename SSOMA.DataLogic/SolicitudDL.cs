using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SolicitudDL
    {
        public SolicitudDL() { }

        public Int32 Inserta(SolicitudBE pItem)
        {
            Int32 intIdSolicitud = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitud", DbType.Int32, pItem.IdSolicitud);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdSolicitud = (int)db.GetParameterValue(dbCommand, "pIdSolicitud");

            return intIdSolicitud;

        }

        public void Actualiza(SolicitudBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitud", DbType.Int32, pItem.IdSolicitud);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdSolicitud, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdSolicitud", DbType.Int32, IdSolicitud);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdSolicitud, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdSolicitud", DbType.Int32, IdSolicitud);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(SolicitudBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitud", DbType.Int32, pItem.IdSolicitud);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SolicitudBE Selecciona(int idSolicitud)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_Selecciona");
            db.AddInParameter(dbCommand, "pidSolicitud", DbType.Int32, idSolicitud);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudBE Solicitud = null;
            while (reader.Read())
            {
                Solicitud = new SolicitudBE();
                Solicitud.IdSolicitud = Int32.Parse(reader["idSolicitud"].ToString());
                Solicitud.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Solicitud.RazonSocial = reader["RazonSocial"].ToString();
                Solicitud.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Solicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Solicitud.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Solicitud.DescArea = reader["DescArea"].ToString();
                Solicitud.Numero = reader["Numero"].ToString();
                Solicitud.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Solicitud.Solicitante = reader["Solicitante"].ToString();
                Solicitud.Cargo = reader["Cargo"].ToString();
                Solicitud.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Solicitud.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Solicitud.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Solicitud.DescSituacion = reader["DescSituacion"].ToString();
                Solicitud.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Solicitud;
        }

        public SolicitudBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudBE Solicitud = null;
            while (reader.Read())
            {
                Solicitud = new SolicitudBE();
                Solicitud.IdSolicitud = Int32.Parse(reader["idSolicitud"].ToString());
                Solicitud.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Solicitud.RazonSocial = reader["RazonSocial"].ToString();
                Solicitud.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Solicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Solicitud.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Solicitud.DescArea = reader["DescArea"].ToString();
                Solicitud.Numero = reader["Numero"].ToString();
                Solicitud.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Solicitud.Solicitante = reader["Solicitante"].ToString();
                Solicitud.Cargo = reader["Cargo"].ToString();
                Solicitud.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Solicitud.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Solicitud.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Solicitud.DescSituacion = reader["DescSituacion"].ToString();
                Solicitud.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Solicitud;
        }

        public List<SolicitudBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudBE> Solicitudlist = new List<SolicitudBE>();
            SolicitudBE Solicitud;
            while (reader.Read())
            {
                Solicitud = new SolicitudBE();
                Solicitud.IdSolicitud = Int32.Parse(reader["idSolicitud"].ToString());
                Solicitud.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Solicitud.RazonSocial = reader["RazonSocial"].ToString();
                Solicitud.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Solicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Solicitud.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Solicitud.DescArea = reader["DescArea"].ToString();
                Solicitud.Numero = reader["Numero"].ToString();
                Solicitud.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Solicitud.Solicitante = reader["Solicitante"].ToString();
                Solicitud.Cargo = reader["Cargo"].ToString();
                Solicitud.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Solicitud.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Solicitud.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Solicitud.DescSituacion = reader["DescSituacion"].ToString();
                Solicitud.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Solicitudlist.Add(Solicitud);
            }
            reader.Close();
            reader.Dispose();
            return Solicitudlist;
        }

        public List<SolicitudBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudBE> Solicitudlist = new List<SolicitudBE>();
            SolicitudBE Solicitud;
            while (reader.Read())
            {
                Solicitud = new SolicitudBE();
                Solicitud.IdSolicitud = Int32.Parse(reader["idSolicitud"].ToString());
                Solicitud.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Solicitud.RazonSocial = reader["RazonSocial"].ToString();
                Solicitud.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Solicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Solicitud.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Solicitud.DescArea = reader["DescArea"].ToString();
                Solicitud.Numero = reader["Numero"].ToString();
                Solicitud.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Solicitud.Solicitante = reader["Solicitante"].ToString();
                Solicitud.Cargo = reader["Cargo"].ToString();
                Solicitud.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Solicitud.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Solicitud.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Solicitud.DescSituacion = reader["DescSituacion"].ToString();
                Solicitud.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
               
                Solicitudlist.Add(Solicitud);
            }
            reader.Close();
            reader.Dispose();
            return Solicitudlist;
        }

        public List<SolicitudBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Solicitud_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudBE> Solicitudlist = new List<SolicitudBE>();
            SolicitudBE Solicitud;
            while (reader.Read())
            {
                Solicitud = new SolicitudBE();
                Solicitud.IdSolicitud = Int32.Parse(reader["idSolicitud"].ToString());
                Solicitud.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Solicitud.RazonSocial = reader["RazonSocial"].ToString();
                Solicitud.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Solicitud.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Solicitud.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Solicitud.DescArea = reader["DescArea"].ToString();
                Solicitud.Numero = reader["Numero"].ToString();
                Solicitud.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Solicitud.Solicitante = reader["Solicitante"].ToString();
                Solicitud.Cargo = reader["Cargo"].ToString();
                Solicitud.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Solicitud.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Solicitud.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Solicitud.DescSituacion = reader["DescSituacion"].ToString();
                Solicitud.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Solicitudlist.Add(Solicitud);
            }
            reader.Close();
            reader.Dispose();
            return Solicitudlist;
        }

        
    }
}
