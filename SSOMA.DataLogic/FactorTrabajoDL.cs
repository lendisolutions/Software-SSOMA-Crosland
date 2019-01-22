using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class FactorTrabajoDL
    {
        public FactorTrabajoDL() { }

        public void Inserta(FactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_Inserta");

            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, pItem.IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFactorTrabajo", DbType.String, pItem.DescFactorTrabajo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(FactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_Actualiza");

            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, pItem.IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFactorTrabajo", DbType.String, pItem.DescFactorTrabajo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(FactorTrabajoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_Elimina");

            db.AddInParameter(dbCommand, "pIdFactorTrabajo", DbType.Int32, pItem.IdFactorTrabajo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public FactorTrabajoBE Selecciona(int idFactorTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_Selecciona");
            db.AddInParameter(dbCommand, "pidFactorTrabajo", DbType.Int32, idFactorTrabajo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FactorTrabajoBE FactorTrabajo = null;
            while (reader.Read())
            {
                FactorTrabajo = new FactorTrabajoBE();
                FactorTrabajo.IdFactorTrabajo = Int32.Parse(reader["idFactorTrabajo"].ToString());
                FactorTrabajo.DescFactorTrabajo = reader["descFactorTrabajo"].ToString();
                FactorTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return FactorTrabajo;
        }

        public List<FactorTrabajoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FactorTrabajoBE> FactorTrabajolist = new List<FactorTrabajoBE>();
            FactorTrabajoBE FactorTrabajo;
            while (reader.Read())
            {
                FactorTrabajo = new FactorTrabajoBE();
                FactorTrabajo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FactorTrabajo.IdFactorTrabajo = Int32.Parse(reader["idFactorTrabajo"].ToString());
                FactorTrabajo.DescFactorTrabajo = reader["descFactorTrabajo"].ToString();
                FactorTrabajo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FactorTrabajolist.Add(FactorTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return FactorTrabajolist;
        }

        public List<FactorTrabajoBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FactorTrabajo_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FactorTrabajoBE> FactorTrabajolist = new List<FactorTrabajoBE>();
            FactorTrabajoBE FactorTrabajo;
            while (reader.Read())
            {
                FactorTrabajo = new FactorTrabajoBE();
                FactorTrabajo.IdFactorTrabajo = Int32.Parse(reader["idFactorTrabajo"].ToString());
                FactorTrabajo.DescFactorTrabajo = reader["descFactorTrabajo"].ToString();
                FactorTrabajolist.Add(FactorTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return FactorTrabajolist;
        }
    }
}
