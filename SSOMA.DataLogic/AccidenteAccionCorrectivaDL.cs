using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteAccionCorrectivaDL
    {
        public AccidenteAccionCorrectivaDL() { }

        public void Inserta(AccidenteAccionCorrectivaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteAccionCorrectiva", DbType.Int32, pItem.IdAccidenteAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDescAccionCorrectiva", DbType.String, pItem.DescAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCumplimiento", DbType.DateTime, pItem.FechaCumplimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteAccionCorrectivaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteAccionCorrectiva", DbType.Int32, pItem.IdAccidenteAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDescAccionCorrectiva", DbType.String, pItem.DescAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCumplimiento", DbType.DateTime, pItem.FechaCumplimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdAccidenteAccionCorrectiva, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdAccidenteAccionCorrectiva", DbType.Int32, IdAccidenteAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteAccionCorrectivaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteAccionCorrectiva", DbType.Int32, pItem.IdAccidenteAccionCorrectiva);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteAccionCorrectivaBE Selecciona(int IdAccidenteAccionCorrectiva)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteAccionCorrectiva", DbType.Int32, IdAccidenteAccionCorrectiva);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteAccionCorrectivaBE AccidenteAccionCorrectiva = null;
            while (reader.Read())
            {
                AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBE();
                AccidenteAccionCorrectiva.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteAccionCorrectiva.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteAccionCorrectiva.IdAccidenteAccionCorrectiva = Int32.Parse(reader["idAccidenteAccionCorrectiva"].ToString());
                AccidenteAccionCorrectiva.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                AccidenteAccionCorrectiva.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                AccidenteAccionCorrectiva.Responsable = reader["Responsable"].ToString();
                AccidenteAccionCorrectiva.FechaCumplimiento = DateTime.Parse(reader["FechaCumplimiento"].ToString());
                AccidenteAccionCorrectiva.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                AccidenteAccionCorrectiva.DescSituacion = reader["DescSituacion"].ToString();
                AccidenteAccionCorrectiva.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteAccionCorrectiva;
        }

        public List<AccidenteAccionCorrectivaBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteAccionCorrectiva_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteAccionCorrectivaBE> AccidenteAccionCorrectivalist = new List<AccidenteAccionCorrectivaBE>();
            AccidenteAccionCorrectivaBE AccidenteAccionCorrectiva;
            while (reader.Read())
            {
                AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBE();
                AccidenteAccionCorrectiva.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteAccionCorrectiva.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteAccionCorrectiva.IdAccidenteAccionCorrectiva = Int32.Parse(reader["idAccidenteAccionCorrectiva"].ToString());
                AccidenteAccionCorrectiva.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                AccidenteAccionCorrectiva.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                AccidenteAccionCorrectiva.Responsable = reader["Responsable"].ToString();
                AccidenteAccionCorrectiva.FechaCumplimiento = DateTime.Parse(reader["FechaCumplimiento"].ToString());
                AccidenteAccionCorrectiva.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                AccidenteAccionCorrectiva.DescSituacion = reader["DescSituacion"].ToString();
                AccidenteAccionCorrectiva.FlagEstado = Boolean.Parse(reader["flagestado"].ToString()); ;
                AccidenteAccionCorrectiva.TipoOper = 4; //CONSULTAR
                AccidenteAccionCorrectivalist.Add(AccidenteAccionCorrectiva);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteAccionCorrectivalist;
        }
    }
}
