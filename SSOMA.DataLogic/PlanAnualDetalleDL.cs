using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PlanAnualDetalleDL
    {
        public PlanAnualDetalleDL() { }

        public void Inserta(PlanAnualDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnualDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPlanAnualDetalle", DbType.Int32, pItem.IdPlanAnualDetalle);
            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, pItem.IdPlanAnual);
            db.AddInParameter(dbCommand, "pDescMes", DbType.String, pItem.DescMes);
            db.AddInParameter(dbCommand, "pSemana", DbType.Int32, pItem.Semana);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PlanAnualDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnualDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlanAnualDetalle", DbType.Int32, pItem.IdPlanAnualDetalle);
            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, pItem.IdPlanAnual);
            db.AddInParameter(dbCommand, "pDescMes", DbType.String, pItem.DescMes);
            db.AddInParameter(dbCommand, "pSemana", DbType.Int32, pItem.Semana);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PlanAnualDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnualDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPlanAnualDetalle", DbType.Int32, pItem.IdPlanAnualDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PlanAnualDetalleBE Selecciona(int IdPlanAnualDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnualDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidPlanAnualDetalle", DbType.Int32, IdPlanAnualDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PlanAnualDetalleBE PlanAnualDetalle = null;
            while (reader.Read())
            {
                PlanAnualDetalle = new PlanAnualDetalleBE();
                PlanAnualDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PlanAnualDetalle.IdPlanAnual = Int32.Parse(reader["idPlanAnual"].ToString());
                PlanAnualDetalle.IdPlanAnualDetalle = Int32.Parse(reader["idPlanAnualDetalle"].ToString());
                PlanAnualDetalle.DescMes = reader["DescMes"].ToString();
                PlanAnualDetalle.Semana = Int32.Parse(reader["Semana"].ToString());
                PlanAnualDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PlanAnualDetalle;
        }

        public List<PlanAnualDetalleBE> ListaTodosActivo(int IdPlanAnual)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnualDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, IdPlanAnual);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanAnualDetalleBE> PlanAnualDetallelist = new List<PlanAnualDetalleBE>();
            PlanAnualDetalleBE PlanAnualDetalle;
            while (reader.Read())
            {
                PlanAnualDetalle = new PlanAnualDetalleBE();
                PlanAnualDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PlanAnualDetalle.IdPlanAnual = Int32.Parse(reader["idPlanAnual"].ToString());
                PlanAnualDetalle.IdPlanAnualDetalle = Int32.Parse(reader["idPlanAnualDetalle"].ToString());
                PlanAnualDetalle.DescMes = reader["DescMes"].ToString();
                PlanAnualDetalle.Semana = Int32.Parse(reader["Semana"].ToString());
                PlanAnualDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PlanAnualDetalle.TipoOper = 4; //CONSULTAR
                PlanAnualDetallelist.Add(PlanAnualDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PlanAnualDetallelist;
        }
    }
}
