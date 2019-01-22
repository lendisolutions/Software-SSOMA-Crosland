using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EliminacionDL
    {
        public EliminacionDL() { }

        public void Inserta(EliminacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_Inserta");

            db.AddInParameter(dbCommand, "pIdEliminacion", DbType.Int32, pItem.IdEliminacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEliminacion", DbType.String, pItem.DescEliminacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(EliminacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdEliminacion", DbType.Int32, pItem.IdEliminacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEliminacion", DbType.String, pItem.DescEliminacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(EliminacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_Elimina");

            db.AddInParameter(dbCommand, "pIdEliminacion", DbType.Int32, pItem.IdEliminacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public EliminacionBE Selecciona(int idEliminacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_Selecciona");
            db.AddInParameter(dbCommand, "pidEliminacion", DbType.Int32, idEliminacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EliminacionBE Eliminacion = null;
            while (reader.Read())
            {
                Eliminacion = new EliminacionBE();
                Eliminacion.IdEliminacion = Int32.Parse(reader["idEliminacion"].ToString());
                Eliminacion.DescEliminacion = reader["descEliminacion"].ToString();
                Eliminacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Eliminacion;
        }

        public List<EliminacionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EliminacionBE> Eliminacionlist = new List<EliminacionBE>();
            EliminacionBE Eliminacion;
            while (reader.Read())
            {
                Eliminacion = new EliminacionBE();
                Eliminacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Eliminacion.IdEliminacion = Int32.Parse(reader["idEliminacion"].ToString());
                Eliminacion.DescEliminacion = reader["descEliminacion"].ToString();
                Eliminacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Eliminacionlist.Add(Eliminacion);
            }
            reader.Close();
            reader.Dispose();
            return Eliminacionlist;
        }

        public List<EliminacionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Eliminacion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EliminacionBE> Eliminacionlist = new List<EliminacionBE>();
            EliminacionBE Eliminacion;
            while (reader.Read())
            {
                Eliminacion = new EliminacionBE();
                Eliminacion.IdEliminacion = Int32.Parse(reader["idEliminacion"].ToString());
                Eliminacion.DescEliminacion = reader["descEliminacion"].ToString();
                Eliminacionlist.Add(Eliminacion);
            }
            reader.Close();
            reader.Dispose();
            return Eliminacionlist;
        }
    }
}
