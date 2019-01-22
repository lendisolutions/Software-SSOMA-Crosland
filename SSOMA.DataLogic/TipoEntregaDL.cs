using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoEntregaDL
    {
        public TipoEntregaDL() { }

        public void Inserta(TipoEntregaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, pItem.IdTipoEntrega);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoEntrega", DbType.String, pItem.DescTipoEntrega);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoEntregaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, pItem.IdTipoEntrega);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoEntrega", DbType.String, pItem.DescTipoEntrega);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoEntregaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, pItem.IdTipoEntrega);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoEntregaBE Selecciona(int IdEmpresa, int idTipoEntrega)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidTipoEntrega", DbType.Int32, idTipoEntrega);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoEntregaBE TipoEntrega = null;
            while (reader.Read())
            {
                TipoEntrega = new TipoEntregaBE();
                TipoEntrega.IdTipoEntrega = Int32.Parse(reader["idTipoEntrega"].ToString());
                TipoEntrega.DescTipoEntrega = reader["descTipoEntrega"].ToString();
                TipoEntrega.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoEntrega;
        }

        public List<TipoEntregaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoEntregaBE> TipoEntregalist = new List<TipoEntregaBE>();
            TipoEntregaBE TipoEntrega;
            while (reader.Read())
            {
                TipoEntrega = new TipoEntregaBE();
                TipoEntrega.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoEntrega.IdTipoEntrega = Int32.Parse(reader["idTipoEntrega"].ToString());
                TipoEntrega.DescTipoEntrega = reader["descTipoEntrega"].ToString();
                TipoEntrega.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoEntregalist.Add(TipoEntrega);
            }
            reader.Close();
            reader.Dispose();
            return TipoEntregalist;
        }

        public List<TipoEntregaBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoEntrega_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
          
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoEntregaBE> TipoEntregalist = new List<TipoEntregaBE>();
            TipoEntregaBE TipoEntrega;
            while (reader.Read())
            {
                TipoEntrega = new TipoEntregaBE();
                TipoEntrega.IdTipoEntrega = Int32.Parse(reader["idTipoEntrega"].ToString());
                TipoEntrega.DescTipoEntrega = reader["descTipoEntrega"].ToString();
                TipoEntregalist.Add(TipoEntrega);
            }
            reader.Close();
            reader.Dispose();
            return TipoEntregalist;
        }
    }
}
