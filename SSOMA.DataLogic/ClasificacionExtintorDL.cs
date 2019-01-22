using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ClasificacionExtintorDL
    {
        public ClasificacionExtintorDL() { }

        public void Inserta(ClasificacionExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_Inserta");

            db.AddInParameter(dbCommand, "pIdClasificacionExtintor", DbType.Int32, pItem.IdClasificacionExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescClasificacionExtintor", DbType.String, pItem.DescClasificacionExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ClasificacionExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_Actualiza");

            db.AddInParameter(dbCommand, "pIdClasificacionExtintor", DbType.Int32, pItem.IdClasificacionExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescClasificacionExtintor", DbType.String, pItem.DescClasificacionExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ClasificacionExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_Elimina");

            db.AddInParameter(dbCommand, "pIdClasificacionExtintor", DbType.Int32, pItem.IdClasificacionExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ClasificacionExtintorBE Selecciona(int idClasificacionExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_Selecciona");
            db.AddInParameter(dbCommand, "pidClasificacionExtintor", DbType.Int32, idClasificacionExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClasificacionExtintorBE ClasificacionExtintor = null;
            while (reader.Read())
            {
                ClasificacionExtintor = new ClasificacionExtintorBE();
                ClasificacionExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClasificacionExtintor.IdClasificacionExtintor = Int32.Parse(reader["idClasificacionExtintor"].ToString());
                ClasificacionExtintor.Abreviatura = reader["Abreviatura"].ToString();
                ClasificacionExtintor.DescClasificacionExtintor = reader["descClasificacionExtintor"].ToString();
                ClasificacionExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClasificacionExtintor;
        }

        public List<ClasificacionExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClasificacionExtintorBE> ClasificacionExtintorlist = new List<ClasificacionExtintorBE>();
            ClasificacionExtintorBE ClasificacionExtintor;
            while (reader.Read())
            {
                ClasificacionExtintor = new ClasificacionExtintorBE();
                ClasificacionExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClasificacionExtintor.IdClasificacionExtintor = Int32.Parse(reader["idClasificacionExtintor"].ToString());
                ClasificacionExtintor.Abreviatura = reader["Abreviatura"].ToString();
                ClasificacionExtintor.DescClasificacionExtintor = reader["descClasificacionExtintor"].ToString();
                ClasificacionExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClasificacionExtintorlist.Add(ClasificacionExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ClasificacionExtintorlist;
        }

        public List<ClasificacionExtintorBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClasificacionExtintor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClasificacionExtintorBE> ClasificacionExtintorlist = new List<ClasificacionExtintorBE>();
            ClasificacionExtintorBE ClasificacionExtintor;
            while (reader.Read())
            {
                ClasificacionExtintor = new ClasificacionExtintorBE();
                ClasificacionExtintor.IdClasificacionExtintor = Int32.Parse(reader["idClasificacionExtintor"].ToString());
                ClasificacionExtintor.Abreviatura = reader["Abreviatura"].ToString();
                ClasificacionExtintorlist.Add(ClasificacionExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ClasificacionExtintorlist;
        }
    }
}
