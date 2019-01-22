using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CondicionSubEstandarDL
    {
        public CondicionSubEstandarDL() { }

        public void Inserta(CondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_Inserta");

            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, pItem.IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCondicionSubEstandar", DbType.String, pItem.DescCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_Actualiza");

            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, pItem.IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCondicionSubEstandar", DbType.String, pItem.DescCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_Elimina");

            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, pItem.IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CondicionSubEstandarBE Selecciona(int idCondicionSubEstandar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_Selecciona");
            db.AddInParameter(dbCommand, "pidCondicionSubEstandar", DbType.Int32, idCondicionSubEstandar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CondicionSubEstandarBE CondicionSubEstandar = null;
            while (reader.Read())
            {
                CondicionSubEstandar = new CondicionSubEstandarBE();
                CondicionSubEstandar.IdCondicionSubEstandar = Int32.Parse(reader["idCondicionSubEstandar"].ToString());
                CondicionSubEstandar.DescCondicionSubEstandar = reader["descCondicionSubEstandar"].ToString();
                CondicionSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CondicionSubEstandar;
        }

        public List<CondicionSubEstandarBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CondicionSubEstandarBE> CondicionSubEstandarlist = new List<CondicionSubEstandarBE>();
            CondicionSubEstandarBE CondicionSubEstandar;
            while (reader.Read())
            {
                CondicionSubEstandar = new CondicionSubEstandarBE();
                CondicionSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CondicionSubEstandar.IdCondicionSubEstandar = Int32.Parse(reader["idCondicionSubEstandar"].ToString());
                CondicionSubEstandar.DescCondicionSubEstandar = reader["descCondicionSubEstandar"].ToString();
                CondicionSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CondicionSubEstandarlist.Add(CondicionSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return CondicionSubEstandarlist;
        }

        public List<CondicionSubEstandarBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionSubEstandar_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CondicionSubEstandarBE> CondicionSubEstandarlist = new List<CondicionSubEstandarBE>();
            CondicionSubEstandarBE CondicionSubEstandar;
            while (reader.Read())
            {
                CondicionSubEstandar = new CondicionSubEstandarBE();
                CondicionSubEstandar.IdCondicionSubEstandar = Int32.Parse(reader["idCondicionSubEstandar"].ToString());
                CondicionSubEstandar.DescCondicionSubEstandar = reader["descCondicionSubEstandar"].ToString();
                CondicionSubEstandarlist.Add(CondicionSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return CondicionSubEstandarlist;
        }
    }
}
