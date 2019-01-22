using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class LugarDL
    {
        public LugarDL() { }

        public void Inserta(LugarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_Inserta");

            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescLugar", DbType.String, pItem.DescLugar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(LugarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_Actualiza");

            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescLugar", DbType.String, pItem.DescLugar);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(LugarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_Elimina");

            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public LugarBE Selecciona(int IdEmpresa, int idLugar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidLugar", DbType.Int32, idLugar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LugarBE Lugar = null;
            while (reader.Read())
            {
                Lugar = new LugarBE();
                Lugar.IdLugar = Int32.Parse(reader["idLugar"].ToString());
                Lugar.DescLugar = reader["descLugar"].ToString();
                Lugar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Lugar;
        }

        public LugarBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LugarBE Lugar = null;
            while (reader.Read())
            {
                Lugar = new LugarBE();
                Lugar.IdLugar = Int32.Parse(reader["idLugar"].ToString());
                Lugar.DescLugar = reader["descLugar"].ToString();
                Lugar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Lugar.RazonSocial = reader["RazonSocial"].ToString();
                Lugar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Lugar;
        }

        public List<LugarBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LugarBE> Lugarlist = new List<LugarBE>();
            LugarBE Lugar;
            while (reader.Read())
            {
                Lugar = new LugarBE();
                Lugar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Lugar.IdLugar = Int32.Parse(reader["idLugar"].ToString());
                Lugar.DescLugar = reader["descLugar"].ToString();
                Lugar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Lugarlist.Add(Lugar);
            }
            reader.Close();
            reader.Dispose();
            return Lugarlist;
        }

        public List<LugarBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lugar_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
          
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LugarBE> Lugarlist = new List<LugarBE>();
            LugarBE Lugar;
            while (reader.Read())
            {
                Lugar = new LugarBE();
                Lugar.IdLugar = Int32.Parse(reader["idLugar"].ToString());
                Lugar.DescLugar = reader["descLugar"].ToString();
                Lugarlist.Add(Lugar);
            }
            reader.Close();
            reader.Dispose();
            return Lugarlist;
        }
    }
}
