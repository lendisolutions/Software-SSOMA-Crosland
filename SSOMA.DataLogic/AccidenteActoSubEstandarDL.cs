using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteActoSubEstandarDL
    {
        public AccidenteActoSubEstandarDL() { }

        public void Inserta(AccidenteActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteActoSubEstandar_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteActoSubEstandar", DbType.Int32, pItem.IdAccidenteActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, pItem.IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteActoSubEstandar_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteActoSubEstandar", DbType.Int32, pItem.IdAccidenteActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdActoSubEstandar", DbType.Int32, pItem.IdActoSubEstandar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteActoSubEstandarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteActoSubEstandar_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteActoSubEstandar", DbType.Int32, pItem.IdAccidenteActoSubEstandar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteActoSubEstandarBE Selecciona(int IdAccidenteActoSubEstandar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteActoSubEstandar_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteActoSubEstandar", DbType.Int32, IdAccidenteActoSubEstandar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteActoSubEstandarBE AccidenteActoSubEstandar = null;
            while (reader.Read())
            {
                AccidenteActoSubEstandar = new AccidenteActoSubEstandarBE();
                AccidenteActoSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteActoSubEstandar.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteActoSubEstandar.IdAccidenteActoSubEstandar = Int32.Parse(reader["idAccidenteActoSubEstandar"].ToString());
                AccidenteActoSubEstandar.IdActoSubEstandar = Int32.Parse(reader["IdActoSubEstandar"].ToString());
                AccidenteActoSubEstandar.DescActoSubEstandar = reader["DescActoSubEstandar"].ToString();
                AccidenteActoSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteActoSubEstandar;
        }

        public List<AccidenteActoSubEstandarBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteActoSubEstandar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteActoSubEstandarBE> AccidenteActoSubEstandarlist = new List<AccidenteActoSubEstandarBE>();
            AccidenteActoSubEstandarBE AccidenteActoSubEstandar;
            while (reader.Read())
            {
                AccidenteActoSubEstandar = new AccidenteActoSubEstandarBE();
                AccidenteActoSubEstandar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteActoSubEstandar.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteActoSubEstandar.IdAccidenteActoSubEstandar = Int32.Parse(reader["idAccidenteActoSubEstandar"].ToString());
                AccidenteActoSubEstandar.IdActoSubEstandar = Int32.Parse(reader["IdActoSubEstandar"].ToString());
                AccidenteActoSubEstandar.DescActoSubEstandar = reader["DescActoSubEstandar"].ToString();
                AccidenteActoSubEstandar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteActoSubEstandar.TipoOper = 4; //CONSULTAR
                AccidenteActoSubEstandarlist.Add(AccidenteActoSubEstandar);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteActoSubEstandarlist;
        }
    }
}
