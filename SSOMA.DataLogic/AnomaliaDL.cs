using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AnomaliaDL
    {
        public AnomaliaDL() { }

        public void Inserta(AnomaliaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_Inserta");

            db.AddInParameter(dbCommand, "pIdAnomalia", DbType.Int32, pItem.IdAnomalia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescAnomalia", DbType.String, pItem.DescAnomalia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AnomaliaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_Actualiza");

            db.AddInParameter(dbCommand, "pIdAnomalia", DbType.Int32, pItem.IdAnomalia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescAnomalia", DbType.String, pItem.DescAnomalia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AnomaliaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_Elimina");

            db.AddInParameter(dbCommand, "pIdAnomalia", DbType.Int32, pItem.IdAnomalia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AnomaliaBE Selecciona(int IdEmpresa, int idAnomalia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidAnomalia", DbType.Int32, idAnomalia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AnomaliaBE Anomalia = null;
            while (reader.Read())
            {
                Anomalia = new AnomaliaBE();
                Anomalia.IdAnomalia = Int32.Parse(reader["idAnomalia"].ToString());
                Anomalia.DescAnomalia = reader["descAnomalia"].ToString();
                Anomalia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Anomalia;
        }

        public AnomaliaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AnomaliaBE Anomalia = null;
            while (reader.Read())
            {
                Anomalia = new AnomaliaBE();
                Anomalia.IdAnomalia = Int32.Parse(reader["idAnomalia"].ToString());
                Anomalia.DescAnomalia = reader["descAnomalia"].ToString();
                Anomalia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Anomalia.RazonSocial = reader["RazonSocial"].ToString();
                Anomalia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Anomalia;
        }

        public List<AnomaliaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AnomaliaBE> Anomalialist = new List<AnomaliaBE>();
            AnomaliaBE Anomalia;
            while (reader.Read())
            {
                Anomalia = new AnomaliaBE();
                Anomalia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Anomalia.IdAnomalia = Int32.Parse(reader["idAnomalia"].ToString());
                Anomalia.DescAnomalia = reader["descAnomalia"].ToString();
                Anomalia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Anomalialist.Add(Anomalia);
            }
            reader.Close();
            reader.Dispose();
            return Anomalialist;
        }

        public List<AnomaliaBE> ListaCombo(int IdEmpresa, int IdAnomalia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anomalia_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAnomalia", DbType.Int32, IdAnomalia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AnomaliaBE> Anomalialist = new List<AnomaliaBE>();
            AnomaliaBE Anomalia;
            while (reader.Read())
            {
                Anomalia = new AnomaliaBE();
                Anomalia.IdAnomalia = Int32.Parse(reader["idAnomalia"].ToString());
                Anomalia.DescAnomalia = reader["descAnomalia"].ToString();
                Anomalia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Anomalialist.Add(Anomalia);
            }
            reader.Close();
            reader.Dispose();
            return Anomalialist;
        }
    }
}
