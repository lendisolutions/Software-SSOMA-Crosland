using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteTestigoDL
    {
        public AccidenteTestigoDL() { }

        public void Inserta(AccidenteTestigoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteTestigo_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteTestigo", DbType.Int32, pItem.IdAccidenteTestigo);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdTestigo", DbType.Int32, pItem.IdTestigo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteTestigoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteTestigo_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteTestigo", DbType.Int32, pItem.IdAccidenteTestigo);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdTestigo", DbType.Int32, pItem.IdTestigo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteTestigoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteTestigo_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteTestigo", DbType.Int32, pItem.IdAccidenteTestigo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteTestigoBE Selecciona(int IdAccidenteTestigo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteTestigo_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteTestigo", DbType.Int32, IdAccidenteTestigo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteTestigoBE AccidenteTestigo = null;
            while (reader.Read())
            {
                AccidenteTestigo = new AccidenteTestigoBE();
                AccidenteTestigo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteTestigo.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteTestigo.IdAccidenteTestigo = Int32.Parse(reader["idAccidenteTestigo"].ToString());
                AccidenteTestigo.IdTestigo = Int32.Parse(reader["IdTestigo"].ToString());
                AccidenteTestigo.Testigo = reader["Testigo"].ToString();
                AccidenteTestigo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteTestigo;
        }

        public List<AccidenteTestigoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteTestigo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteTestigoBE> AccidenteTestigolist = new List<AccidenteTestigoBE>();
            AccidenteTestigoBE AccidenteTestigo;
            while (reader.Read())
            {
                AccidenteTestigo = new AccidenteTestigoBE();
                AccidenteTestigo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteTestigo.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteTestigo.IdAccidenteTestigo = Int32.Parse(reader["idAccidenteTestigo"].ToString());
                AccidenteTestigo.IdTestigo = Int32.Parse(reader["IdTestigo"].ToString());
                AccidenteTestigo.Testigo = reader["Testigo"].ToString();
                AccidenteTestigo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteTestigo.TipoOper = 4; //CONSULTAR
                AccidenteTestigolist.Add(AccidenteTestigo);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteTestigolist;
        }
    }
}
