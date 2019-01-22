using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ContingenciaDL
    {
        public ContingenciaDL() { }

        public void Inserta(ContingenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_Inserta");

            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, pItem.IdContingencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescContingencia", DbType.String, pItem.DescContingencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ContingenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, pItem.IdContingencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescContingencia", DbType.String, pItem.DescContingencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ContingenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_Elimina");

            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, pItem.IdContingencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ContingenciaBE Selecciona(int IdEmpresa, int idContingencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidContingencia", DbType.Int32, idContingencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ContingenciaBE Contingencia = null;
            while (reader.Read())
            {
                Contingencia = new ContingenciaBE();
                Contingencia.IdContingencia = Int32.Parse(reader["idContingencia"].ToString());
                Contingencia.DescContingencia = reader["descContingencia"].ToString();
                Contingencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Contingencia;
        }

        public ContingenciaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ContingenciaBE Contingencia = null;
            while (reader.Read())
            {
                Contingencia = new ContingenciaBE();
                Contingencia.IdContingencia = Int32.Parse(reader["idContingencia"].ToString());
                Contingencia.DescContingencia = reader["descContingencia"].ToString();
                Contingencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contingencia.RazonSocial = reader["RazonSocial"].ToString();
                Contingencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Contingencia;
        }

        public List<ContingenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ContingenciaBE> Contingencialist = new List<ContingenciaBE>();
            ContingenciaBE Contingencia;
            while (reader.Read())
            {
                Contingencia = new ContingenciaBE();
                Contingencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contingencia.IdContingencia = Int32.Parse(reader["idContingencia"].ToString());
                Contingencia.DescContingencia = reader["descContingencia"].ToString();
                Contingencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Contingencialist.Add(Contingencia);
            }
            reader.Close();
            reader.Dispose();
            return Contingencialist;
        }

        public List<ContingenciaBE> ListaCombo(int IdEmpresa, int IdContingencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contingencia_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, IdContingencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ContingenciaBE> Contingencialist = new List<ContingenciaBE>();
            ContingenciaBE Contingencia;
            while (reader.Read())
            {
                Contingencia = new ContingenciaBE();
                Contingencia.IdContingencia = Int32.Parse(reader["idContingencia"].ToString());
                Contingencia.DescContingencia = reader["descContingencia"].ToString();
                Contingencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Contingencialist.Add(Contingencia);
            }
            reader.Close();
            reader.Dispose();
            return Contingencialist;
        }
    }
}
