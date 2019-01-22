using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteFactorPersonalDL
    {
        public AccidenteFactorPersonalDL() { }

        public void Inserta(AccidenteFactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorPersonal_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorPersonal", DbType.Int32, pItem.IdAccidenteFactorPersonal);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, pItem.IdFactorPersonal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteFactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorPersonal_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorPersonal", DbType.Int32, pItem.IdAccidenteFactorPersonal);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdFactorPersonal", DbType.Int32, pItem.IdFactorPersonal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteFactorPersonalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorPersonal_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorPersonal", DbType.Int32, pItem.IdAccidenteFactorPersonal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteFactorPersonalBE Selecciona(int IdAccidenteFactorPersonal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorPersonal_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteFactorPersonal", DbType.Int32, IdAccidenteFactorPersonal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteFactorPersonalBE AccidenteFactorPersonal = null;
            while (reader.Read())
            {
                AccidenteFactorPersonal = new AccidenteFactorPersonalBE();
                AccidenteFactorPersonal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFactorPersonal.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFactorPersonal.IdAccidenteFactorPersonal = Int32.Parse(reader["idAccidenteFactorPersonal"].ToString());
                AccidenteFactorPersonal.IdFactorPersonal = Int32.Parse(reader["IdFactorPersonal"].ToString());
                AccidenteFactorPersonal.DescFactorPersonal = reader["DescFactorPersonal"].ToString();
                AccidenteFactorPersonal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFactorPersonal;
        }

        public List<AccidenteFactorPersonalBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorPersonal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteFactorPersonalBE> AccidenteFactorPersonallist = new List<AccidenteFactorPersonalBE>();
            AccidenteFactorPersonalBE AccidenteFactorPersonal;
            while (reader.Read())
            {
                AccidenteFactorPersonal = new AccidenteFactorPersonalBE();
                AccidenteFactorPersonal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFactorPersonal.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFactorPersonal.IdAccidenteFactorPersonal = Int32.Parse(reader["idAccidenteFactorPersonal"].ToString());
                AccidenteFactorPersonal.IdFactorPersonal = Int32.Parse(reader["IdFactorPersonal"].ToString());
                AccidenteFactorPersonal.DescFactorPersonal = reader["DescFactorPersonal"].ToString();
                AccidenteFactorPersonal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteFactorPersonal.TipoOper = 4; //CONSULTAR
                AccidenteFactorPersonallist.Add(AccidenteFactorPersonal);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFactorPersonallist;
        }
    }
}
