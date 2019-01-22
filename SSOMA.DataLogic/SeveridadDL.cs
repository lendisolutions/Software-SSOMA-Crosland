using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SeveridadDL
    {
        public SeveridadDL() { }

        public void Inserta(SeveridadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Severidad_Inserta");

            db.AddInParameter(dbCommand, "pIdSeveridad", DbType.Int32, pItem.IdSeveridad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValorSeveridad", DbType.Int32, pItem.ValorSeveridad);
            db.AddInParameter(dbCommand, "pDescSeveridad", DbType.String, pItem.DescSeveridad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SeveridadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Severidad_Actualiza");

            db.AddInParameter(dbCommand, "pIdSeveridad", DbType.Int32, pItem.IdSeveridad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValorSeveridad", DbType.Int32, pItem.ValorSeveridad);
            db.AddInParameter(dbCommand, "pDescSeveridad", DbType.String, pItem.DescSeveridad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SeveridadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Severidad_Elimina");

            db.AddInParameter(dbCommand, "pIdSeveridad", DbType.Int32, pItem.IdSeveridad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SeveridadBE Selecciona(int idSeveridad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Severidad_Selecciona");
            db.AddInParameter(dbCommand, "pidSeveridad", DbType.Int32, idSeveridad);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeveridadBE Severidad = null;
            while (reader.Read())
            {
                Severidad = new SeveridadBE();
                Severidad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Severidad.IdSeveridad = Int32.Parse(reader["idSeveridad"].ToString());
                Severidad.ValorSeveridad = Int32.Parse(reader["ValorSeveridad"].ToString());
                Severidad.DescSeveridad = reader["DescSeveridad"].ToString();
                Severidad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Severidad;
        }

        public List<SeveridadBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Severidad_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeveridadBE> Severidadlist = new List<SeveridadBE>();
            SeveridadBE Severidad;
            while (reader.Read())
            {
                Severidad = new SeveridadBE();
                Severidad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Severidad.IdSeveridad = Int32.Parse(reader["idSeveridad"].ToString());
                Severidad.ValorSeveridad = Int32.Parse(reader["ValorSeveridad"].ToString());
                Severidad.DescSeveridad = reader["DescSeveridad"].ToString();
                Severidad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Severidadlist.Add(Severidad);
            }
            reader.Close();
            reader.Dispose();
            return Severidadlist;
        }

    }
}
