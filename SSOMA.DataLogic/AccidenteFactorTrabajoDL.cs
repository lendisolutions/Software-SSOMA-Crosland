using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteFactorTrabajoDL
    {
        public AccidenteFactorTrabajoDL() { }

        public void Inserta(AccidenteFactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorTrabajo_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorTrabajo", DbType.Int32, pItem.IdAccidenteFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, pItem.IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteFactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorTrabajo_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorTrabajo", DbType.Int32, pItem.IdAccidenteFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, pItem.IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteFactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorTrabajo_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteFactorTrabajo", DbType.Int32, pItem.IdAccidenteFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteFactorTrabajoBE Selecciona(int IdAccidenteFactorTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorTrabajo_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteFactorTrabajo", DbType.Int32, IdAccidenteFactorTrabajo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteFactorTrabajoBE AccidenteFactorTrabajo = null;
            while (reader.Read())
            {
                AccidenteFactorTrabajo = new AccidenteFactorTrabajoBE();
                AccidenteFactorTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFactorTrabajo.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFactorTrabajo.IdAccidenteFactorTrabajo = Int32.Parse(reader["idAccidenteFactorTrabajo"].ToString());
                AccidenteFactorTrabajo.IdFactorTrabajo = Int32.Parse(reader["IdFactorTrabajo"].ToString());
                AccidenteFactorTrabajo.DescFactorTrabajo = reader["DescFactorTrabajo"].ToString();
                AccidenteFactorTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFactorTrabajo;
        }

        public List<AccidenteFactorTrabajoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFactorTrabajo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteFactorTrabajoBE> AccidenteFactorTrabajolist = new List<AccidenteFactorTrabajoBE>();
            AccidenteFactorTrabajoBE AccidenteFactorTrabajo;
            while (reader.Read())
            {
                AccidenteFactorTrabajo = new AccidenteFactorTrabajoBE();
                AccidenteFactorTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFactorTrabajo.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFactorTrabajo.IdAccidenteFactorTrabajo = Int32.Parse(reader["idAccidenteFactorTrabajo"].ToString());
                AccidenteFactorTrabajo.IdFactorTrabajo = Int32.Parse(reader["IdFactorTrabajo"].ToString());
                AccidenteFactorTrabajo.DescFactorTrabajo = reader["DescFactorTrabajo"].ToString();
                AccidenteFactorTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteFactorTrabajo.TipoOper = 4; //CONSULTAR
                AccidenteFactorTrabajolist.Add(AccidenteFactorTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFactorTrabajolist;
        }
    }
}
