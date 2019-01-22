using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoLesionDL
    {
        public TipoLesionDL() { }

        public void Inserta(TipoLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, pItem.IdTipoLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoLesion", DbType.String, pItem.DescTipoLesion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, pItem.IdTipoLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoLesion", DbType.String, pItem.DescTipoLesion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, pItem.IdTipoLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoLesionBE Selecciona(int idTipoLesion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_Selecciona");
            db.AddInParameter(dbCommand, "pidTipoLesion", DbType.Int32, idTipoLesion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoLesionBE TipoLesion = null;
            while (reader.Read())
            {
                TipoLesion = new TipoLesionBE();
                TipoLesion.IdTipoLesion = Int32.Parse(reader["idTipoLesion"].ToString());
                TipoLesion.DescTipoLesion = reader["descTipoLesion"].ToString();
                TipoLesion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoLesion;
        }

        public List<TipoLesionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoLesionBE> TipoLesionlist = new List<TipoLesionBE>();
            TipoLesionBE TipoLesion;
            while (reader.Read())
            {
                TipoLesion = new TipoLesionBE();
                TipoLesion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoLesion.IdTipoLesion = Int32.Parse(reader["idTipoLesion"].ToString());
                TipoLesion.DescTipoLesion = reader["descTipoLesion"].ToString();
                TipoLesion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoLesionlist.Add(TipoLesion);
            }
            reader.Close();
            reader.Dispose();
            return TipoLesionlist;
        }

        public List<TipoLesionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoLesion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoLesionBE> TipoLesionlist = new List<TipoLesionBE>();
            TipoLesionBE TipoLesion;
            while (reader.Read())
            {
                TipoLesion = new TipoLesionBE();
                TipoLesion.IdTipoLesion = Int32.Parse(reader["idTipoLesion"].ToString());
                TipoLesion.DescTipoLesion = reader["descTipoLesion"].ToString();
                TipoLesionlist.Add(TipoLesion);
            }
            reader.Close();
            reader.Dispose();
            return TipoLesionlist;
        }
    }
}
