using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ActoSubEstandarDL
    {
        public ActoSubEstandarDL() { }

        public void Inserta(ActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_Inserta");

            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, pItem.IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescActoSubEstandar", DbType.String, pItem.DescActoSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_Actualiza");

            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, pItem.IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescActoSubEstandar", DbType.String, pItem.DescActoSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_Elimina");

            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, pItem.IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ActoSubEstandarBE Selecciona(int idActoSubEstandar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_Selecciona");
            db.AddInParameter(dbCommand, "pidActoSubEstandar", DbType.Int32, idActoSubEstandar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ActoSubEstandarBE ActoSubEstandar = null;
            while (reader.Read())
            {
                ActoSubEstandar = new ActoSubEstandarBE();
                ActoSubEstandar.IdActoSubEstandar = Int32.Parse(reader["idActoSubEstandar"].ToString());
                ActoSubEstandar.DescActoSubEstandar = reader["descActoSubEstandar"].ToString();
                ActoSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ActoSubEstandar;
        }

        public List<ActoSubEstandarBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ActoSubEstandarBE> ActoSubEstandarlist = new List<ActoSubEstandarBE>();
            ActoSubEstandarBE ActoSubEstandar;
            while (reader.Read())
            {
                ActoSubEstandar = new ActoSubEstandarBE();
                ActoSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActoSubEstandar.IdActoSubEstandar = Int32.Parse(reader["idActoSubEstandar"].ToString());
                ActoSubEstandar.DescActoSubEstandar = reader["descActoSubEstandar"].ToString();
                ActoSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ActoSubEstandarlist.Add(ActoSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return ActoSubEstandarlist;
        }

        public List<ActoSubEstandarBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActoSubEstandar_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ActoSubEstandarBE> ActoSubEstandarlist = new List<ActoSubEstandarBE>();
            ActoSubEstandarBE ActoSubEstandar;
            while (reader.Read())
            {
                ActoSubEstandar = new ActoSubEstandarBE();
                ActoSubEstandar.IdActoSubEstandar = Int32.Parse(reader["idActoSubEstandar"].ToString());
                ActoSubEstandar.DescActoSubEstandar = reader["descActoSubEstandar"].ToString();
                ActoSubEstandarlist.Add(ActoSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return ActoSubEstandarlist;
        }
    }
}
