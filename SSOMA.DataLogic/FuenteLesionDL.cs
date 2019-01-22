using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class FuenteLesionDL
    {
        public FuenteLesionDL() { }

        public void Inserta(FuenteLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_Inserta");

            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, pItem.IdFuenteLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFuenteLesion", DbType.String, pItem.DescFuenteLesion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(FuenteLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_Actualiza");

            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, pItem.IdFuenteLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFuenteLesion", DbType.String, pItem.DescFuenteLesion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(FuenteLesionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_Elimina");

            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, pItem.IdFuenteLesion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public FuenteLesionBE Selecciona(int idFuenteLesion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_Selecciona");
            db.AddInParameter(dbCommand, "pidFuenteLesion", DbType.Int32, idFuenteLesion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FuenteLesionBE FuenteLesion = null;
            while (reader.Read())
            {
                FuenteLesion = new FuenteLesionBE();
                FuenteLesion.IdFuenteLesion = Int32.Parse(reader["idFuenteLesion"].ToString());
                FuenteLesion.DescFuenteLesion = reader["descFuenteLesion"].ToString();
                FuenteLesion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return FuenteLesion;
        }

        public List<FuenteLesionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FuenteLesionBE> FuenteLesionlist = new List<FuenteLesionBE>();
            FuenteLesionBE FuenteLesion;
            while (reader.Read())
            {
                FuenteLesion = new FuenteLesionBE();
                FuenteLesion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FuenteLesion.IdFuenteLesion = Int32.Parse(reader["idFuenteLesion"].ToString());
                FuenteLesion.DescFuenteLesion = reader["descFuenteLesion"].ToString();
                FuenteLesion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FuenteLesionlist.Add(FuenteLesion);
            }
            reader.Close();
            reader.Dispose();
            return FuenteLesionlist;
        }

        public List<FuenteLesionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FuenteLesion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FuenteLesionBE> FuenteLesionlist = new List<FuenteLesionBE>();
            FuenteLesionBE FuenteLesion;
            while (reader.Read())
            {
                FuenteLesion = new FuenteLesionBE();
                FuenteLesion.IdFuenteLesion = Int32.Parse(reader["idFuenteLesion"].ToString());
                FuenteLesion.DescFuenteLesion = reader["descFuenteLesion"].ToString();
                FuenteLesionlist.Add(FuenteLesion);
            }
            reader.Close();
            reader.Dispose();
            return FuenteLesionlist;
        }
    }
}
