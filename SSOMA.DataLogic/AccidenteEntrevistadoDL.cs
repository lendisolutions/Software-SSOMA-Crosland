using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteEntrevistadoDL
    {
        public AccidenteEntrevistadoDL() { }

        public void Inserta(AccidenteEntrevistadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteEntrevistado_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteEntrevistado", DbType.Int32, pItem.IdAccidenteEntrevistado);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdEntrevistado", DbType.Int32, pItem.IdEntrevistado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteEntrevistadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteEntrevistado_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteEntrevistado", DbType.Int32, pItem.IdAccidenteEntrevistado);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdEntrevistado", DbType.Int32, pItem.IdEntrevistado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteEntrevistadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteEntrevistado_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteEntrevistado", DbType.Int32, pItem.IdAccidenteEntrevistado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteEntrevistadoBE Selecciona(int IdAccidenteEntrevistado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteEntrevistado_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteEntrevistado", DbType.Int32, IdAccidenteEntrevistado);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteEntrevistadoBE AccidenteEntrevistado = null;
            while (reader.Read())
            {
                AccidenteEntrevistado = new AccidenteEntrevistadoBE();
                AccidenteEntrevistado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteEntrevistado.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteEntrevistado.IdAccidenteEntrevistado = Int32.Parse(reader["idAccidenteEntrevistado"].ToString());
                AccidenteEntrevistado.IdEntrevistado = Int32.Parse(reader["IdEntrevistado"].ToString());
                AccidenteEntrevistado.Entrevistado = reader["Entrevistado"].ToString();
                AccidenteEntrevistado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteEntrevistado;
        }

        public List<AccidenteEntrevistadoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteEntrevistado_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteEntrevistadoBE> AccidenteEntrevistadolist = new List<AccidenteEntrevistadoBE>();
            AccidenteEntrevistadoBE AccidenteEntrevistado;
            while (reader.Read())
            {
                AccidenteEntrevistado = new AccidenteEntrevistadoBE();
                AccidenteEntrevistado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteEntrevistado.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteEntrevistado.IdAccidenteEntrevistado = Int32.Parse(reader["idAccidenteEntrevistado"].ToString());
                AccidenteEntrevistado.IdEntrevistado = Int32.Parse(reader["IdEntrevistado"].ToString());
                AccidenteEntrevistado.Entrevistado = reader["Entrevistado"].ToString();
                AccidenteEntrevistado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteEntrevistado.TipoOper = 4; //CONSULTAR
                AccidenteEntrevistadolist.Add(AccidenteEntrevistado);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteEntrevistadolist;
        }
    }
}
