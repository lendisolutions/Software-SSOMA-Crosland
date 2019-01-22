using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class InspeccionTrabajoDetalleDL
    {
        public InspeccionTrabajoDetalleDL() { }

        public void Inserta(InspeccionTrabajoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajoDetalle", DbType.Int32, pItem.IdInspeccionTrabajoDetalle);
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, pItem.IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pCondicionSubEstandar", DbType.String, pItem.CondicionSubEstandar);
            db.AddInParameter(dbCommand, "pAccionCorrectiva", DbType.String, pItem.AccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaEjecucion", DbType.DateTime, pItem.FechaEjecucion);
            db.AddInParameter(dbCommand, "pFotoCumplimiento", DbType.Binary, pItem.FotoCumplimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(InspeccionTrabajoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajoDetalle", DbType.Int32, pItem.IdInspeccionTrabajoDetalle);
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, pItem.IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pCondicionSubEstandar", DbType.String, pItem.CondicionSubEstandar);
            db.AddInParameter(dbCommand, "pAccionCorrectiva", DbType.String, pItem.AccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaEjecucion", DbType.DateTime, pItem.FechaEjecucion);
            db.AddInParameter(dbCommand, "pFotoCumplimiento", DbType.Binary, pItem.FotoCumplimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdInspeccionTrabajoDetalle, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajoDetalle", DbType.Int32, IdInspeccionTrabajoDetalle);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InspeccionTrabajoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajoDetalle", DbType.Int32, pItem.IdInspeccionTrabajoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public InspeccionTrabajoDetalleBE Selecciona(int IdInspeccionTrabajoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidInspeccionTrabajoDetalle", DbType.Int32, IdInspeccionTrabajoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspeccionTrabajoDetalleBE InspeccionTrabajoDetalle = null;
            while (reader.Read())
            {
                InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                InspeccionTrabajoDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajoDetalle.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = Int32.Parse(reader["idInspeccionTrabajoDetalle"].ToString());
                InspeccionTrabajoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                InspeccionTrabajoDetalle.Foto = (byte[])reader["Foto"];
                InspeccionTrabajoDetalle.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                InspeccionTrabajoDetalle.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                InspeccionTrabajoDetalle.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                InspeccionTrabajoDetalle.Responsable = reader["Responsable"].ToString();
                InspeccionTrabajoDetalle.FechaEjecucion = reader.IsDBNull(reader.GetOrdinal("FechaEjecucion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEjecucion"));
                InspeccionTrabajoDetalle.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                InspeccionTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                InspeccionTrabajoDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                InspeccionTrabajoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                InspeccionTrabajoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajoDetalle;
        }

        public List<InspeccionTrabajoDetalleBE> ListaTodosActivo(int IdInspeccionTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, IdInspeccionTrabajo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoDetalleBE> InspeccionTrabajoDetallelist = new List<InspeccionTrabajoDetalleBE>();
            InspeccionTrabajoDetalleBE InspeccionTrabajoDetalle;
            while (reader.Read())
            {
                InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                InspeccionTrabajoDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajoDetalle.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = Int32.Parse(reader["idInspeccionTrabajoDetalle"].ToString());
                InspeccionTrabajoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                InspeccionTrabajoDetalle.Foto = (byte[])reader["Foto"];
                InspeccionTrabajoDetalle.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                InspeccionTrabajoDetalle.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                InspeccionTrabajoDetalle.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                InspeccionTrabajoDetalle.Responsable = reader["Responsable"].ToString();
                InspeccionTrabajoDetalle.FechaEjecucion = reader.IsDBNull(reader.GetOrdinal("FechaEjecucion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEjecucion"));
                InspeccionTrabajoDetalle.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                InspeccionTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                InspeccionTrabajoDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                InspeccionTrabajoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                InspeccionTrabajoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajoDetalle.TipoOper = 4; //CONSULTAR
                InspeccionTrabajoDetallelist.Add(InspeccionTrabajoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajoDetallelist;
        }

        public List<InspeccionTrabajoDetalleBE> ListaTipo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdTipoInspeccion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_ListaTipo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoDetalleBE> InspeccionTrabajoDetallelist = new List<InspeccionTrabajoDetalleBE>();
            InspeccionTrabajoDetalleBE InspeccionTrabajoDetalle;
            while (reader.Read())
            {
                InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                InspeccionTrabajoDetalle.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajoDetalle.Logo = (byte[])reader["Logo"];
                InspeccionTrabajoDetalle.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajoDetalle.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajoDetalle.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajoDetalle.Numero = reader["Numero"].ToString();
                InspeccionTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajoDetalle.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajoDetalle.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajoDetalle.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajoDetalle.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                InspeccionTrabajoDetalle.Foto = (byte[])reader["Foto"];
                InspeccionTrabajoDetalle.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                InspeccionTrabajoDetalle.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                InspeccionTrabajoDetalle.Responsable = reader["Responsable"].ToString();
                InspeccionTrabajoDetalle.FechaEjecucion = reader.IsDBNull(reader.GetOrdinal("FechaEjecucion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEjecucion"));
                InspeccionTrabajoDetalle.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                InspeccionTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                InspeccionTrabajoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                InspeccionTrabajoDetallelist.Add(InspeccionTrabajoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajoDetallelist;
        }

        public List<InspeccionTrabajoDetalleBE> ListaSituacion(int IdInspeccionTrabajo, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_ListaSituacion");
            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoDetalleBE> InspeccionTrabajoDetallelist = new List<InspeccionTrabajoDetalleBE>();
            InspeccionTrabajoDetalleBE InspeccionTrabajoDetalle;
            while (reader.Read())
            {
                InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                InspeccionTrabajoDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajoDetalle.Logo = (byte[])reader["Logo"];
                InspeccionTrabajoDetalle.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = Int32.Parse(reader["idInspeccionTrabajoDetalle"].ToString());
                InspeccionTrabajoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                InspeccionTrabajoDetalle.Foto = (byte[])reader["Foto"];
                InspeccionTrabajoDetalle.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                InspeccionTrabajoDetalle.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                InspeccionTrabajoDetalle.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                InspeccionTrabajoDetalle.Responsable = reader["Responsable"].ToString();
                InspeccionTrabajoDetalle.FechaEjecucion = reader.IsDBNull(reader.GetOrdinal("FechaEjecucion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEjecucion"));
                InspeccionTrabajoDetalle.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                InspeccionTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                InspeccionTrabajoDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                InspeccionTrabajoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                InspeccionTrabajoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajoDetalle.TipoOper = 4; //CONSULTAR
                InspeccionTrabajoDetallelist.Add(InspeccionTrabajoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajoDetallelist;
        }

        public List<InspeccionTrabajoDetalleBE> ListaEmpresaContratista(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajoDetalle_ListaEmpresaContratista");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoDetalleBE> InspeccionTrabajoDetallelist = new List<InspeccionTrabajoDetalleBE>();
            InspeccionTrabajoDetalleBE InspeccionTrabajoDetalle;
            while (reader.Read())
            {
                InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                InspeccionTrabajoDetalle.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajoDetalle.Logo = (byte[])reader["Logo"];
                InspeccionTrabajoDetalle.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajoDetalle.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajoDetalle.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajoDetalle.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajoDetalle.Numero = reader["Numero"].ToString();
                InspeccionTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajoDetalle.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajoDetalle.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajoDetalle.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajoDetalle.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                InspeccionTrabajoDetalle.Foto = (byte[])reader["Foto"];
                InspeccionTrabajoDetalle.CondicionSubEstandar = reader["CondicionSubEstandar"].ToString();
                InspeccionTrabajoDetalle.AccionCorrectiva = reader["AccionCorrectiva"].ToString();
                InspeccionTrabajoDetalle.Responsable = reader["Responsable"].ToString();
                InspeccionTrabajoDetalle.FechaEjecucion = reader.IsDBNull(reader.GetOrdinal("FechaEjecucion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEjecucion"));
                InspeccionTrabajoDetalle.FotoCumplimiento = (byte[])reader["FotoCumplimiento"];
                InspeccionTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                InspeccionTrabajoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                InspeccionTrabajoDetallelist.Add(InspeccionTrabajoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajoDetallelist;
        }
    }
}
