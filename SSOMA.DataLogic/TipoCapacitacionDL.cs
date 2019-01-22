using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TipoCapacitacionDL
    {
        public TipoCapacitacionDL() { }

        public void Inserta(TipoCapacitacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoCapacitacion", DbType.String, pItem.DescTipoCapacitacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TipoCapacitacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTipoCapacitacion", DbType.String, pItem.DescTipoCapacitacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TipoCapacitacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TipoCapacitacionBE Selecciona(int IdEmpresa, int idTipoCapacitacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidTipoCapacitacion", DbType.Int32, idTipoCapacitacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoCapacitacionBE TipoCapacitacion = null;
            while (reader.Read())
            {
                TipoCapacitacion = new TipoCapacitacionBE();
                TipoCapacitacion.IdTipoCapacitacion = Int32.Parse(reader["idTipoCapacitacion"].ToString());
                TipoCapacitacion.DescTipoCapacitacion = reader["descTipoCapacitacion"].ToString();
                TipoCapacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoCapacitacion;
        }

        
        public List<TipoCapacitacionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoCapacitacionBE> TipoCapacitacionlist = new List<TipoCapacitacionBE>();
            TipoCapacitacionBE TipoCapacitacion;
            while (reader.Read())
            {
                TipoCapacitacion = new TipoCapacitacionBE();
                TipoCapacitacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TipoCapacitacion.IdTipoCapacitacion = Int32.Parse(reader["idTipoCapacitacion"].ToString());
                TipoCapacitacion.DescTipoCapacitacion = reader["descTipoCapacitacion"].ToString();
                TipoCapacitacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoCapacitacionlist.Add(TipoCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return TipoCapacitacionlist;
        }

        public List<TipoCapacitacionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCapacitacion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
          
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoCapacitacionBE> TipoCapacitacionlist = new List<TipoCapacitacionBE>();
            TipoCapacitacionBE TipoCapacitacion;
            while (reader.Read())
            {
                TipoCapacitacion = new TipoCapacitacionBE();
                TipoCapacitacion.IdTipoCapacitacion = Int32.Parse(reader["idTipoCapacitacion"].ToString());
                TipoCapacitacion.DescTipoCapacitacion = reader["descTipoCapacitacion"].ToString();
                TipoCapacitacionlist.Add(TipoCapacitacion);
            }
            reader.Close();
            reader.Dispose();
            return TipoCapacitacionlist;
        }
    }
}
