using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteDL
    {
        public AccidenteDL() { }

        public Int32 Inserta(AccidenteBE pItem)
        {
            Int32 intIdAccidente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_Inserta");

            db.AddOutParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, pItem.IdTipo);
            db.AddInParameter(dbCommand, "pIdDanio", DbType.Int32, pItem.IdDanio);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, pItem.IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pIdJefeDirecto", DbType.Int32, pItem.IdJefeDirecto);
            db.AddInParameter(dbCommand, "pTiempoExperiencia", DbType.String, pItem.TiempoExperiencia);
            db.AddInParameter(dbCommand, "pTipoMaterial", DbType.String, pItem.TipoMaterial);
            db.AddInParameter(dbCommand, "pIdResponsableArea", DbType.Int32, pItem.IdResponsableArea);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHora", DbType.DateTime, pItem.Hora);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pHoraTrabajada", DbType.String, pItem.HoraTrabajada);
            db.AddInParameter(dbCommand, "pIdPotencialDanio", DbType.Int32, pItem.IdPotencialDanio);
            db.AddInParameter(dbCommand, "pIdGradoAccidente", DbType.Int32, pItem.IdGradoAccidente);
            db.AddInParameter(dbCommand, "pIdProbabilidadOcurrencia", DbType.Int32, pItem.IdProbabilidadOcurrencia);
            db.AddInParameter(dbCommand, "pPorque", DbType.String, pItem.Porque);
            db.AddInParameter(dbCommand, "pIdTrabajoOrdenadoPor", DbType.Int32, pItem.IdTrabajoOrdenadoPor);
            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, pItem.IdTipoAccidente);
            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, pItem.IdParteLesionada);
            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, pItem.IdTipoLesion);
            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, pItem.IdFuenteLesion);
            db.AddInParameter(dbCommand, "pDiasPerdido", DbType.Int32, pItem.DiasPerdido);
            db.AddInParameter(dbCommand, "pTrabajadoresAfectado", DbType.Int32, pItem.TrabajadoresAfectado);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pIdInvestigadoPor", DbType.Int32, pItem.IdInvestigadoPor);
            db.AddInParameter(dbCommand, "pIdRevisadoPor", DbType.Int32, pItem.IdRevisadoPor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdAccidente = (int)db.GetParameterValue(dbCommand, "pIdAccidente");

            return intIdAccidente;

        }

        public void Actualiza(AccidenteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, pItem.IdTipo);
            db.AddInParameter(dbCommand, "pIdDanio", DbType.Int32, pItem.IdDanio);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, pItem.IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, pItem.IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, pItem.IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdSectorResponsable", DbType.Int32, pItem.IdSectorResponsable);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, pItem.IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pIdJefeDirecto", DbType.Int32, pItem.IdJefeDirecto);
            db.AddInParameter(dbCommand, "pTiempoExperiencia", DbType.String, pItem.TiempoExperiencia);
            db.AddInParameter(dbCommand, "pTipoMaterial", DbType.String, pItem.TipoMaterial);
            db.AddInParameter(dbCommand, "pIdResponsableArea", DbType.Int32, pItem.IdResponsableArea);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHora", DbType.DateTime, pItem.Hora);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pHoraTrabajada", DbType.String, pItem.HoraTrabajada);
            db.AddInParameter(dbCommand, "pIdPotencialDanio", DbType.Int32, pItem.IdPotencialDanio);
            db.AddInParameter(dbCommand, "pIdGradoAccidente", DbType.Int32, pItem.IdGradoAccidente);
            db.AddInParameter(dbCommand, "pIdProbabilidadOcurrencia", DbType.Int32, pItem.IdProbabilidadOcurrencia);
            db.AddInParameter(dbCommand, "pPorque", DbType.String, pItem.Porque);
            db.AddInParameter(dbCommand, "pIdTrabajoOrdenadoPor", DbType.Int32, pItem.IdTrabajoOrdenadoPor);
            db.AddInParameter(dbCommand, "pIdTipoAccidente", DbType.Int32, pItem.IdTipoAccidente);
            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, pItem.IdParteLesionada);
            db.AddInParameter(dbCommand, "pIdTipoLesion", DbType.Int32, pItem.IdTipoLesion);
            db.AddInParameter(dbCommand, "pIdFuenteLesion", DbType.Int32, pItem.IdFuenteLesion);
            db.AddInParameter(dbCommand, "pDiasPerdido", DbType.Int32, pItem.DiasPerdido);
            db.AddInParameter(dbCommand, "pTrabajadoresAfectado", DbType.Int32, pItem.TrabajadoresAfectado);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pIdInvestigadoPor", DbType.Int32, pItem.IdInvestigadoPor);
            db.AddInParameter(dbCommand, "pIdRevisadoPor", DbType.Int32, pItem.IdRevisadoPor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdAccidente, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(AccidenteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteBE Selecciona(int idAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidente", DbType.Int32, idAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteBE Accidente = null;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Accidente;
        }

        public AccidenteBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteBE Accidente = null;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Accidente;
        }

        public List<AccidenteBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaFechaResponsable");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, IdResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaTipo(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaTipo");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaPotencialDanio(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPotencialDanio, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaPotencialDanio");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pIdAreaResponsable", DbType.Int32, IdAreaResponsable);
            db.AddInParameter(dbCommand, "pIdPotencialDanio", DbType.Int32, IdPotencialDanio);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaEmpresaContratista(int IdEmpresaContratista, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaEmpresaContratista");
            db.AddInParameter(dbCommand, "pIdEmpresaContratista", DbType.Int32, IdEmpresaContratista);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                Accidente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Accidente.IdTipo = Int32.Parse(reader["IdTipo"].ToString());
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.IdDanio = Int32.Parse(reader["IdDanio"].ToString());
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.IdEmpresaResponsable = Int32.Parse(reader["IdEmpresaResponsable"].ToString());
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.IdUnidadMineraResponsable = Int32.Parse(reader["IdUnidadMineraResponsable"].ToString());
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.IdAreaResponsable = Int32.Parse(reader["IdAreaResponsable"].ToString());
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.IdSectorResponsable = Int32.Parse(reader["IdSectorResponsable"].ToString());
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.IdJefeDirecto = reader.IsDBNull(reader.GetOrdinal("IdJefeDirecto")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdJefeDirecto"));
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.CorreoJefeDirecto = reader["CorreoJefeDirecto"].ToString();
                Accidente.IdEmpresaContratista = Int32.Parse(reader["IdEmpresaContratista"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.IdResponsableArea = reader.IsDBNull(reader.GetOrdinal("IdResponsableArea")) ? -1 : reader.GetInt32(reader.GetOrdinal("IdResponsableArea"));
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.CorreoResponsableArea = reader["CorreoResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.IdPotencialDanio = Int32.Parse(reader["IdPotencialDanio"].ToString());
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.IdGradoAccidente = Int32.Parse(reader["IdGradoAccidente"].ToString());
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.IdProbabilidadOcurrencia = Int32.Parse(reader["IdProbabilidadOcurrencia"].ToString());
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.IdTrabajoOrdenadoPor = Int32.Parse(reader["IdTrabajoOrdenadoPor"].ToString());
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.IdTipoAccidente = Int32.Parse(reader["IdTipoAccidente"].ToString());
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.IdParteLesionada = Int32.Parse(reader["IdParteLesionada"].ToString());
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.IdTipoLesion = Int32.Parse(reader["IdTipoLesion"].ToString());
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.IdFuenteLesion = Int32.Parse(reader["IdFuenteLesion"].ToString());
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.IdInvestigadoPor = Int32.Parse(reader["IdInvestigadoPor"].ToString());
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.CorreoInvestigadoPor = reader["CorreoInvestigadoPor"].ToString();
                Accidente.IdRevisadoPor = Int32.Parse(reader["IdRevisadoPor"].ToString());
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
                Accidente.CorreoRevisadoPor = reader["CorreoRevisadoPor"].ToString();
                Accidente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaSeguimiento(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaSeguimiento");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresaResponsable);
            db.AddInParameter(dbCommand, "pIdUnidadMineraResponsable", DbType.Int32, IdUnidadMineraResponsable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.Logo = (byte[])reader["Logo"];
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.DescAccionCorrectiva = reader["DescAccionCorrectiva"].ToString();
                Accidente.FechaCumplimiento = reader["FechaCumplimiento"].ToString();
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.DescSituacion = reader["DescSituacion"].ToString();
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public AccidenteBE SeleccionaReporte(int idAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccidente");
            db.AddInParameter(dbCommand, "pidAccidente", DbType.Int32, idAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteBE Accidente = null;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.RazonSocial = reader["RazonSocial"].ToString();
                Accidente.Logo = (byte[])reader["Logo"];
                Accidente.Ruc = reader["Ruc"].ToString();
                Accidente.Direccion = reader["Direccion"].ToString();
                Accidente.ActividadEconomica = reader["ActividadEconomica"].ToString();
                Accidente.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                Accidente.EmpresaContratista = reader["EmpresaContratista"].ToString();
                Accidente.DescTipo = reader["DescTipo"].ToString();
                Accidente.DescDanio = reader["DescDanio"].ToString();
                Accidente.Numero = reader["Numero"].ToString();
                Accidente.Responsable = reader["Responsable"].ToString();
                Accidente.Dni = reader["Dni"].ToString();
                Accidente.Edad = Int32.Parse(reader["Edad"].ToString());
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Accidente.Cargo = reader["Cargo"].ToString();
                Accidente.EmpresaResponsable = reader["EmpresaResponsable"].ToString();
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidente.AreaResponsable = reader["AreaResponsable"].ToString();
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidente.JefeDirecto = reader["JefeDirecto"].ToString();
                Accidente.TiempoExperiencia = reader["TiempoExperiencia"].ToString();
                Accidente.TipoMaterial = reader["TipoMaterial"].ToString();
                Accidente.ResponsableArea = reader["ResponsableArea"].ToString();
                Accidente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Accidente.Hora = DateTime.Parse(reader["Hora"].ToString());
                Accidente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Accidente.Lugar = reader["Lugar"].ToString();
                Accidente.HoraTrabajada = reader["HoraTrabajada"].ToString();
                Accidente.DescPotencialDanio = reader["DescPotencialDanio"].ToString();
                Accidente.DescGradoAccidente = reader["DescGradoAccidente"].ToString();
                Accidente.DescProbabilidadOcurrencia = reader["DescProbabilidadOcurrencia"].ToString();
                Accidente.Porque = reader["Porque"].ToString();
                Accidente.TrabajoOrdenadoPor = reader["TrabajoOrdenadoPor"].ToString();
                Accidente.DescTipoAccidente = reader["DescTipoAccidente"].ToString();
                Accidente.DescParteLesionada = reader["DescParteLesionada"].ToString();
                Accidente.DescTipoLesion = reader["DescTipoLesion"].ToString();
                Accidente.DescFuenteLesion = reader["DescFuenteLesion"].ToString();
                Accidente.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                Accidente.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Accidente.TrabajadoresAfectado = Int32.Parse(reader["TrabajadoresAfectado"].ToString());
                Accidente.Descripcion = reader["Descripcion"].ToString();
                Accidente.InvestigadoPor = reader["InvestigadoPor"].ToString();
                Accidente.RevisadoPor = reader["RevisadoPor"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Accidente;
        }

        public int SeleccionaTipoNumeroMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_SeleccionaTipoNumeroMensual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public int SeleccionaTipoNumeroAnual(int IdEmpresa, int IdTipo, int Periodo)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_SeleccionaTipoNumeroAnual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
           

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public int SeleccionaDiasPerdidosMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_SeleccionaDiasPerdidosMensual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public int SeleccionaDiasPerdidosAnual(int IdEmpresa, int IdTipo, int Periodo)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_SeleccionaDiasPerdidosAnual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            
            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<AccidenteBE> ListaUnidadMineraMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaUnidadMineraMensual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.UnidadMineraResponsable = reader["UnidadMineraResponsable"].ToString();
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

        public List<AccidenteBE> ListaSectorMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Accidente_ListaSectorMensual");
            db.AddInParameter(dbCommand, "pIdEmpresaResponsable", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipo", DbType.Int32, IdTipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteBE> Accidentelist = new List<AccidenteBE>();
            AccidenteBE Accidente;
            while (reader.Read())
            {
                Accidente = new AccidenteBE();
                Accidente.SectorResponsable = reader["SectorResponsable"].ToString();
                Accidentelist.Add(Accidente);
            }
            reader.Close();
            reader.Dispose();
            return Accidentelist;
        }

    }
}
