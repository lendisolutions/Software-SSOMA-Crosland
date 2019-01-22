using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteCondicionSubEstandarDL
    {
        public AccidenteCondicionSubEstandarDL() { }

        public void Inserta(AccidenteCondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCondicionSubEstandar_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteCondicionSubEstandar", DbType.Int32, pItem.IdAccidenteCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, pItem.IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteCondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCondicionSubEstandar_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteCondicionSubEstandar", DbType.Int32, pItem.IdAccidenteCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdCondicionSubEstandar", DbType.Int32, pItem.IdCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteCondicionSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCondicionSubEstandar_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteCondicionSubEstandar", DbType.Int32, pItem.IdAccidenteCondicionSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteCondicionSubEstandarBE Selecciona(int IdAccidenteCondicionSubEstandar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCondicionSubEstandar_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteCondicionSubEstandar", DbType.Int32, IdAccidenteCondicionSubEstandar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteCondicionSubEstandarBE AccidenteCondicionSubEstandar = null;
            while (reader.Read())
            {
                AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBE();
                AccidenteCondicionSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteCondicionSubEstandar.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteCondicionSubEstandar.IdAccidenteCondicionSubEstandar = Int32.Parse(reader["idAccidenteCondicionSubEstandar"].ToString());
                AccidenteCondicionSubEstandar.IdCondicionSubEstandar = Int32.Parse(reader["IdCondicionSubEstandar"].ToString());
                AccidenteCondicionSubEstandar.DescCondicionSubEstandar = reader["DescCondicionSubEstandar"].ToString();
                AccidenteCondicionSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteCondicionSubEstandar;
        }

        public List<AccidenteCondicionSubEstandarBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCondicionSubEstandar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteCondicionSubEstandarBE> AccidenteCondicionSubEstandarlist = new List<AccidenteCondicionSubEstandarBE>();
            AccidenteCondicionSubEstandarBE AccidenteCondicionSubEstandar;
            while (reader.Read())
            {
                AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBE();
                AccidenteCondicionSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteCondicionSubEstandar.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteCondicionSubEstandar.IdAccidenteCondicionSubEstandar = Int32.Parse(reader["idAccidenteCondicionSubEstandar"].ToString());
                AccidenteCondicionSubEstandar.IdCondicionSubEstandar = Int32.Parse(reader["IdCondicionSubEstandar"].ToString());
                AccidenteCondicionSubEstandar.DescCondicionSubEstandar = reader["DescCondicionSubEstandar"].ToString();
                AccidenteCondicionSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteCondicionSubEstandar.TipoOper = 4; //CONSULTAR
                AccidenteCondicionSubEstandarlist.Add(AccidenteCondicionSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteCondicionSubEstandarlist;
        }
    }
}
