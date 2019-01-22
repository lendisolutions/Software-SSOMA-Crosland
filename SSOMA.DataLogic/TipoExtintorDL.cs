using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;


namespace SSOMA.DataLogic
{
    public class TipoExtintorDL
    {
        public TipoExtintorDL() { }

        public void Inserta(TipoExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoExtintor", DbType.Int32, pItem.IdTipoExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTipoExtintor", DbType.String, pItem.DescTipoExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoExtintor", DbType.Int32, pItem.IdTipoExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTipoExtintor", DbType.String, pItem.DescTipoExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoExtintor", DbType.Int32, pItem.IdTipoExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoExtintorBE Selecciona(int idTipoExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_Selecciona");
            db.AddInParameter(dbCommand, "pidTipoExtintor", DbType.Int32, idTipoExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoExtintorBE TipoExtintor = null;
            while (reader.Read())
            {
                TipoExtintor = new TipoExtintorBE();
                TipoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoExtintor.IdTipoExtintor = Int32.Parse(reader["idTipoExtintor"].ToString());
                TipoExtintor.Abreviatura = reader["Abreviatura"].ToString();
                TipoExtintor.DescTipoExtintor = reader["descTipoExtintor"].ToString();
                TipoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoExtintor;
        }

        public List<TipoExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoExtintorBE> TipoExtintorlist = new List<TipoExtintorBE>();
            TipoExtintorBE TipoExtintor;
            while (reader.Read())
            {
                TipoExtintor = new TipoExtintorBE();
                TipoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoExtintor.IdTipoExtintor = Int32.Parse(reader["idTipoExtintor"].ToString());
                TipoExtintor.Abreviatura = reader["Abreviatura"].ToString();
                TipoExtintor.DescTipoExtintor = reader["descTipoExtintor"].ToString();
                TipoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoExtintorlist.Add(TipoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return TipoExtintorlist;
        }

        public List<TipoExtintorBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoExtintor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoExtintorBE> TipoExtintorlist = new List<TipoExtintorBE>();
            TipoExtintorBE TipoExtintor;
            while (reader.Read())
            {
                TipoExtintor = new TipoExtintorBE();
                TipoExtintor.IdTipoExtintor = Int32.Parse(reader["idTipoExtintor"].ToString());
                TipoExtintor.Abreviatura = reader["Abreviatura"].ToString();
                TipoExtintorlist.Add(TipoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return TipoExtintorlist;
        }
    }
}
