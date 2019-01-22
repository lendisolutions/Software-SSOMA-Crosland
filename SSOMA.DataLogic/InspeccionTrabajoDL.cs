using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class InspeccionTrabajoDL
    {
        public InspeccionTrabajoDL() { }

        public Int32 Inserta(InspeccionTrabajoBE pItem)
        {
            Int32 intIdInspeccionTrabajo = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_Inserta");

            db.AddOutParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, pItem.IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, pItem.IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHora", DbType.DateTime, pItem.Hora);
            db.AddInParameter(dbCommand, "pObjetivo", DbType.String, pItem.Objetivo);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pIdInspeccionadoPor", DbType.Int32, pItem.IdInspeccionadoPor);
            db.AddInParameter(dbCommand, "pIdResponsableArea", DbType.Int32, pItem.IdResponsableArea);
            db.AddInParameter(dbCommand, "pIdResponsableSector", DbType.Int32, pItem.IdResponsableSector);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pPersonaRegistro", DbType.String, pItem.PersonaRegistro);
            db.AddInParameter(dbCommand, "pPersonaCargo", DbType.String, pItem.PersonaCargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdInspeccionTrabajo = (int)db.GetParameterValue(dbCommand, "pIdInspeccionTrabajo");

            return intIdInspeccionTrabajo;

        }

        public void Actualiza(InspeccionTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_Actualiza");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, pItem.IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, pItem.IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHora", DbType.DateTime, pItem.Hora);
            db.AddInParameter(dbCommand, "pObjetivo", DbType.String, pItem.Objetivo);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pIdInspeccionadoPor", DbType.Int32, pItem.IdInspeccionadoPor);
            db.AddInParameter(dbCommand, "pIdResponsableArea", DbType.Int32, pItem.IdResponsableArea);
            db.AddInParameter(dbCommand, "pIdResponsableSector", DbType.Int32, pItem.IdResponsableSector);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pPersonaRegistro", DbType.String, pItem.PersonaRegistro);
            db.AddInParameter(dbCommand, "pPersonaCargo", DbType.String, pItem.PersonaCargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdInspeccionTrabajo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InspeccionTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_Elimina");

            db.AddInParameter(dbCommand, "pIdInspeccionTrabajo", DbType.Int32, pItem.IdInspeccionTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public InspeccionTrabajoBE Selecciona(int idInspeccionTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_Selecciona");
            db.AddInParameter(dbCommand, "pidInspeccionTrabajo", DbType.Int32, idInspeccionTrabajo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspeccionTrabajoBE InspeccionTrabajo = null;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajo;
        }

        public InspeccionTrabajoBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InspeccionTrabajoBE InspeccionTrabajo = null;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajo;
        }

        public List<InspeccionTrabajoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoBE> InspeccionTrabajolist = new List<InspeccionTrabajoBE>();
            InspeccionTrabajoBE InspeccionTrabajo;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajolist.Add(InspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajolist;
        }

        public List<InspeccionTrabajoBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoBE> InspeccionTrabajolist = new List<InspeccionTrabajoBE>();
            InspeccionTrabajoBE InspeccionTrabajo;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajolist.Add(InspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajolist;
        }

        public List<InspeccionTrabajoBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoBE> InspeccionTrabajolist = new List<InspeccionTrabajoBE>();
            InspeccionTrabajoBE InspeccionTrabajo;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajolist.Add(InspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajolist;
        }

        public List<InspeccionTrabajoBE> ListaTipo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdTipoInspeccion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InspeccionTrabajo_ListaTipo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InspeccionTrabajoBE> InspeccionTrabajolist = new List<InspeccionTrabajoBE>();
            InspeccionTrabajoBE InspeccionTrabajo;
            while (reader.Read())
            {
                InspeccionTrabajo = new InspeccionTrabajoBE();
                InspeccionTrabajo.IdInspeccionTrabajo = Int32.Parse(reader["idInspeccionTrabajo"].ToString());
                InspeccionTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InspeccionTrabajo.RazonSocial = reader["RazonSocial"].ToString();
                InspeccionTrabajo.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                InspeccionTrabajo.EmpresaContratista = reader["EmpresaContratista"].ToString();
                InspeccionTrabajo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                InspeccionTrabajo.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                InspeccionTrabajo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                InspeccionTrabajo.DescArea = reader["DescArea"].ToString();
                InspeccionTrabajo.IdSector = Int32.Parse(reader["IdSector"].ToString());
                InspeccionTrabajo.DescSector = reader["DescSector"].ToString();
                InspeccionTrabajo.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                InspeccionTrabajo.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                InspeccionTrabajo.Numero = reader["Numero"].ToString();
                InspeccionTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InspeccionTrabajo.Hora = DateTime.Parse(reader["Hora"].ToString());
                InspeccionTrabajo.Objetivo = reader["Objetivo"].ToString();
                InspeccionTrabajo.Lugar = reader["Lugar"].ToString();
                InspeccionTrabajo.IdInspeccionadoPor = Int32.Parse(reader["IdInspeccionadoPor"].ToString());
                InspeccionTrabajo.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                InspeccionTrabajo.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                InspeccionTrabajo.ResponsableArea = reader["ResponsableArea"].ToString();
                InspeccionTrabajo.MailAreaResponsable = reader["MailAreaResponsable"].ToString();
                InspeccionTrabajo.IdResponsableSector = reader.IsDBNull(reader.GetOrdinal("IdResponsableSector")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableSector"));
                InspeccionTrabajo.ResponsableSector = reader["ResponsableSector"].ToString();
                InspeccionTrabajo.MailSectorResponsable = reader["MailSectorResponsable"].ToString();
                InspeccionTrabajo.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                InspeccionTrabajo.PersonaRegistro = reader["PersonaRegistro"].ToString();
                InspeccionTrabajo.PersonaCargo = reader["PersonaCargo"].ToString();
                InspeccionTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InspeccionTrabajolist.Add(InspeccionTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return InspeccionTrabajolist;
        }
    }
}
