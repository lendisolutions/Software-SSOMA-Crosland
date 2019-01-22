using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SctrDL
    {
        public SctrDL() { }

        public Int32 Inserta(SctrBE pItem)
        {
            Int32 intIdSctr = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_Inserta");

            db.AddOutParameter(dbCommand, "pIdSctr", DbType.Int32, pItem.IdSctr);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pTipoDocumento", DbType.String, pItem.TipoDocumento);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pNacionalidad", DbType.String, pItem.Nacionalidad);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdSctr = (int)db.GetParameterValue(dbCommand, "pIdSctr");

            return intIdSctr;

        }

        public void Actualiza(SctrBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_Actualiza");

            db.AddInParameter(dbCommand, "pIdSctr", DbType.Int32, pItem.IdSctr);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pTipoDocumento", DbType.String, pItem.TipoDocumento);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pNacionalidad", DbType.String, pItem.Nacionalidad);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdSctr, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdSctr", DbType.Int32, IdSctr);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdSctr, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdSctr", DbType.Int32, IdSctr);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(SctrBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_Elimina");

            db.AddInParameter(dbCommand, "pIdSctr", DbType.Int32, pItem.IdSctr);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SctrBE Selecciona(int idSctr)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_Selecciona");
            db.AddInParameter(dbCommand, "pidSctr", DbType.Int32, idSctr);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SctrBE Sctr = null;
            while (reader.Read())
            {
                Sctr = new SctrBE();
                Sctr.IdSctr = Int32.Parse(reader["idSctr"].ToString());
                Sctr.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sctr.RazonSocial = reader["RazonSocial"].ToString();
                Sctr.Numero = reader["Numero"].ToString();
                Sctr.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Sctr.Mes = Int32.Parse(reader["Mes"].ToString());
                Sctr.DescMes = reader["DescMes"].ToString();
                Sctr.TipoDocumento = reader["TipoDocumento"].ToString();
                Sctr.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Sctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Sctr.Solicitante = reader["Solicitante"].ToString();
                Sctr.Sexo = reader["Sexo"].ToString();
                Sctr.Cargo = reader["Cargo"].ToString();
                Sctr.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Sctr.Nacionalidad = reader["Nacionalidad"].ToString();
                Sctr.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Sctr.DescSituacion = reader["DescSituacion"].ToString();
                Sctr.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Sctr;
        }

        public SctrBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SctrBE Sctr = null;
            while (reader.Read())
            {
                Sctr = new SctrBE();
                Sctr.IdSctr = Int32.Parse(reader["idSctr"].ToString());
                Sctr.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sctr.RazonSocial = reader["RazonSocial"].ToString();
                Sctr.Numero = reader["Numero"].ToString();
                Sctr.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Sctr.Mes = Int32.Parse(reader["Mes"].ToString());
                Sctr.DescMes = reader["DescMes"].ToString();
                Sctr.TipoDocumento = reader["TipoDocumento"].ToString();
                Sctr.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Sctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Sctr.Solicitante = reader["Solicitante"].ToString();
                Sctr.Sexo = reader["Sexo"].ToString();
                Sctr.Cargo = reader["Cargo"].ToString();
                Sctr.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Sctr.Nacionalidad = reader["Nacionalidad"].ToString();
                Sctr.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Sctr.DescSituacion = reader["DescSituacion"].ToString();
                Sctr.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Sctr;
        }

        public List<SctrBE> ListaTodosActivo(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SctrBE> Sctrlist = new List<SctrBE>();
            SctrBE Sctr;
            while (reader.Read())
            {
                Sctr = new SctrBE();
                Sctr.IdSctr = Int32.Parse(reader["idSctr"].ToString());
                Sctr.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sctr.RazonSocial = reader["RazonSocial"].ToString();
                Sctr.Numero = reader["Numero"].ToString();
                Sctr.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Sctr.Mes = Int32.Parse(reader["Mes"].ToString());
                Sctr.DescMes = reader["DescMes"].ToString();
                Sctr.TipoDocumento = reader["TipoDocumento"].ToString();
                Sctr.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Sctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Sctr.Solicitante = reader["Solicitante"].ToString();
                Sctr.Sexo = reader["Sexo"].ToString();
                Sctr.Cargo = reader["Cargo"].ToString();
                Sctr.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Sctr.Nacionalidad = reader["Nacionalidad"].ToString();
                Sctr.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Sctr.DescSituacion = reader["DescSituacion"].ToString();
                Sctr.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sctrlist.Add(Sctr);
            }
            reader.Close();
            reader.Dispose();
            return Sctrlist;
        }

        public List<SctrBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SctrBE> Sctrlist = new List<SctrBE>();
            SctrBE Sctr;
            while (reader.Read())
            {
                Sctr = new SctrBE();
                Sctr.IdSctr = Int32.Parse(reader["idSctr"].ToString());
                Sctr.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sctr.RazonSocial = reader["RazonSocial"].ToString();
                Sctr.Numero = reader["Numero"].ToString();
                Sctr.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Sctr.Mes = Int32.Parse(reader["Mes"].ToString());
                Sctr.DescMes = reader["DescMes"].ToString();
                Sctr.TipoDocumento = reader["TipoDocumento"].ToString();
                Sctr.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Sctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Sctr.Solicitante = reader["Solicitante"].ToString();
                Sctr.Sexo = reader["Sexo"].ToString();
                Sctr.Cargo = reader["Cargo"].ToString();
                Sctr.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Sctr.Nacionalidad = reader["Nacionalidad"].ToString();
                Sctr.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Sctr.DescSituacion = reader["DescSituacion"].ToString();
                Sctr.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sctrlist.Add(Sctr);
            }
            reader.Close();
            reader.Dispose();
            return Sctrlist;
        }

        public List<SctrBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sctr_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SctrBE> Sctrlist = new List<SctrBE>();
            SctrBE Sctr;
            while (reader.Read())
            {
                Sctr = new SctrBE();
                Sctr.IdSctr = Int32.Parse(reader["idSctr"].ToString());
                Sctr.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sctr.RazonSocial = reader["RazonSocial"].ToString();
                Sctr.Numero = reader["Numero"].ToString();
                Sctr.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Sctr.Mes = Int32.Parse(reader["Mes"].ToString());
                Sctr.DescMes = reader["DescMes"].ToString();
                Sctr.TipoDocumento = reader["TipoDocumento"].ToString();
                Sctr.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Sctr.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Sctr.Solicitante = reader["Solicitante"].ToString();
                Sctr.Sexo = reader["Sexo"].ToString();
                Sctr.Cargo = reader["Cargo"].ToString();
                Sctr.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                Sctr.Nacionalidad = reader["Nacionalidad"].ToString();
                Sctr.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Sctr.DescSituacion = reader["DescSituacion"].ToString();
                Sctr.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sctrlist.Add(Sctr);
            }
            reader.Close();
            reader.Dispose();
            return Sctrlist;
        }

    }
}
