using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PlanAnualDL
    {
        public PlanAnualDL() { }

        public Int32 Inserta(PlanAnualBE pItem)
        {
            Int32 intIdPlanAnual = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_Inserta");

            db.AddOutParameter(dbCommand, "pIdPlanAnual", DbType.Int32, pItem.IdPlanAnual);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdClaseCapacitacion", DbType.Int32, pItem.IdClaseCapacitacion);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdResponsableCapacitacion", DbType.Int32, pItem.IdResponsableCapacitacion);
            db.AddInParameter(dbCommand, "pDuracion", DbType.Int32, pItem.Duracion);
            db.AddInParameter(dbCommand, "pFechaCumplimiento", DbType.DateTime, pItem.FechaCumplimiento);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdPlanAnual = (int)db.GetParameterValue(dbCommand, "pIdPlanAnual");

            return intIdPlanAnual;
        }

        public void Actualiza(PlanAnualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, pItem.IdPlanAnual);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdClaseCapacitacion", DbType.Int32, pItem.IdClaseCapacitacion);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdLugar", DbType.Int32, pItem.IdLugar);
            db.AddInParameter(dbCommand, "pIdResponsableCapacitacion", DbType.Int32, pItem.IdResponsableCapacitacion);
            db.AddInParameter(dbCommand, "pDuracion", DbType.Int32, pItem.Duracion);
            db.AddInParameter(dbCommand, "pFechaCumplimiento", DbType.DateTime, pItem.FechaCumplimiento);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PlanAnualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_Elimina");

            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, pItem.IdPlanAnual);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public PlanAnualBE Selecciona(int IdPlanAnual)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_Selecciona");
            db.AddInParameter(dbCommand, "pIdPlanAnual", DbType.Int32, IdPlanAnual);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PlanAnualBE PlanAnual = null;
            while (reader.Read())
            {
                PlanAnual = new PlanAnualBE();
                PlanAnual.IdPlanAnual = Int32.Parse(reader["idPlanAnual"].ToString());
                PlanAnual.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                PlanAnual.RazonSocial = reader["RazonSocial"].ToString();
                PlanAnual.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                PlanAnual.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                PlanAnual.IdTema = Int32.Parse(reader["IdTema"].ToString());
                PlanAnual.DescTema = reader["DescTema"].ToString();
                PlanAnual.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                PlanAnual.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                PlanAnual.IdClaseCapacitacion = Int32.Parse(reader["IdClaseCapacitacion"].ToString());
                PlanAnual.DescClaseCapacitacion = reader["DescClaseCapacitacion"].ToString();
                PlanAnual.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PlanAnual.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                PlanAnual.DescLugar = reader["DescLugar"].ToString();
                PlanAnual.IdResponsableCapacitacion = Int32.Parse(reader["IdResponsableCapacitacion"].ToString());
                PlanAnual.DescResponsableCapacitacion = reader["DescResponsableCapacitacion"].ToString();
                PlanAnual.Duracion = Int32.Parse(reader["Duracion"].ToString());
                PlanAnual.FechaCumplimiento = reader.IsDBNull(reader.GetOrdinal("FechaCumplimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCumplimiento"));
                PlanAnual.Costo = Decimal.Parse(reader["Costo"].ToString());
                PlanAnual.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PlanAnual.DescSituacion = reader["DescSituacion"].ToString();
                PlanAnual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return PlanAnual;
        }

        public List<PlanAnualBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanAnualBE> PlanAnuallist = new List<PlanAnualBE>();
            PlanAnualBE PlanAnual;
            while (reader.Read())
            {
                PlanAnual = new PlanAnualBE();
                PlanAnual.IdPlanAnual = Int32.Parse(reader["idPlanAnual"].ToString());
                PlanAnual.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                PlanAnual.RazonSocial = reader["RazonSocial"].ToString();
                PlanAnual.Logo = (byte[])reader["Logo"];
                PlanAnual.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                PlanAnual.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                PlanAnual.IdTema = Int32.Parse(reader["IdTema"].ToString());
                PlanAnual.DescTema = reader["DescTema"].ToString();
                PlanAnual.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                PlanAnual.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                PlanAnual.IdClaseCapacitacion = Int32.Parse(reader["IdClaseCapacitacion"].ToString());
                PlanAnual.DescClaseCapacitacion = reader["DescClaseCapacitacion"].ToString();
                PlanAnual.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PlanAnual.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                PlanAnual.DescLugar = reader["DescLugar"].ToString();
                PlanAnual.IdResponsableCapacitacion = Int32.Parse(reader["IdResponsableCapacitacion"].ToString());
                PlanAnual.DescResponsableCapacitacion = reader["DescResponsableCapacitacion"].ToString();
                PlanAnual.Duracion = Int32.Parse(reader["Duracion"].ToString());
                PlanAnual.FechaCumplimiento = reader.IsDBNull(reader.GetOrdinal("FechaCumplimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCumplimiento"));
                PlanAnual.Costo = Decimal.Parse(reader["Costo"].ToString());
                PlanAnual.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PlanAnual.DescSituacion = reader["DescSituacion"].ToString();
                PlanAnual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PlanAnuallist.Add(PlanAnual);
            }
            reader.Close();
            reader.Dispose();
            return PlanAnuallist;
        }

        public List<PlanAnualBE> ListaPeriodo(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_ListaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanAnualBE> PlanAnuallist = new List<PlanAnualBE>();
            PlanAnualBE PlanAnual;
            while (reader.Read())
            {
                PlanAnual = new PlanAnualBE();
                PlanAnual.IdPlanAnual = Int32.Parse(reader["idPlanAnual"].ToString());
                PlanAnual.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                PlanAnual.RazonSocial = reader["RazonSocial"].ToString();
                PlanAnual.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                PlanAnual.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                PlanAnual.IdTema = Int32.Parse(reader["IdTema"].ToString());
                PlanAnual.DescTema = reader["DescTema"].ToString();
                PlanAnual.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                PlanAnual.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                PlanAnual.IdClaseCapacitacion = Int32.Parse(reader["IdClaseCapacitacion"].ToString());
                PlanAnual.DescClaseCapacitacion = reader["DescClaseCapacitacion"].ToString();
                PlanAnual.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PlanAnual.IdLugar = Int32.Parse(reader["IdLugar"].ToString());
                PlanAnual.DescLugar = reader["DescLugar"].ToString();
                PlanAnual.IdResponsableCapacitacion = Int32.Parse(reader["IdResponsableCapacitacion"].ToString());
                PlanAnual.DescResponsableCapacitacion = reader["DescResponsableCapacitacion"].ToString();
                PlanAnual.Duracion = Int32.Parse(reader["Duracion"].ToString());
                PlanAnual.FechaCumplimiento = reader.IsDBNull(reader.GetOrdinal("FechaCumplimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCumplimiento"));
                PlanAnual.Costo = Decimal.Parse(reader["Costo"].ToString());
                PlanAnual.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PlanAnual.DescSituacion = reader["DescSituacion"].ToString();
                PlanAnual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PlanAnuallist.Add(PlanAnual);
            }
            reader.Close();
            reader.Dispose();
            return PlanAnuallist;
        }

        public List<PlanAnualBE> ListaTema(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanAnual_ListaTema");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanAnualBE> PlanAnuallist = new List<PlanAnualBE>();
            PlanAnualBE PlanAnual;
            while (reader.Read())
            {
                PlanAnual = new PlanAnualBE();
                PlanAnual.IdTema = Int32.Parse(reader["IdTema"].ToString());
                PlanAnual.DescTema = reader["DescTema"].ToString();
                PlanAnuallist.Add(PlanAnual);
            }
            reader.Close();
            reader.Dispose();
            return PlanAnuallist;
        }
    }
}
