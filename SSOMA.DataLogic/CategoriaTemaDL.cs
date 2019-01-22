using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CategoriaTemaDL
    {
        public CategoriaTemaDL() { }

        public void Inserta(CategoriaTemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_Inserta");

            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, pItem.IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCategoriaTema", DbType.String, pItem.DescCategoriaTema);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CategoriaTemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_Actualiza");

            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, pItem.IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCategoriaTema", DbType.String, pItem.DescCategoriaTema);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CategoriaTemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_Elimina");

            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, pItem.IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CategoriaTemaBE Selecciona(int idCategoriaTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_Selecciona");
            db.AddInParameter(dbCommand, "pidCategoriaTema", DbType.Int32, idCategoriaTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CategoriaTemaBE CategoriaTema = null;
            while (reader.Read())
            {
                CategoriaTema = new CategoriaTemaBE();
                CategoriaTema.IdCategoriaTema = Int32.Parse(reader["idCategoriaTema"].ToString());
                CategoriaTema.DescCategoriaTema = reader["descCategoriaTema"].ToString();
                CategoriaTema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CategoriaTema;
        }

        public List<CategoriaTemaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CategoriaTemaBE> CategoriaTemalist = new List<CategoriaTemaBE>();
            CategoriaTemaBE CategoriaTema;
            while (reader.Read())
            {
                CategoriaTema = new CategoriaTemaBE();
                CategoriaTema.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CategoriaTema.IdCategoriaTema = Int32.Parse(reader["idCategoriaTema"].ToString());
                CategoriaTema.DescCategoriaTema = reader["descCategoriaTema"].ToString();
                CategoriaTema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CategoriaTemalist.Add(CategoriaTema);
            }
            reader.Close();
            reader.Dispose();
            return CategoriaTemalist;
        }

        public List<CategoriaTemaBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaTema_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CategoriaTemaBE> CategoriaTemalist = new List<CategoriaTemaBE>();
            CategoriaTemaBE CategoriaTema;
            while (reader.Read())
            {
                CategoriaTema = new CategoriaTemaBE();
                CategoriaTema.IdCategoriaTema = Int32.Parse(reader["idCategoriaTema"].ToString());
                CategoriaTema.DescCategoriaTema = reader["descCategoriaTema"].ToString();
                CategoriaTemalist.Add(CategoriaTema);
            }
            reader.Close();
            reader.Dispose();
            return CategoriaTemalist;
        }
    }
}
