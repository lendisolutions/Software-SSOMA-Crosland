using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoPeligroDL
    {
        public TipoPeligroDL() { }

        public void Inserta(TipoPeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, pItem.IdTipoPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoPeligro", DbType.String, pItem.DescTipoPeligro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoPeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, pItem.IdTipoPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoPeligro", DbType.String, pItem.DescTipoPeligro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoPeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, pItem.IdTipoPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoPeligroBE Selecciona(int idTipoPeligro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_Selecciona");
            db.AddInParameter(dbCommand, "pidTipoPeligro", DbType.Int32, idTipoPeligro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoPeligroBE TipoPeligro = null;
            while (reader.Read())
            {
                TipoPeligro = new TipoPeligroBE();
                TipoPeligro.IdTipoPeligro = Int32.Parse(reader["idTipoPeligro"].ToString());
                TipoPeligro.DescTipoPeligro = reader["descTipoPeligro"].ToString();
                TipoPeligro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoPeligro;
        }

        public List<TipoPeligroBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoPeligroBE> TipoPeligrolist = new List<TipoPeligroBE>();
            TipoPeligroBE TipoPeligro;
            while (reader.Read())
            {
                TipoPeligro = new TipoPeligroBE();
                TipoPeligro.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoPeligro.IdTipoPeligro = Int32.Parse(reader["idTipoPeligro"].ToString());
                TipoPeligro.DescTipoPeligro = reader["descTipoPeligro"].ToString();
                TipoPeligro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoPeligrolist.Add(TipoPeligro);
            }
            reader.Close();
            reader.Dispose();
            return TipoPeligrolist;
        }

        public List<TipoPeligroBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoPeligro_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoPeligroBE> TipoPeligrolist = new List<TipoPeligroBE>();
            TipoPeligroBE TipoPeligro;
            while (reader.Read())
            {
                TipoPeligro = new TipoPeligroBE();
                TipoPeligro.IdTipoPeligro = Int32.Parse(reader["idTipoPeligro"].ToString());
                TipoPeligro.DescTipoPeligro = reader["descTipoPeligro"].ToString();
                TipoPeligrolist.Add(TipoPeligro);
            }
            reader.Close();
            reader.Dispose();
            return TipoPeligrolist;
        }
    }
}
