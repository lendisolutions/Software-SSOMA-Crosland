using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CategoriaDiagnosticoDL
    {
        public CategoriaDiagnosticoDL() { }

        public void Inserta(CategoriaDiagnosticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_Inserta");

            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, pItem.IdCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescCategoriaDiagnostico", DbType.String, pItem.DescCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CategoriaDiagnosticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_Actualiza");

            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, pItem.IdCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescCategoriaDiagnostico", DbType.String, pItem.DescCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CategoriaDiagnosticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_Elimina");

            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, pItem.IdCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CategoriaDiagnosticoBE Selecciona(int IdEmpresa, int idCategoriaDiagnostico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidCategoriaDiagnostico", DbType.Int32, idCategoriaDiagnostico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CategoriaDiagnosticoBE CategoriaDiagnostico = null;
            while (reader.Read())
            {
                CategoriaDiagnostico = new CategoriaDiagnosticoBE();
                CategoriaDiagnostico.IdCategoriaDiagnostico = Int32.Parse(reader["idCategoriaDiagnostico"].ToString());
                CategoriaDiagnostico.Abreviatura = reader["Abreviatura"].ToString();
                CategoriaDiagnostico.DescCategoriaDiagnostico = reader["descCategoriaDiagnostico"].ToString();
                CategoriaDiagnostico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CategoriaDiagnostico;
        }

        public CategoriaDiagnosticoBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CategoriaDiagnosticoBE CategoriaDiagnostico = null;
            while (reader.Read())
            {
                CategoriaDiagnostico = new CategoriaDiagnosticoBE();
                CategoriaDiagnostico.IdCategoriaDiagnostico = Int32.Parse(reader["idCategoriaDiagnostico"].ToString());
                CategoriaDiagnostico.DescCategoriaDiagnostico = reader["descCategoriaDiagnostico"].ToString();
                CategoriaDiagnostico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CategoriaDiagnostico.RazonSocial = reader["RazonSocial"].ToString();
                CategoriaDiagnostico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CategoriaDiagnostico;
        }

        public List<CategoriaDiagnosticoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CategoriaDiagnosticoBE> CategoriaDiagnosticolist = new List<CategoriaDiagnosticoBE>();
            CategoriaDiagnosticoBE CategoriaDiagnostico;
            while (reader.Read())
            {
                CategoriaDiagnostico = new CategoriaDiagnosticoBE();
                CategoriaDiagnostico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CategoriaDiagnostico.IdCategoriaDiagnostico = Int32.Parse(reader["idCategoriaDiagnostico"].ToString());
                CategoriaDiagnostico.Abreviatura = reader["Abreviatura"].ToString();
                CategoriaDiagnostico.DescCategoriaDiagnostico = reader["descCategoriaDiagnostico"].ToString();
                CategoriaDiagnostico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CategoriaDiagnosticolist.Add(CategoriaDiagnostico);
            }
            reader.Close();
            reader.Dispose();
            return CategoriaDiagnosticolist;
        }

        public List<CategoriaDiagnosticoBE> ListaCombo(int IdEmpresa, int IdCategoriaDiagnostico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CategoriaDiagnostico_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, IdCategoriaDiagnostico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CategoriaDiagnosticoBE> CategoriaDiagnosticolist = new List<CategoriaDiagnosticoBE>();
            CategoriaDiagnosticoBE CategoriaDiagnostico;
            while (reader.Read())
            {
                CategoriaDiagnostico = new CategoriaDiagnosticoBE();
                CategoriaDiagnostico.IdCategoriaDiagnostico = Int32.Parse(reader["idCategoriaDiagnostico"].ToString());
                CategoriaDiagnostico.Abreviatura = reader["Abreviatura"].ToString();
                CategoriaDiagnostico.DescCategoriaDiagnostico = reader["descCategoriaDiagnostico"].ToString();
                CategoriaDiagnostico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CategoriaDiagnosticolist.Add(CategoriaDiagnostico);
            }
            reader.Close();
            reader.Dispose();
            return CategoriaDiagnosticolist;
        }
    }
}
