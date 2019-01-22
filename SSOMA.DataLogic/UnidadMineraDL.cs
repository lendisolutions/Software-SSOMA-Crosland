using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class UnidadMineraDL
    {
        public UnidadMineraDL() { }

        public void Inserta(UnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_Inserta");

            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescUnidadMinera", DbType.String, pItem.DescUnidadMinera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(UnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_Actualiza");

            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescUnidadMinera", DbType.String, pItem.DescUnidadMinera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(UnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_Elimina");

            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public UnidadMineraBE Selecciona(int IdEmpresa, int idUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidUnidadMinera", DbType.Int32, idUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UnidadMineraBE UnidadMinera = null;
            while (reader.Read())
            {
                UnidadMinera = new UnidadMineraBE();
                UnidadMinera.IdUnidadMinera = Int32.Parse(reader["idUnidadMinera"].ToString());
                UnidadMinera.DescUnidadMinera = reader["descUnidadMinera"].ToString();
                UnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return UnidadMinera;
        }

        public UnidadMineraBE SeleccionaDescripcion(int IdEmpresa, string DescUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDescUnidadMinera", DbType.String, DescUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UnidadMineraBE UnidadMinera = null;
            while (reader.Read())
            {
                UnidadMinera = new UnidadMineraBE();
                UnidadMinera.IdUnidadMinera = Int32.Parse(reader["idUnidadMinera"].ToString());
                UnidadMinera.DescUnidadMinera = reader["descUnidadMinera"].ToString();
                UnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return UnidadMinera;
        }

        public UnidadMineraBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UnidadMineraBE UnidadMinera = null;
            while (reader.Read())
            {
                UnidadMinera = new UnidadMineraBE();
                UnidadMinera.IdUnidadMinera = Int32.Parse(reader["idUnidadMinera"].ToString());
                UnidadMinera.DescUnidadMinera = reader["descUnidadMinera"].ToString();
                UnidadMinera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                UnidadMinera.RazonSocial = reader["RazonSocial"].ToString();
                UnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return UnidadMinera;
        }

        public List<UnidadMineraBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UnidadMineraBE> UnidadMineralist = new List<UnidadMineraBE>();
            UnidadMineraBE UnidadMinera;
            while (reader.Read())
            {
                UnidadMinera = new UnidadMineraBE();
                UnidadMinera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                UnidadMinera.IdUnidadMinera = Int32.Parse(reader["idUnidadMinera"].ToString());
                UnidadMinera.DescUnidadMinera = reader["descUnidadMinera"].ToString();
                UnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UnidadMineralist.Add(UnidadMinera);
            }
            reader.Close();
            reader.Dispose();
            return UnidadMineralist;
        }

        public List<UnidadMineraBE> ListaCombo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMinera_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UnidadMineraBE> UnidadMineralist = new List<UnidadMineraBE>();
            UnidadMineraBE UnidadMinera;
            while (reader.Read())
            {
                UnidadMinera = new UnidadMineraBE();
                UnidadMinera.IdUnidadMinera = Int32.Parse(reader["idUnidadMinera"].ToString());
                UnidadMinera.DescUnidadMinera = reader["descUnidadMinera"].ToString();
                UnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UnidadMineralist.Add(UnidadMinera);
            }
            reader.Close();
            reader.Dispose();
            return UnidadMineralist;
        }
    }
}
