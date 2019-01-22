using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoAccidenteDL
    {
        public TipoAccidenteDL() { }

        public void Inserta(TipoAccidenteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, pItem.IdTipoAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoAccidente", DbType.String, pItem.DescTipoAccidente);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoAccidenteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, pItem.IdTipoAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoAccidente", DbType.String, pItem.DescTipoAccidente);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoAccidenteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, pItem.IdTipoAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoAccidenteBE Selecciona(int idTipoAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_Selecciona");
            db.AddInParameter(dbCommand, "pidTipoAccidente", DbType.Int32, idTipoAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoAccidenteBE TipoAccidente = null;
            while (reader.Read())
            {
                TipoAccidente = new TipoAccidenteBE();
                TipoAccidente.IdTipoAccidente = Int32.Parse(reader["idTipoAccidente"].ToString());
                TipoAccidente.DescTipoAccidente = reader["descTipoAccidente"].ToString();
                TipoAccidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoAccidente;
        }

        public List<TipoAccidenteBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoAccidenteBE> TipoAccidentelist = new List<TipoAccidenteBE>();
            TipoAccidenteBE TipoAccidente;
            while (reader.Read())
            {
                TipoAccidente = new TipoAccidenteBE();
                TipoAccidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoAccidente.IdTipoAccidente = Int32.Parse(reader["idTipoAccidente"].ToString());
                TipoAccidente.DescTipoAccidente = reader["descTipoAccidente"].ToString();
                TipoAccidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoAccidentelist.Add(TipoAccidente);
            }
            reader.Close();
            reader.Dispose();
            return TipoAccidentelist;
        }

        public List<TipoAccidenteBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoAccidente_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoAccidenteBE> TipoAccidentelist = new List<TipoAccidenteBE>();
            TipoAccidenteBE TipoAccidente;
            while (reader.Read())
            {
                TipoAccidente = new TipoAccidenteBE();
                TipoAccidente.IdTipoAccidente = Int32.Parse(reader["idTipoAccidente"].ToString());
                TipoAccidente.DescTipoAccidente = reader["descTipoAccidente"].ToString();
                TipoAccidentelist.Add(TipoAccidente);
            }
            reader.Close();
            reader.Dispose();
            return TipoAccidentelist;
        }
    }
}
