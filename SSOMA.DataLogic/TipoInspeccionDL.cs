using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoInspeccionDL
    {
        public TipoInspeccionDL() { }

        public void Inserta(TipoInspeccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoInspeccion", DbType.String, pItem.DescTipoInspeccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoInspeccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoInspeccion", DbType.String, pItem.DescTipoInspeccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoInspeccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoInspeccionBE Selecciona(int idTipoInspeccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_Selecciona");
            db.AddInParameter(dbCommand, "pidTipoInspeccion", DbType.Int32, idTipoInspeccion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoInspeccionBE TipoInspeccion = null;
            while (reader.Read())
            {
                TipoInspeccion = new TipoInspeccionBE();
                TipoInspeccion.IdTipoInspeccion = Int32.Parse(reader["idTipoInspeccion"].ToString());
                TipoInspeccion.DescTipoInspeccion = reader["descTipoInspeccion"].ToString();
                TipoInspeccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoInspeccion;
        }

        public List<TipoInspeccionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoInspeccionBE> TipoInspeccionlist = new List<TipoInspeccionBE>();
            TipoInspeccionBE TipoInspeccion;
            while (reader.Read())
            {
                TipoInspeccion = new TipoInspeccionBE();
                TipoInspeccion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoInspeccion.IdTipoInspeccion = Int32.Parse(reader["idTipoInspeccion"].ToString());
                TipoInspeccion.DescTipoInspeccion = reader["descTipoInspeccion"].ToString();
                TipoInspeccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoInspeccionlist.Add(TipoInspeccion);
            }
            reader.Close();
            reader.Dispose();
            return TipoInspeccionlist;
        }

        public List<TipoInspeccionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoInspeccion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoInspeccionBE> TipoInspeccionlist = new List<TipoInspeccionBE>();
            TipoInspeccionBE TipoInspeccion;
            while (reader.Read())
            {
                TipoInspeccion = new TipoInspeccionBE();
                TipoInspeccion.IdTipoInspeccion = Int32.Parse(reader["idTipoInspeccion"].ToString());
                TipoInspeccion.DescTipoInspeccion = reader["descTipoInspeccion"].ToString();
                TipoInspeccionlist.Add(TipoInspeccion);
            }
            reader.Close();
            reader.Dispose();
            return TipoInspeccionlist;
        }
    }
}
