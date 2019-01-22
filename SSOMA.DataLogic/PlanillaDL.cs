using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PlanillaDL
    {
        public PlanillaDL() { }

        public void Inserta(PlanillaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Inserta");

            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, pItem.IdActividad);
            db.AddInParameter(dbCommand, "pFlagRutinaria", DbType.Boolean, pItem.FlagRutinaria);
            db.AddInParameter(dbCommand, "pFlagNoRutinaria", DbType.Boolean, pItem.FlagNoRutinaria);
            db.AddInParameter(dbCommand, "pFlagEmergencia", DbType.Boolean, pItem.FlagEmergencia);
            db.AddInParameter(dbCommand, "pFlagPropio", DbType.Boolean, pItem.FlagPropio);
            db.AddInParameter(dbCommand, "pFlagTercero", DbType.Boolean, pItem.FlagTercero);
            db.AddInParameter(dbCommand, "pIdPeligro", DbType.Int32, pItem.IdPeligro);
            db.AddInParameter(dbCommand, "pDetallePeligro", DbType.String, pItem.DetallePeligro);
            db.AddInParameter(dbCommand, "pTipoPeligro", DbType.String, pItem.TipoPeligro);
            db.AddInParameter(dbCommand, "pDescRiesgo", DbType.String, pItem.DescRiesgo);
            db.AddInParameter(dbCommand, "pIndicePersona", DbType.Int32, pItem.IndicePersona);
            db.AddInParameter(dbCommand, "pIndiceProcedimiento", DbType.Int32, pItem.IndiceProcedimiento);
            db.AddInParameter(dbCommand, "pIndiceCapacitacion", DbType.Int32, pItem.IndiceCapacitacion);
            db.AddInParameter(dbCommand, "pIndiceFrecuencia", DbType.Int32, pItem.IndiceFrecuencia);
            db.AddInParameter(dbCommand, "pSeveridad", DbType.Int32, pItem.Severidad);
            db.AddInParameter(dbCommand, "pValoracionRiesgo", DbType.Int32, pItem.ValoracionRiesgo);
            db.AddInParameter(dbCommand, "pCalificacionRiesgo", DbType.String, pItem.CalificacionRiesgo);
            db.AddInParameter(dbCommand, "pSignificativo", DbType.String, pItem.Significativo);
            db.AddInParameter(dbCommand, "pEliminacion", DbType.String, pItem.Eliminacion);
            db.AddInParameter(dbCommand, "pSituacion", DbType.String, pItem.Situacion);
            db.AddInParameter(dbCommand, "pTratamiento", DbType.String, pItem.Tratamiento);
            db.AddInParameter(dbCommand, "pControlAdministrativo", DbType.String, pItem.ControlAdministrativo);
            db.AddInParameter(dbCommand, "pEquipoProteccion", DbType.String, pItem.EquipoProteccion);
            db.AddInParameter(dbCommand, "pResponsable", DbType.String, pItem.Responsable);
            db.AddInParameter(dbCommand, "pIndicePersonaRR", DbType.Int32, pItem.IndicePersonaRR);
            db.AddInParameter(dbCommand, "pIndiceProcedimientoRR", DbType.Int32, pItem.IndiceProcedimientoRR);
            db.AddInParameter(dbCommand, "pIndiceCapacitacionRR", DbType.Int32, pItem.IndiceCapacitacionRR);
            db.AddInParameter(dbCommand, "pIndiceFrecuenciaRR", DbType.Int32, pItem.IndiceFrecuenciaRR);
            db.AddInParameter(dbCommand, "pSeveridadRR", DbType.Int32, pItem.SeveridadRR);
            db.AddInParameter(dbCommand, "pValoracionRiesgoRR", DbType.Int32, pItem.ValoracionRiesgoRR);
            db.AddInParameter(dbCommand, "pCalificacionRiesgoRR", DbType.String, pItem.CalificacionRiesgoRR);
            db.AddInParameter(dbCommand, "pSignificativoRR", DbType.String, pItem.SignificativoRR);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PlanillaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, pItem.IdActividad);
            db.AddInParameter(dbCommand, "pFlagRutinaria", DbType.Boolean, pItem.FlagRutinaria);
            db.AddInParameter(dbCommand, "pFlagNoRutinaria", DbType.Boolean, pItem.FlagNoRutinaria);
            db.AddInParameter(dbCommand, "pFlagEmergencia", DbType.Boolean, pItem.FlagEmergencia);
            db.AddInParameter(dbCommand, "pFlagPropio", DbType.Boolean, pItem.FlagPropio);
            db.AddInParameter(dbCommand, "pFlagTercero", DbType.Boolean, pItem.FlagTercero);
            db.AddInParameter(dbCommand, "pIdPeligro", DbType.Int32, pItem.IdPeligro);
            db.AddInParameter(dbCommand, "pDetallePeligro", DbType.String, pItem.DetallePeligro);
            db.AddInParameter(dbCommand, "pTipoPeligro", DbType.String, pItem.TipoPeligro);
            db.AddInParameter(dbCommand, "pDescRiesgo", DbType.String, pItem.DescRiesgo);
            db.AddInParameter(dbCommand, "pIndicePersona", DbType.Int32, pItem.IndicePersona);
            db.AddInParameter(dbCommand, "pIndiceProcedimiento", DbType.Int32, pItem.IndiceProcedimiento);
            db.AddInParameter(dbCommand, "pIndiceCapacitacion", DbType.Int32, pItem.IndiceCapacitacion);
            db.AddInParameter(dbCommand, "pIndiceFrecuencia", DbType.Int32, pItem.IndiceFrecuencia);
            db.AddInParameter(dbCommand, "pSeveridad", DbType.Int32, pItem.Severidad);
            db.AddInParameter(dbCommand, "pValoracionRiesgo", DbType.Int32, pItem.ValoracionRiesgo);
            db.AddInParameter(dbCommand, "pCalificacionRiesgo", DbType.String, pItem.CalificacionRiesgo);
            db.AddInParameter(dbCommand, "pSignificativo", DbType.String, pItem.Significativo);
            db.AddInParameter(dbCommand, "pEliminacion", DbType.String, pItem.Eliminacion);
            db.AddInParameter(dbCommand, "pSituacion", DbType.String, pItem.Situacion);
            db.AddInParameter(dbCommand, "pTratamiento", DbType.String, pItem.Tratamiento);
            db.AddInParameter(dbCommand, "pControlAdministrativo", DbType.String, pItem.ControlAdministrativo);
            db.AddInParameter(dbCommand, "pEquipoProteccion", DbType.String, pItem.EquipoProteccion);
            db.AddInParameter(dbCommand, "pResponsable", DbType.String, pItem.Responsable);
            db.AddInParameter(dbCommand, "pIndicePersonaRR", DbType.Int32, pItem.IndicePersonaRR);
            db.AddInParameter(dbCommand, "pIndiceProcedimientoRR", DbType.Int32, pItem.IndiceProcedimientoRR);
            db.AddInParameter(dbCommand, "pIndiceCapacitacionRR", DbType.Int32, pItem.IndiceCapacitacionRR);
            db.AddInParameter(dbCommand, "pIndiceFrecuenciaRR", DbType.Int32, pItem.IndiceFrecuenciaRR);
            db.AddInParameter(dbCommand, "pSeveridadRR", DbType.Int32, pItem.SeveridadRR);
            db.AddInParameter(dbCommand, "pValoracionRiesgoRR", DbType.Int32, pItem.ValoracionRiesgoRR);
            db.AddInParameter(dbCommand, "pCalificacionRiesgoRR", DbType.String, pItem.CalificacionRiesgoRR);
            db.AddInParameter(dbCommand, "pSignificativoRR", DbType.String, pItem.SignificativoRR);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PlanillaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Elimina");

            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PlanillaBE Selecciona(int IdPlanilla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Selecciona");
            db.AddInParameter(dbCommand, "pidPlanilla", DbType.Int32, IdPlanilla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PlanillaBE Planilla = null;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Planilla.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Planilla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Planilla.DescArea = reader["DescArea"].ToString();
                Planilla.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Planilla.DescSector = reader["DescSector"].ToString();
                Planilla.IdActividad = Int32.Parse(reader["IdActividad"].ToString());
                Planilla.DescActividad = reader["DescActividad"].ToString();
                Planilla.FlagRutinaria = Boolean.Parse(reader["FlagRutinaria"].ToString());
                Planilla.FlagNoRutinaria = Boolean.Parse(reader["FlagNoRutinaria"].ToString());
                Planilla.FlagEmergencia = Boolean.Parse(reader["FlagEmergencia"].ToString());
                Planilla.FlagPropio = Boolean.Parse(reader["FlagPropio"].ToString());
                Planilla.FlagTercero = Boolean.Parse(reader["FlagTercero"].ToString());
                Planilla.IdPeligro = Int32.Parse(reader["IdPeligro"].ToString());
                Planilla.DescPeligro = reader["DescPeligro"].ToString();
                Planilla.DetallePeligro = reader["DetallePeligro"].ToString();
                Planilla.TipoPeligro = reader["TipoPeligro"].ToString();
                Planilla.DescRiesgo = reader["DescRiesgo"].ToString();
                Planilla.IndicePersona = Int32.Parse(reader["IndicePersona"].ToString());
                Planilla.IndiceProcedimiento = Int32.Parse(reader["IndiceProcedimiento"].ToString());
                Planilla.IndiceCapacitacion = Int32.Parse(reader["IndiceCapacitacion"].ToString());
                Planilla.IndiceFrecuencia = Int32.Parse(reader["IndiceFrecuencia"].ToString());
                Planilla.Severidad = Int32.Parse(reader["Severidad"].ToString());
                Planilla.ValoracionRiesgo = Int32.Parse(reader["ValoracionRiesgo"].ToString());
                Planilla.CalificacionRiesgo = reader["CalificacionRiesgo"].ToString();
                Planilla.Significativo = reader["Significativo"].ToString();
                Planilla.Eliminacion = reader["Eliminacion"].ToString();
                Planilla.Situacion = reader["Situacion"].ToString();
                Planilla.Tratamiento = reader["Tratamiento"].ToString();
                Planilla.ControlAdministrativo = reader["ControlAdministrativo"].ToString();
                Planilla.EquipoProteccion = reader["EquipoProteccion"].ToString();
                Planilla.Responsable = reader["Responsable"].ToString();
                Planilla.IndicePersonaRR = Int32.Parse(reader["IndicePersonaRR"].ToString());
                Planilla.IndiceProcedimientoRR = Int32.Parse(reader["IndiceProcedimientoRR"].ToString());
                Planilla.IndiceCapacitacionRR = Int32.Parse(reader["IndiceCapacitacionRR"].ToString());
                Planilla.IndiceFrecuenciaRR = Int32.Parse(reader["IndiceFrecuenciaRR"].ToString());
                Planilla.SeveridadRR = Int32.Parse(reader["SeveridadRR"].ToString());
                Planilla.ValoracionRiesgoRR = Int32.Parse(reader["ValoracionRiesgoRR"].ToString());
                Planilla.CalificacionRiesgoRR = reader["CalificacionRiesgoRR"].ToString();
                Planilla.SignificativoRR = reader["SignificativoRR"].ToString();
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Planilla;
        }

        public List<PlanillaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, int IdActividad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, IdActividad);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaBE> Planillalist = new List<PlanillaBE>();
            PlanillaBE Planilla;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Planilla.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Planilla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Planilla.DescArea = reader["DescArea"].ToString();
                Planilla.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Planilla.DescSector = reader["DescSector"].ToString();
                Planilla.IdActividad = Int32.Parse(reader["IdActividad"].ToString());
                Planilla.DescActividad = reader["DescActividad"].ToString();
                Planilla.FlagRutinaria = Boolean.Parse(reader["FlagRutinaria"].ToString());
                Planilla.FlagNoRutinaria = Boolean.Parse(reader["FlagNoRutinaria"].ToString());
                Planilla.FlagEmergencia = Boolean.Parse(reader["FlagEmergencia"].ToString());
                Planilla.FlagPropio = Boolean.Parse(reader["FlagPropio"].ToString());
                Planilla.FlagTercero = Boolean.Parse(reader["FlagTercero"].ToString());
                Planilla.IdPeligro = Int32.Parse(reader["IdPeligro"].ToString());
                Planilla.DescPeligro = reader["DescPeligro"].ToString();
                Planilla.DetallePeligro = reader["DetallePeligro"].ToString();
                Planilla.TipoPeligro = reader["TipoPeligro"].ToString();
                Planilla.DescRiesgo = reader["DescRiesgo"].ToString();
                Planilla.IndicePersona = Int32.Parse(reader["IndicePersona"].ToString());
                Planilla.IndiceProcedimiento = Int32.Parse(reader["IndiceProcedimiento"].ToString());
                Planilla.IndiceCapacitacion = Int32.Parse(reader["IndiceCapacitacion"].ToString());
                Planilla.IndiceFrecuencia = Int32.Parse(reader["IndiceFrecuencia"].ToString());
                Planilla.Severidad = Int32.Parse(reader["Severidad"].ToString());
                Planilla.ValoracionRiesgo = Int32.Parse(reader["ValoracionRiesgo"].ToString());
                Planilla.CalificacionRiesgo = reader["CalificacionRiesgo"].ToString();
                Planilla.Significativo = reader["Significativo"].ToString();
                Planilla.Eliminacion = reader["Eliminacion"].ToString();
                Planilla.Situacion = reader["Situacion"].ToString();
                Planilla.Tratamiento = reader["Tratamiento"].ToString();
                Planilla.ControlAdministrativo = reader["ControlAdministrativo"].ToString();
                Planilla.EquipoProteccion = reader["EquipoProteccion"].ToString();
                Planilla.Responsable = reader["Responsable"].ToString();
                Planilla.IndicePersonaRR = Int32.Parse(reader["IndicePersonaRR"].ToString());
                Planilla.IndiceProcedimientoRR = Int32.Parse(reader["IndiceProcedimientoRR"].ToString());
                Planilla.IndiceCapacitacionRR = Int32.Parse(reader["IndiceCapacitacionRR"].ToString());
                Planilla.IndiceFrecuenciaRR = Int32.Parse(reader["IndiceFrecuenciaRR"].ToString());
                Planilla.SeveridadRR = Int32.Parse(reader["SeveridadRR"].ToString());
                Planilla.ValoracionRiesgoRR = Int32.Parse(reader["ValoracionRiesgoRR"].ToString());
                Planilla.CalificacionRiesgoRR = reader["CalificacionRiesgoRR"].ToString();
                Planilla.SignificativoRR = reader["SignificativoRR"].ToString();
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Planilla.TipoOper = 4;//CONSULTAR
                Planillalist.Add(Planilla);
            }
            reader.Close();
            reader.Dispose();
            return Planillalist;
        }

        public List<PlanillaBE> ListaActividad(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, string DescActividad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_ListaActividad");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            db.AddInParameter(dbCommand, "pDescActividad", DbType.String, DescActividad);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaBE> Planillalist = new List<PlanillaBE>();
            PlanillaBE Planilla;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Planilla.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Planilla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Planilla.DescArea = reader["DescArea"].ToString();
                Planilla.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Planilla.DescSector = reader["DescSector"].ToString();
                Planilla.IdActividad = Int32.Parse(reader["IdActividad"].ToString());
                Planilla.DescActividad = reader["DescActividad"].ToString();
                Planilla.FlagRutinaria = Boolean.Parse(reader["FlagRutinaria"].ToString());
                Planilla.FlagNoRutinaria = Boolean.Parse(reader["FlagNoRutinaria"].ToString());
                Planilla.FlagEmergencia = Boolean.Parse(reader["FlagEmergencia"].ToString());
                Planilla.FlagPropio = Boolean.Parse(reader["FlagPropio"].ToString());
                Planilla.FlagTercero = Boolean.Parse(reader["FlagTercero"].ToString());
                Planilla.IdPeligro = Int32.Parse(reader["IdPeligro"].ToString());
                Planilla.DescPeligro = reader["DescPeligro"].ToString();
                Planilla.DetallePeligro = reader["DetallePeligro"].ToString();
                Planilla.TipoPeligro = reader["TipoPeligro"].ToString();
                Planilla.DescRiesgo = reader["DescRiesgo"].ToString();
                Planilla.IndicePersona = Int32.Parse(reader["IndicePersona"].ToString());
                Planilla.IndiceProcedimiento = Int32.Parse(reader["IndiceProcedimiento"].ToString());
                Planilla.IndiceCapacitacion = Int32.Parse(reader["IndiceCapacitacion"].ToString());
                Planilla.IndiceFrecuencia = Int32.Parse(reader["IndiceFrecuencia"].ToString());
                Planilla.Severidad = Int32.Parse(reader["Severidad"].ToString());
                Planilla.ValoracionRiesgo = Int32.Parse(reader["ValoracionRiesgo"].ToString());
                Planilla.CalificacionRiesgo = reader["CalificacionRiesgo"].ToString();
                Planilla.Significativo = reader["Significativo"].ToString();
                Planilla.Eliminacion = reader["Eliminacion"].ToString();
                Planilla.Situacion = reader["Situacion"].ToString();
                Planilla.Tratamiento = reader["Tratamiento"].ToString();
                Planilla.ControlAdministrativo = reader["ControlAdministrativo"].ToString();
                Planilla.EquipoProteccion = reader["EquipoProteccion"].ToString();
                Planilla.Responsable = reader["Responsable"].ToString();
                Planilla.IndicePersonaRR = Int32.Parse(reader["IndicePersonaRR"].ToString());
                Planilla.IndiceProcedimientoRR = Int32.Parse(reader["IndiceProcedimientoRR"].ToString());
                Planilla.IndiceCapacitacionRR = Int32.Parse(reader["IndiceCapacitacionRR"].ToString());
                Planilla.IndiceFrecuenciaRR = Int32.Parse(reader["IndiceFrecuenciaRR"].ToString());
                Planilla.SeveridadRR = Int32.Parse(reader["SeveridadRR"].ToString());
                Planilla.ValoracionRiesgoRR = Int32.Parse(reader["ValoracionRiesgoRR"].ToString());
                Planilla.CalificacionRiesgoRR = reader["CalificacionRiesgoRR"].ToString();
                Planilla.SignificativoRR = reader["SignificativoRR"].ToString();
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Planillalist.Add(Planilla);
            }
            reader.Close();
            reader.Dispose();
            return Planillalist;
        }

        public List<PlanillaBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, int IdActividad, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, IdActividad);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaBE> Planillalist = new List<PlanillaBE>();
            PlanillaBE Planilla;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Planilla.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Planilla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Planilla.DescArea = reader["DescArea"].ToString();
                Planilla.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Planilla.DescSector = reader["DescSector"].ToString();
                Planilla.IdActividad = Int32.Parse(reader["IdActividad"].ToString());
                Planilla.DescActividad = reader["DescActividad"].ToString();
                Planilla.FlagRutinaria = Boolean.Parse(reader["FlagRutinaria"].ToString());
                Planilla.FlagNoRutinaria = Boolean.Parse(reader["FlagNoRutinaria"].ToString());
                Planilla.FlagEmergencia = Boolean.Parse(reader["FlagEmergencia"].ToString());
                Planilla.FlagPropio = Boolean.Parse(reader["FlagPropio"].ToString());
                Planilla.FlagTercero = Boolean.Parse(reader["FlagTercero"].ToString());
                Planilla.IdPeligro = Int32.Parse(reader["IdPeligro"].ToString());
                Planilla.DescPeligro = reader["DescPeligro"].ToString();
                Planilla.DetallePeligro = reader["DetallePeligro"].ToString();
                Planilla.TipoPeligro = reader["TipoPeligro"].ToString();
                Planilla.DescRiesgo = reader["DescRiesgo"].ToString();
                Planilla.IndicePersona = Int32.Parse(reader["IndicePersona"].ToString());
                Planilla.IndiceProcedimiento = Int32.Parse(reader["IndiceProcedimiento"].ToString());
                Planilla.IndiceCapacitacion = Int32.Parse(reader["IndiceCapacitacion"].ToString());
                Planilla.IndiceFrecuencia = Int32.Parse(reader["IndiceFrecuencia"].ToString());
                Planilla.Severidad = Int32.Parse(reader["Severidad"].ToString());
                Planilla.ValoracionRiesgo = Int32.Parse(reader["ValoracionRiesgo"].ToString());
                Planilla.CalificacionRiesgo = reader["CalificacionRiesgo"].ToString();
                Planilla.Significativo = reader["Significativo"].ToString();
                Planilla.Eliminacion = reader["Eliminacion"].ToString();
                Planilla.Situacion = reader["Situacion"].ToString();
                Planilla.Tratamiento = reader["Tratamiento"].ToString();
                Planilla.ControlAdministrativo = reader["ControlAdministrativo"].ToString();
                Planilla.EquipoProteccion = reader["EquipoProteccion"].ToString();
                Planilla.Responsable = reader["Responsable"].ToString();
                Planilla.IndicePersonaRR = Int32.Parse(reader["IndicePersonaRR"].ToString());
                Planilla.IndiceProcedimientoRR = Int32.Parse(reader["IndiceProcedimientoRR"].ToString());
                Planilla.IndiceCapacitacionRR = Int32.Parse(reader["IndiceCapacitacionRR"].ToString());
                Planilla.IndiceFrecuenciaRR = Int32.Parse(reader["IndiceFrecuenciaRR"].ToString());
                Planilla.SeveridadRR = Int32.Parse(reader["SeveridadRR"].ToString());
                Planilla.ValoracionRiesgoRR = Int32.Parse(reader["ValoracionRiesgoRR"].ToString());
                Planilla.CalificacionRiesgoRR = reader["CalificacionRiesgoRR"].ToString();
                Planilla.SignificativoRR = reader["SignificativoRR"].ToString();
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Planillalist.Add(Planilla);
            }
            reader.Close();
            reader.Dispose();
            return Planillalist;
        }
    }
}
