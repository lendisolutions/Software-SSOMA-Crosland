using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EquipoProteccionDL
    {
        public EquipoProteccionDL() { }

        public void Inserta(EquipoProteccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_Inserta");

            db.AddInParameter(dbCommand, "pIdEquipoProteccion", DbType.Int32, pItem.IdEquipoProteccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEquipoProteccion", DbType.String, pItem.DescEquipoProteccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(EquipoProteccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_Actualiza");

            db.AddInParameter(dbCommand, "pIdEquipoProteccion", DbType.Int32, pItem.IdEquipoProteccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescEquipoProteccion", DbType.String, pItem.DescEquipoProteccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(EquipoProteccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_Elimina");

            db.AddInParameter(dbCommand, "pIdEquipoProteccion", DbType.Int32, pItem.IdEquipoProteccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public EquipoProteccionBE Selecciona(int idEquipoProteccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_Selecciona");
            db.AddInParameter(dbCommand, "pidEquipoProteccion", DbType.Int32, idEquipoProteccion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EquipoProteccionBE EquipoProteccion = null;
            while (reader.Read())
            {
                EquipoProteccion = new EquipoProteccionBE();
                EquipoProteccion.IdEquipoProteccion = Int32.Parse(reader["idEquipoProteccion"].ToString());
                EquipoProteccion.DescEquipoProteccion = reader["descEquipoProteccion"].ToString();
                EquipoProteccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EquipoProteccion;
        }

        public List<EquipoProteccionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoProteccionBE> EquipoProteccionlist = new List<EquipoProteccionBE>();
            EquipoProteccionBE EquipoProteccion;
            while (reader.Read())
            {
                EquipoProteccion = new EquipoProteccionBE();
                EquipoProteccion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EquipoProteccion.IdEquipoProteccion = Int32.Parse(reader["idEquipoProteccion"].ToString());
                EquipoProteccion.DescEquipoProteccion = reader["descEquipoProteccion"].ToString();
                EquipoProteccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                EquipoProteccionlist.Add(EquipoProteccion);
            }
            reader.Close();
            reader.Dispose();
            return EquipoProteccionlist;
        }

        public List<EquipoProteccionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoProteccion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoProteccionBE> EquipoProteccionlist = new List<EquipoProteccionBE>();
            EquipoProteccionBE EquipoProteccion;
            while (reader.Read())
            {
                EquipoProteccion = new EquipoProteccionBE();
                EquipoProteccion.IdEquipoProteccion = Int32.Parse(reader["idEquipoProteccion"].ToString());
                EquipoProteccion.DescEquipoProteccion = reader["descEquipoProteccion"].ToString();
                EquipoProteccionlist.Add(EquipoProteccion);
            }
            reader.Close();
            reader.Dispose();
            return EquipoProteccionlist;
        }
    }
}
