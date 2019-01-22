using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SustitucionDL
    {
        public SustitucionDL() { }

        public void Inserta(SustitucionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_Inserta");

            db.AddInParameter(dbCommand, "pIdSustitucion", DbType.Int32, pItem.IdSustitucion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescSustitucion", DbType.String, pItem.DescSustitucion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SustitucionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_Actualiza");

            db.AddInParameter(dbCommand, "pIdSustitucion", DbType.Int32, pItem.IdSustitucion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescSustitucion", DbType.String, pItem.DescSustitucion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SustitucionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_Elimina");

            db.AddInParameter(dbCommand, "pIdSustitucion", DbType.Int32, pItem.IdSustitucion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SustitucionBE Selecciona(int idSustitucion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_Selecciona");
            db.AddInParameter(dbCommand, "pidSustitucion", DbType.Int32, idSustitucion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SustitucionBE Sustitucion = null;
            while (reader.Read())
            {
                Sustitucion = new SustitucionBE();
                Sustitucion.IdSustitucion = Int32.Parse(reader["idSustitucion"].ToString());
                Sustitucion.DescSustitucion = reader["descSustitucion"].ToString();
                Sustitucion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Sustitucion;
        }

        public List<SustitucionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SustitucionBE> Sustitucionlist = new List<SustitucionBE>();
            SustitucionBE Sustitucion;
            while (reader.Read())
            {
                Sustitucion = new SustitucionBE();
                Sustitucion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sustitucion.IdSustitucion = Int32.Parse(reader["idSustitucion"].ToString());
                Sustitucion.DescSustitucion = reader["descSustitucion"].ToString();
                Sustitucion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sustitucionlist.Add(Sustitucion);
            }
            reader.Close();
            reader.Dispose();
            return Sustitucionlist;
        }

        public List<SustitucionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sustitucion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SustitucionBE> Sustitucionlist = new List<SustitucionBE>();
            SustitucionBE Sustitucion;
            while (reader.Read())
            {
                Sustitucion = new SustitucionBE();
                Sustitucion.IdSustitucion = Int32.Parse(reader["idSustitucion"].ToString());
                Sustitucion.DescSustitucion = reader["descSustitucion"].ToString();
                Sustitucionlist.Add(Sustitucion);
            }
            reader.Close();
            reader.Dispose();
            return Sustitucionlist;
        }
    }
}
