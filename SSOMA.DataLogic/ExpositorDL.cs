using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ExpositorDL
    {
        public ExpositorDL() { }

        public void Inserta(ExpositorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_Inserta");

            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, pItem.IdExpositor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEmpresa", DbType.String, pItem.DescEmpresa);
            db.AddInParameter(dbCommand, "pDescExpositor", DbType.String, pItem.DescExpositor);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ExpositorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_Actualiza");

            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, pItem.IdExpositor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEmpresa", DbType.String, pItem.DescEmpresa);
            db.AddInParameter(dbCommand, "pDescExpositor", DbType.String, pItem.DescExpositor);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ExpositorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_Elimina");

            db.AddInParameter(dbCommand, "pIdExpositor", DbType.Int32, pItem.IdExpositor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ExpositorBE Selecciona(int IdEmpresa, int idExpositor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidExpositor", DbType.Int32, idExpositor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExpositorBE Expositor = null;
            while (reader.Read())
            {
                Expositor = new ExpositorBE();
                Expositor.IdExpositor = Int32.Parse(reader["idExpositor"].ToString());
                Expositor.DescEmpresa = reader["DescEmpresa"].ToString();
                Expositor.DescExpositor = reader["descExpositor"].ToString();
                Expositor.Cargo = reader["Cargo"].ToString();
                Expositor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Expositor;
        }

        public ExpositorBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExpositorBE Expositor = null;
            while (reader.Read())
            {
                Expositor = new ExpositorBE();
                Expositor.IdExpositor = Int32.Parse(reader["idExpositor"].ToString());
                Expositor.DescExpositor = reader["descExpositor"].ToString();
                Expositor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Expositor.RazonSocial = reader["RazonSocial"].ToString();
                Expositor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Expositor;
        }

        public List<ExpositorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExpositorBE> Expositorlist = new List<ExpositorBE>();
            ExpositorBE Expositor;
            while (reader.Read())
            {
                Expositor = new ExpositorBE();
                Expositor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Expositor.IdExpositor = Int32.Parse(reader["idExpositor"].ToString());
                Expositor.DescEmpresa = reader["DescEmpresa"].ToString();
                Expositor.DescExpositor = reader["descExpositor"].ToString();
                Expositor.Cargo = reader["Cargo"].ToString();
                Expositor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Expositorlist.Add(Expositor);
            }
            reader.Close();
            reader.Dispose();
            return Expositorlist;
        }

        public List<ExpositorBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Expositor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
          
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExpositorBE> Expositorlist = new List<ExpositorBE>();
            ExpositorBE Expositor;
            while (reader.Read())
            {
                Expositor = new ExpositorBE();
                Expositor.IdExpositor = Int32.Parse(reader["idExpositor"].ToString());
                Expositor.DescExpositor = reader["descExpositor"].ToString();
                Expositorlist.Add(Expositor);
            }
            reader.Close();
            reader.Dispose();
            return Expositorlist;
        }
    }
}
