using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteMedidaPrevencionDL
    {
        public AccidenteMedidaPrevencionDL() { }

        public void Inserta(AccidenteMedidaPrevencionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteMedidaPrevencion_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteMedidaPrevencion", DbType.Int32, pItem.IdAccidenteMedidaPrevencion);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDescMedidaPrevencion", DbType.String, pItem.DescMedidaPrevencion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteMedidaPrevencionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteMedidaPrevencion_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteMedidaPrevencion", DbType.Int32, pItem.IdAccidenteMedidaPrevencion);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDescMedidaPrevencion", DbType.String, pItem.DescMedidaPrevencion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteMedidaPrevencionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteMedidaPrevencion_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteMedidaPrevencion", DbType.Int32, pItem.IdAccidenteMedidaPrevencion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteMedidaPrevencionBE Selecciona(int IdAccidenteMedidaPrevencion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteMedidaPrevencion_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteMedidaPrevencion", DbType.Int32, IdAccidenteMedidaPrevencion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteMedidaPrevencionBE AccidenteMedidaPrevencion = null;
            while (reader.Read())
            {
                AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBE();
                AccidenteMedidaPrevencion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteMedidaPrevencion.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteMedidaPrevencion.IdAccidenteMedidaPrevencion = Int32.Parse(reader["idAccidenteMedidaPrevencion"].ToString());
                AccidenteMedidaPrevencion.DescMedidaPrevencion = reader["DescMedidaPrevencion"].ToString();
                AccidenteMedidaPrevencion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteMedidaPrevencion;
        }

        public List<AccidenteMedidaPrevencionBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteMedidaPrevencion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteMedidaPrevencionBE> AccidenteMedidaPrevencionlist = new List<AccidenteMedidaPrevencionBE>();
            AccidenteMedidaPrevencionBE AccidenteMedidaPrevencion;
            while (reader.Read())
            {
                AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBE();
                AccidenteMedidaPrevencion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteMedidaPrevencion.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteMedidaPrevencion.IdAccidenteMedidaPrevencion = Int32.Parse(reader["idAccidenteMedidaPrevencion"].ToString());
                AccidenteMedidaPrevencion.DescMedidaPrevencion = reader["DescMedidaPrevencion"].ToString();
                AccidenteMedidaPrevencion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteMedidaPrevencion.TipoOper = 4; //CONSULTAR
                AccidenteMedidaPrevencionlist.Add(AccidenteMedidaPrevencion);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteMedidaPrevencionlist;
        }
    }
}
