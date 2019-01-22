using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoDescansoMedicoDL
    {
        public TipoDescansoMedicoDL() { }

        public void Inserta(TipoDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, pItem.IdTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoDescansoMedico", DbType.String, pItem.DescTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, pItem.IdTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoDescansoMedico", DbType.String, pItem.DescTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoDescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, pItem.IdTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoDescansoMedicoBE Selecciona(int IdEmpresa, int idTipoDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidTipoDescansoMedico", DbType.Int32, idTipoDescansoMedico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoDescansoMedicoBE TipoDescansoMedico = null;
            while (reader.Read())
            {
                TipoDescansoMedico = new TipoDescansoMedicoBE();
                TipoDescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["idTipoDescansoMedico"].ToString());
                TipoDescansoMedico.DescTipoDescansoMedico = reader["descTipoDescansoMedico"].ToString();
                TipoDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoDescansoMedico;
        }

        public TipoDescansoMedicoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoDescansoMedicoBE TipoDescansoMedico = null;
            while (reader.Read())
            {
                TipoDescansoMedico = new TipoDescansoMedicoBE();
                TipoDescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["idTipoDescansoMedico"].ToString());
                TipoDescansoMedico.DescTipoDescansoMedico = reader["descTipoDescansoMedico"].ToString();
                TipoDescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoDescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                TipoDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoDescansoMedico;
        }

        public List<TipoDescansoMedicoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoDescansoMedicoBE> TipoDescansoMedicolist = new List<TipoDescansoMedicoBE>();
            TipoDescansoMedicoBE TipoDescansoMedico;
            while (reader.Read())
            {
                TipoDescansoMedico = new TipoDescansoMedicoBE();
                TipoDescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoDescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["idTipoDescansoMedico"].ToString());
                TipoDescansoMedico.DescTipoDescansoMedico = reader["descTipoDescansoMedico"].ToString();
                TipoDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoDescansoMedicolist.Add(TipoDescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return TipoDescansoMedicolist;
        }

        public List<TipoDescansoMedicoBE> ListaCombo(int IdEmpresa, int IdTipoDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDescansoMedico_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, IdTipoDescansoMedico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoDescansoMedicoBE> TipoDescansoMedicolist = new List<TipoDescansoMedicoBE>();
            TipoDescansoMedicoBE TipoDescansoMedico;
            while (reader.Read())
            {
                TipoDescansoMedico = new TipoDescansoMedicoBE();
                TipoDescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["idTipoDescansoMedico"].ToString());
                TipoDescansoMedico.DescTipoDescansoMedico = reader["descTipoDescansoMedico"].ToString();
                TipoDescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoDescansoMedicolist.Add(TipoDescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return TipoDescansoMedicolist;
        }
    }
}
