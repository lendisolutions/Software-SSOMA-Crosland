using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ActividadContratistaDL
    {
        public ActividadContratistaDL() { }

        public Int32 Inserta(ActividadContratistaBE pItem)
        {
            Int32 intIdActividadContratista = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_Inserta");

            db.AddOutParameter(dbCommand, "pIdActividadContratista", DbType.Int32, pItem.IdActividadContratista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescActvidad", DbType.String, pItem.DescActvidad);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pResponsableContratista", DbType.String, pItem.ResponsableContratista);
            db.AddInParameter(dbCommand, "pEmailContratista", DbType.String, pItem.EmailContratista);
            db.AddInParameter(dbCommand, "pResponsableEmpresa", DbType.String, pItem.ResponsableEmpresa);
            db.AddInParameter(dbCommand, "pEmailEmpresa", DbType.String, pItem.EmailEmpresa);
            db.AddInParameter(dbCommand, "pFechaSctrIni", DbType.DateTime, pItem.FechaSctrIni);
            db.AddInParameter(dbCommand, "pFechaSctrFin", DbType.DateTime, pItem.FechaSctrFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdActividadContratista = (int)db.GetParameterValue(dbCommand, "pIdActividadContratista");

            return intIdActividadContratista;

        }

        public void Actualiza(ActividadContratistaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_Actualiza");

            db.AddInParameter(dbCommand, "pIdActividadContratista", DbType.Int32, pItem.IdActividadContratista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescActvidad", DbType.String, pItem.DescActvidad);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pResponsableContratista", DbType.String, pItem.ResponsableContratista);
            db.AddInParameter(dbCommand, "pEmailContratista", DbType.String, pItem.EmailContratista);
            db.AddInParameter(dbCommand, "pResponsableEmpresa", DbType.String, pItem.ResponsableEmpresa);
            db.AddInParameter(dbCommand, "pEmailEmpresa", DbType.String, pItem.EmailEmpresa);
            db.AddInParameter(dbCommand, "pFechaSctrIni", DbType.DateTime, pItem.FechaSctrIni);
            db.AddInParameter(dbCommand, "pFechaSctrFin", DbType.DateTime, pItem.FechaSctrFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ActividadContratistaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_Elimina");

            db.AddInParameter(dbCommand, "pIdActividadContratista", DbType.Int32, pItem.IdActividadContratista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ActividadContratistaBE Selecciona(int idActividadContratista)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_Selecciona");
            db.AddInParameter(dbCommand, "pidActividadContratista", DbType.Int32, idActividadContratista);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ActividadContratistaBE ActividadContratista = null;
            while (reader.Read())
            {
                ActividadContratista = new ActividadContratistaBE();
                ActividadContratista.IdActividadContratista = Int32.Parse(reader["idActividadContratista"].ToString());
                ActividadContratista.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActividadContratista.RazonSocial = reader["RazonSocial"].ToString();
                ActividadContratista.DescActvidad = reader["DescActvidad"].ToString();
                ActividadContratista.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                ActividadContratista.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                ActividadContratista.ResponsableContratista = reader["ResponsableContratista"].ToString();
                ActividadContratista.EmailContratista = reader["EmailContratista"].ToString();
                ActividadContratista.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                ActividadContratista.EmailEmpresa = reader["EmailEmpresa"].ToString();
                ActividadContratista.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                ActividadContratista.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                ActividadContratista.Observacion = reader["Observacion"].ToString();
                ActividadContratista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ActividadContratista;
        }

        public ActividadContratistaBE SeleccionaEmpresa(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_SeleccionaEmpresa");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ActividadContratistaBE ActividadContratista = null;
            while (reader.Read())
            {
                ActividadContratista = new ActividadContratistaBE();
                ActividadContratista.IdActividadContratista = Int32.Parse(reader["idActividadContratista"].ToString());
                ActividadContratista.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActividadContratista.RazonSocial = reader["RazonSocial"].ToString();
                ActividadContratista.DescActvidad = reader["DescActvidad"].ToString();
                ActividadContratista.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                ActividadContratista.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                ActividadContratista.ResponsableContratista = reader["ResponsableContratista"].ToString();
                ActividadContratista.EmailContratista = reader["EmailContratista"].ToString();
                ActividadContratista.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                ActividadContratista.EmailEmpresa = reader["EmailEmpresa"].ToString();
                ActividadContratista.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                ActividadContratista.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                ActividadContratista.Observacion = reader["Observacion"].ToString();
                ActividadContratista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ActividadContratista;
        }

        public List<ActividadContratistaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratista_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ActividadContratistaBE> ActividadContratistalist = new List<ActividadContratistaBE>();
            ActividadContratistaBE ActividadContratista;
            while (reader.Read())
            {
                ActividadContratista = new ActividadContratistaBE();
                ActividadContratista.IdActividadContratista = Int32.Parse(reader["idActividadContratista"].ToString());
                ActividadContratista.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActividadContratista.RazonSocial = reader["RazonSocial"].ToString();
                ActividadContratista.DescActvidad = reader["DescActvidad"].ToString();
                ActividadContratista.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                ActividadContratista.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                ActividadContratista.ResponsableContratista = reader["ResponsableContratista"].ToString();
                ActividadContratista.EmailContratista = reader["EmailContratista"].ToString();
                ActividadContratista.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                ActividadContratista.EmailEmpresa = reader["EmailEmpresa"].ToString();
                ActividadContratista.FechaSctrIni = DateTime.Parse(reader["FechaSctrIni"].ToString());
                ActividadContratista.FechaSctrFin = DateTime.Parse(reader["FechaSctrFin"].ToString());
                ActividadContratista.Observacion = reader["Observacion"].ToString();
                ActividadContratista.DescSituacion = reader["DescSituacion"].ToString();
                ActividadContratista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ActividadContratistalist.Add(ActividadContratista);
            }
            reader.Close();
            reader.Dispose();
            return ActividadContratistalist;
        }


    }

    
}
