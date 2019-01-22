using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class FactorPersonalDL
    {
        public FactorPersonalDL() { }

        public void Inserta(FactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_Inserta");

            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, pItem.IdFactorPersonal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFactorPersonal", DbType.String, pItem.DescFactorPersonal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(FactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_Actualiza");

            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, pItem.IdFactorPersonal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFactorPersonal", DbType.String, pItem.DescFactorPersonal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(FactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_Elimina");

            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, pItem.IdFactorPersonal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public FactorPersonalBE Selecciona(int idFactorPersonal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_Selecciona");
            db.AddInParameter(dbCommand, "pidFactorPersonal", DbType.Int32, idFactorPersonal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FactorPersonalBE FactorPersonal = null;
            while (reader.Read())
            {
                FactorPersonal = new FactorPersonalBE();
                FactorPersonal.IdFactorPersonal = Int32.Parse(reader["idFactorPersonal"].ToString());
                FactorPersonal.DescFactorPersonal = reader["descFactorPersonal"].ToString();
                FactorPersonal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return FactorPersonal;
        }

        public List<FactorPersonalBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FactorPersonalBE> FactorPersonallist = new List<FactorPersonalBE>();
            FactorPersonalBE FactorPersonal;
            while (reader.Read())
            {
                FactorPersonal = new FactorPersonalBE();
                FactorPersonal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FactorPersonal.IdFactorPersonal = Int32.Parse(reader["idFactorPersonal"].ToString());
                FactorPersonal.DescFactorPersonal = reader["descFactorPersonal"].ToString();
                FactorPersonal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FactorPersonallist.Add(FactorPersonal);
            }
            reader.Close();
            reader.Dispose();
            return FactorPersonallist;
        }

        public List<FactorPersonalBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorPersonal_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FactorPersonalBE> FactorPersonallist = new List<FactorPersonalBE>();
            FactorPersonalBE FactorPersonal;
            while (reader.Read())
            {
                FactorPersonal = new FactorPersonalBE();
                FactorPersonal.IdFactorPersonal = Int32.Parse(reader["idFactorPersonal"].ToString());
                FactorPersonal.DescFactorPersonal = reader["descFactorPersonal"].ToString();
                FactorPersonallist.Add(FactorPersonal);
            }
            reader.Close();
            reader.Dispose();
            return FactorPersonallist;
        }
    }
}
