using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PersonaDL
    {
        public PersonaDL() { }

        public Int32 Inserta(PersonaBE pItem)
        {
            Int32 intIdPersona = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_Inserta");

            db.AddOutParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdContratista", DbType.Int32, pItem.IdContratista);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pEdad", DbType.Int32, pItem.Edad);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pSexo", DbType.String, pItem.Sexo);
            db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
            db.AddInParameter(dbCommand, "pIdEstadoCivil", DbType.Int32, pItem.IdEstadoCivil);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagCapacitacion", DbType.Boolean, pItem.FlagCapacitacion);
            db.AddInParameter(dbCommand, "pSctr", DbType.String, pItem.Sctr);
            db.AddInParameter(dbCommand, "pFechaSctrIni", DbType.DateTime, pItem.FechaSctrIni);
            db.AddInParameter(dbCommand, "pFechaSctrFin", DbType.DateTime, pItem.FechaSctrFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdPersona = (int)db.GetParameterValue(dbCommand, "pIdPersona");

            return intIdPersona;

        }

        public void InsertaMasivo(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_InsertaMasivo");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pEdad", DbType.Int32, pItem.Edad);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pSexo", DbType.String, pItem.Sexo);
            db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
            db.AddInParameter(dbCommand, "pIdEstadoCivil", DbType.Int32, pItem.IdEstadoCivil);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_Actualiza");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdContratista", DbType.Int32, pItem.IdContratista);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pEdad", DbType.Int32, pItem.Edad);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pSexo", DbType.String, pItem.Sexo);
            db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
            db.AddInParameter(dbCommand, "pIdEstadoCivil", DbType.Int32, pItem.IdEstadoCivil);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagCapacitacion", DbType.Boolean, pItem.FlagCapacitacion);
            db.AddInParameter(dbCommand, "pSctr", DbType.String, pItem.Sctr);
            db.AddInParameter(dbCommand, "pFechaSctrIni", DbType.DateTime, pItem.FechaSctrIni);
            db.AddInParameter(dbCommand, "pFechaSctrFin", DbType.DateTime, pItem.FechaSctrFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdEmpresa, string Dni, int IdSituacion, DateTime FechaIngreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_ActualizaSituacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, FechaIngreso);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_Elimina");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PersonaBE Selecciona(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pidPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Persona = null;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdNegocio = Int32.Parse(reader["IdNegocio"].ToString());
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdContratista = reader.IsDBNull(reader.GetOrdinal("IdContratista")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratista"));
                Persona.DescEmpresaContratista = reader["DescEmpresaContratista"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Sexo = reader["Sexo"].ToString();
                Persona.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Persona.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.FlagCapacitacion = Boolean.Parse(reader["FlagCapacitacion"].ToString());
                Persona.Sctr = reader["Sctr"].ToString();
                Persona.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                Persona.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                Persona.Observacion = reader["Observacion"].ToString();
                Persona.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Persona;
        }

        public PersonaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, int IdArea, string DescPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pDescPersona", DbType.String, DescPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Persona = null;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdNegocio = Int32.Parse(reader["IdNegocio"].ToString());
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdContratista = reader.IsDBNull(reader.GetOrdinal("IdContratista")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratista"));
                Persona.DescEmpresaContratista = reader["DescEmpresaContratista"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Sexo = reader["Sexo"].ToString();
                Persona.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Persona.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.FlagCapacitacion = Boolean.Parse(reader["FlagCapacitacion"].ToString());
                Persona.Sctr = reader["Sctr"].ToString();
                Persona.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                Persona.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                Persona.Observacion = reader["Observacion"].ToString();
                Persona.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Persona;
        }

        public List<PersonaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personalist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdNegocio = Int32.Parse(reader["IdNegocio"].ToString());
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdContratista = reader.IsDBNull(reader.GetOrdinal("IdContratista")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratista"));
                Persona.DescEmpresaContratista = reader["DescEmpresaContratista"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Sexo = reader["Sexo"].ToString();
                Persona.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Persona.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.FlagCapacitacion = Boolean.Parse(reader["FlagCapacitacion"].ToString());
                Persona.Sctr = reader["Sctr"].ToString();
                Persona.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                Persona.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                Persona.Observacion = reader["Observacion"].ToString();
                Persona.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personalist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personalist;
        }

        public List<PersonaBE> ListaContratista(int IdContratista)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_ListaContratista");
            db.AddInParameter(dbCommand, "pIdContratista", DbType.Int32, IdContratista);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personalist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdNegocio = Int32.Parse(reader["IdNegocio"].ToString());
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdContratista = reader.IsDBNull(reader.GetOrdinal("IdContratista")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratista"));
                Persona.DescEmpresaContratista = reader["DescEmpresaContratista"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Sexo = reader["Sexo"].ToString();
                Persona.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Persona.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.FlagCapacitacion = Boolean.Parse(reader["FlagCapacitacion"].ToString());
                Persona.Sctr = reader["Sctr"].ToString();
                Persona.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                Persona.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                Persona.Observacion = reader["Observacion"].ToString();
                Persona.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personalist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personalist;
        }

        public List<PersonaBE> SeleccionaBusqueda(int IdEmpresa, int IdUnidadMinera, int IdSituacion, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personalist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.Ruc = reader["Ruc"].ToString();
                Persona.RazonSocial = reader["RazonSocial"].ToString();
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Sexo = reader["Sexo"].ToString();
                Personalist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personalist;
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdUnidadMinera, int IdSituacion, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public PersonaBE SeleccionaNumeroDocumento(int IdEmpresa, string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Persona_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Persona = null;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdNegocio = Int32.Parse(reader["IdNegocio"].ToString());
                Persona.DescNegocio = reader["DescNegocio"].ToString();
                Persona.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Persona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdContratista = reader.IsDBNull(reader.GetOrdinal("IdContratista")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratista"));
                Persona.DescEmpresaContratista = reader["DescEmpresaContratista"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Persona.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Persona.Edad = Int32.Parse(reader["Edad"].ToString());
                Persona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Persona.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Persona.Cargo = reader["Cargo"].ToString();
                Persona.Sexo = reader["Sexo"].ToString();
                Persona.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Persona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Persona.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Persona.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.FlagCapacitacion = Boolean.Parse(reader["FlagCapacitacion"].ToString());
                Persona.Sctr = reader["Sctr"].ToString();
                Persona.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                Persona.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                Persona.Observacion = reader["Observacion"].ToString();
                Persona.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Persona.DescSituacion = reader["DescSituacion"].ToString();
                Persona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Persona;
        }
    }
}
