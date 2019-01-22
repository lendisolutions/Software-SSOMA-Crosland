using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ProbabilidadDL
    {
        public ProbabilidadDL() { }

        public void Inserta(ProbabilidadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Probabilidad_Inserta");

            db.AddInParameter(dbCommand, "pIdProbabilidad", DbType.Int32, pItem.IdProbabilidad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValorProbabilidad", DbType.Int32, pItem.ValorProbabilidad);
            db.AddInParameter(dbCommand, "pIndicePersona", DbType.String, pItem.IndicePersona);
            db.AddInParameter(dbCommand, "pIndiceProcedimiento", DbType.String, pItem.IndiceProcedimiento);
            db.AddInParameter(dbCommand, "pIndiceCapacitacion", DbType.String, pItem.IndiceCapacitacion);
            db.AddInParameter(dbCommand, "pIndiceFrecuencia", DbType.String, pItem.IndiceFrecuencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProbabilidadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Probabilidad_Actualiza");

            db.AddInParameter(dbCommand, "pIdProbabilidad", DbType.Int32, pItem.IdProbabilidad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValorProbabilidad", DbType.Int32, pItem.ValorProbabilidad);
            db.AddInParameter(dbCommand, "pIndicePersona", DbType.String, pItem.IndicePersona);
            db.AddInParameter(dbCommand, "pIndiceProcedimiento", DbType.String, pItem.IndiceProcedimiento);
            db.AddInParameter(dbCommand, "pIndiceCapacitacion", DbType.String, pItem.IndiceCapacitacion);
            db.AddInParameter(dbCommand, "pIndiceFrecuencia", DbType.String, pItem.IndiceFrecuencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProbabilidadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Probabilidad_Elimina");

            db.AddInParameter(dbCommand, "pIdProbabilidad", DbType.Int32, pItem.IdProbabilidad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProbabilidadBE Selecciona(int idProbabilidad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Probabilidad_Selecciona");
            db.AddInParameter(dbCommand, "pidProbabilidad", DbType.Int32, idProbabilidad);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProbabilidadBE Probabilidad = null;
            while (reader.Read())
            {
                Probabilidad = new ProbabilidadBE();
                Probabilidad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Probabilidad.IdProbabilidad = Int32.Parse(reader["idProbabilidad"].ToString());
                Probabilidad.ValorProbabilidad = Int32.Parse(reader["ValorProbabilidad"].ToString());
                Probabilidad.IndicePersona = reader["IndicePersona"].ToString();
                Probabilidad.IndiceProcedimiento = reader["IndiceProcedimiento"].ToString();
                Probabilidad.IndiceCapacitacion = reader["IndiceCapacitacion"].ToString();
                Probabilidad.IndiceFrecuencia = reader["IndiceFrecuencia"].ToString();
                Probabilidad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Probabilidad;
        }

        public List<ProbabilidadBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Probabilidad_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProbabilidadBE> Probabilidadlist = new List<ProbabilidadBE>();
            ProbabilidadBE Probabilidad;
            while (reader.Read())
            {
                Probabilidad = new ProbabilidadBE();
                Probabilidad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Probabilidad.IdProbabilidad = Int32.Parse(reader["idProbabilidad"].ToString());
                Probabilidad.ValorProbabilidad = Int32.Parse(reader["ValorProbabilidad"].ToString());
                Probabilidad.IndicePersona = reader["IndicePersona"].ToString();
                Probabilidad.IndiceProcedimiento = reader["IndiceProcedimiento"].ToString();
                Probabilidad.IndiceCapacitacion = reader["IndiceCapacitacion"].ToString();
                Probabilidad.IndiceFrecuencia = reader["IndiceFrecuencia"].ToString();
                Probabilidad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Probabilidadlist.Add(Probabilidad);
            }
            reader.Close();
            reader.Dispose();
            return Probabilidadlist;
        }

        
    }
}
