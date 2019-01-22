using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SenalizacionDL
    {
        public SenalizacionDL() { }

        public void Inserta(SenalizacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_Inserta");

            db.AddInParameter(dbCommand, "pIdSenalizacion", DbType.Int32, pItem.IdSenalizacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescSenalizacion", DbType.String, pItem.DescSenalizacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SenalizacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdSenalizacion", DbType.Int32, pItem.IdSenalizacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescSenalizacion", DbType.String, pItem.DescSenalizacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SenalizacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_Elimina");

            db.AddInParameter(dbCommand, "pIdSenalizacion", DbType.Int32, pItem.IdSenalizacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SenalizacionBE Selecciona(int idSenalizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_Selecciona");
            db.AddInParameter(dbCommand, "pidSenalizacion", DbType.Int32, idSenalizacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SenalizacionBE Senalizacion = null;
            while (reader.Read())
            {
                Senalizacion = new SenalizacionBE();
                Senalizacion.IdSenalizacion = Int32.Parse(reader["idSenalizacion"].ToString());
                Senalizacion.DescSenalizacion = reader["descSenalizacion"].ToString();
                Senalizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Senalizacion;
        }

        public List<SenalizacionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SenalizacionBE> Senalizacionlist = new List<SenalizacionBE>();
            SenalizacionBE Senalizacion;
            while (reader.Read())
            {
                Senalizacion = new SenalizacionBE();
                Senalizacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Senalizacion.IdSenalizacion = Int32.Parse(reader["idSenalizacion"].ToString());
                Senalizacion.DescSenalizacion = reader["descSenalizacion"].ToString();
                Senalizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Senalizacionlist.Add(Senalizacion);
            }
            reader.Close();
            reader.Dispose();
            return Senalizacionlist;
        }

        public List<SenalizacionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Senalizacion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SenalizacionBE> Senalizacionlist = new List<SenalizacionBE>();
            SenalizacionBE Senalizacion;
            while (reader.Read())
            {
                Senalizacion = new SenalizacionBE();
                Senalizacion.IdSenalizacion = Int32.Parse(reader["idSenalizacion"].ToString());
                Senalizacion.DescSenalizacion = reader["descSenalizacion"].ToString();
                Senalizacionlist.Add(Senalizacion);
            }
            reader.Close();
            reader.Dispose();
            return Senalizacionlist;
        }
    }
}
