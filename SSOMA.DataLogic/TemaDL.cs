using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TemaDL
    {
        public TemaDL() { }

        public void Inserta(TemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Inserta");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pDescTema", DbType.String, pItem.DescTema);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Actualiza");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pDescTema", DbType.String, pItem.DescTema);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Elimina");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TemaBE Selecciona(int IdEmpresa, int idTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidTema", DbType.Int32, idTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaBE Tema = null;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.DescTema = reader["descTema"].ToString();
                Tema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Tema;
        }

        public TemaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaBE Tema = null;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.DescTema = reader["descTema"].ToString();
                Tema.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Tema.RazonSocial = reader["RazonSocial"].ToString();
                Tema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Tema;
        }

        public List<TemaBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaBE> Temalist = new List<TemaBE>();
            TemaBE Tema;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Tema.DescTema = reader["descTema"].ToString();
                Tema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Temalist.Add(Tema);
            }
            reader.Close();
            reader.Dispose();
            return Temalist;
        }

        public List<TemaBE> ListaCombo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaBE> Temalist = new List<TemaBE>();
            TemaBE Tema;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.DescTema = reader["descTema"].ToString();
                Temalist.Add(Tema);
            }
            reader.Close();
            reader.Dispose();
            return Temalist;
        }
    }
}
