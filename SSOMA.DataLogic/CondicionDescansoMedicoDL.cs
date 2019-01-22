using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CondicionDescansoMedicoDL
    {
        public CondicionDescansoMedicoDL() { }

        public void Inserta(CondicionDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_Inserta");

            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, pItem.IdCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCondicionDescansoMedico", DbType.String, pItem.DescCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CondicionDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_Actualiza");

            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, pItem.IdCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCondicionDescansoMedico", DbType.String, pItem.DescCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CondicionDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_Elimina");

            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, pItem.IdCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CondicionDescansoMedicoBE Selecciona(int IdEmpresa, int idCondicionDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidCondicionDescansoMedico", DbType.Int32, idCondicionDescansoMedico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CondicionDescansoMedicoBE CondicionDescansoMedico = null;
            while (reader.Read())
            {
                CondicionDescansoMedico = new CondicionDescansoMedicoBE();
                CondicionDescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["idCondicionDescansoMedico"].ToString());
                CondicionDescansoMedico.DescCondicionDescansoMedico = reader["descCondicionDescansoMedico"].ToString();
                CondicionDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CondicionDescansoMedico;
        }

        public CondicionDescansoMedicoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CondicionDescansoMedicoBE CondicionDescansoMedico = null;
            while (reader.Read())
            {
                CondicionDescansoMedico = new CondicionDescansoMedicoBE();
                CondicionDescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["idCondicionDescansoMedico"].ToString());
                CondicionDescansoMedico.DescCondicionDescansoMedico = reader["descCondicionDescansoMedico"].ToString();
                CondicionDescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CondicionDescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                CondicionDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CondicionDescansoMedico;
        }

        public List<CondicionDescansoMedicoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CondicionDescansoMedicoBE> CondicionDescansoMedicolist = new List<CondicionDescansoMedicoBE>();
            CondicionDescansoMedicoBE CondicionDescansoMedico;
            while (reader.Read())
            {
                CondicionDescansoMedico = new CondicionDescansoMedicoBE();
                CondicionDescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CondicionDescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["idCondicionDescansoMedico"].ToString());
                CondicionDescansoMedico.DescCondicionDescansoMedico = reader["descCondicionDescansoMedico"].ToString();
                CondicionDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CondicionDescansoMedicolist.Add(CondicionDescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return CondicionDescansoMedicolist;
        }

        public List<CondicionDescansoMedicoBE> ListaCombo(int IdEmpresa, int IdCondicionDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CondicionDescansoMedico_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, IdCondicionDescansoMedico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CondicionDescansoMedicoBE> CondicionDescansoMedicolist = new List<CondicionDescansoMedicoBE>();
            CondicionDescansoMedicoBE CondicionDescansoMedico;
            while (reader.Read())
            {
                CondicionDescansoMedico = new CondicionDescansoMedicoBE();
                CondicionDescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["idCondicionDescansoMedico"].ToString());
                CondicionDescansoMedico.DescCondicionDescansoMedico = reader["descCondicionDescansoMedico"].ToString();
                CondicionDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CondicionDescansoMedicolist.Add(CondicionDescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return CondicionDescansoMedicolist;
        }
    }
}
