using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PeligroDL
    {
        public PeligroDL() { }

        public void Inserta(PeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Peligro_Inserta");

            db.AddInParameter(dbCommand, "pIdPeligro", DbType.Int32, pItem.IdPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, pItem.IdTipoPeligro);
            db.AddInParameter(dbCommand, "pDescPeligro", DbType.String, pItem.DescPeligro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Peligro_Actualiza");

            db.AddInParameter(dbCommand, "pIdPeligro", DbType.Int32, pItem.IdPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, pItem.IdTipoPeligro);
            db.AddInParameter(dbCommand, "pDescPeligro", DbType.String, pItem.DescPeligro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PeligroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Peligro_Elimina");

            db.AddInParameter(dbCommand, "pIdPeligro", DbType.Int32, pItem.IdPeligro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PeligroBE Selecciona(int IdPeligro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Peligro_Selecciona");
            db.AddInParameter(dbCommand, "pidPeligro", DbType.Int32, IdPeligro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PeligroBE Peligro = null;
            while (reader.Read())
            {
                Peligro = new PeligroBE();
                Peligro.IdPeligro = Int32.Parse(reader["idPeligro"].ToString());
                Peligro.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Peligro.RazonSocial = reader["RazonSocial"].ToString();
                Peligro.IdTipoPeligro = Int32.Parse(reader["IdTipoPeligro"].ToString());
                Peligro.DescTipoPeligro = reader["DescTipoPeligro"].ToString();
                Peligro.DescPeligro = reader["DescPeligro"].ToString();
                Peligro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Peligro;
        }

        public List<PeligroBE> ListaTodosActivo(int IdEmpresa, int IdTipoPeligro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Peligro_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoPeligro", DbType.Int32, IdTipoPeligro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PeligroBE> Peligrolist = new List<PeligroBE>();
            PeligroBE Peligro;
            while (reader.Read())
            {
                Peligro = new PeligroBE();
                Peligro.IdPeligro = Int32.Parse(reader["idPeligro"].ToString());
                Peligro.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Peligro.RazonSocial = reader["RazonSocial"].ToString();
                Peligro.IdTipoPeligro = Int32.Parse(reader["IdTipoPeligro"].ToString());
                Peligro.DescTipoPeligro = reader["DescTipoPeligro"].ToString();
                Peligro.DescPeligro = reader["DescPeligro"].ToString();
                Peligro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Peligrolist.Add(Peligro);
            }
            reader.Close();
            reader.Dispose();
            return Peligrolist;
        }
    }
}
