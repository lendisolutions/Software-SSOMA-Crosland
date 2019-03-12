using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class RespuestaPersonaDL
    {
        public RespuestaPersonaDL() { }

        public void Inserta(RespuestaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RespuestaPersona_Inserta");

            db.AddInParameter(dbCommand, "pIdRespuestaPersona", DbType.Int32, pItem.IdRespuestaPersona);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, pItem.IdRespuesta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagRespuesta", DbType.Boolean, pItem.FlagRespuesta);
            db.AddInParameter(dbCommand, "pDescSituacion", DbType.String, pItem.DescSituacion);
            db.AddInParameter(dbCommand, "pPuntaje", DbType.Int32, pItem.Puntaje);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(RespuestaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RespuestaPersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdRespuestaPersona", DbType.Int32, pItem.IdRespuestaPersona);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, pItem.IdRespuesta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagRespuesta", DbType.Boolean, pItem.FlagRespuesta);
            db.AddInParameter(dbCommand, "pDescSituacion", DbType.String, pItem.DescSituacion);
            db.AddInParameter(dbCommand, "pPuntaje", DbType.Int32, pItem.Puntaje);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(RespuestaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RespuestaPersona_Elimina");

            db.AddInParameter(dbCommand, "pIdRespuestaPersona", DbType.Int32, pItem.IdRespuestaPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public RespuestaPersonaBE Selecciona(int IdRespuestaPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RespuestaPersona_Selecciona");
            db.AddInParameter(dbCommand, "pidRespuestaPersona", DbType.Int32, IdRespuestaPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RespuestaPersonaBE RespuestaPersona = null;
            while (reader.Read())
            {
                RespuestaPersona = new RespuestaPersonaBE();
                RespuestaPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                RespuestaPersona.IdRespuestaPersona = Int32.Parse(reader["idRespuestaPersona"].ToString());
                RespuestaPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                RespuestaPersona.DescTema = reader["DescTema"].ToString();
                RespuestaPersona.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                RespuestaPersona.DescCuestionario = reader["DescCuestionario"].ToString();
                RespuestaPersona.IdPregunta = Int32.Parse(reader["IdPregunta"].ToString());
                RespuestaPersona.DescPregunta = reader["DescPregunta"].ToString();
                RespuestaPersona.IdRespuesta = Int32.Parse(reader["IdRespuesta"].ToString());
                RespuestaPersona.DescRespuesta = reader["DescRespuesta"].ToString();
                RespuestaPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                RespuestaPersona.ApeNom = reader["ApeNom"].ToString();
                RespuestaPersona.FlagRespuesta = Boolean.Parse(reader["FlagRespuesta"].ToString());
                RespuestaPersona.DescSituacion = reader["DescSituacion"].ToString();
                RespuestaPersona.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                RespuestaPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return RespuestaPersona;
        }

        public List<RespuestaPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdCuestionario, int IdPregunta, int IdRespuesta, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RespuestaPersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, IdPregunta);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, IdCuestionario);
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, IdPregunta);
            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, IdRespuesta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RespuestaPersonaBE> RespuestaPersonalist = new List<RespuestaPersonaBE>();
            RespuestaPersonaBE RespuestaPersona;
            while (reader.Read())
            {
                RespuestaPersona = new RespuestaPersonaBE();
                RespuestaPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                RespuestaPersona.IdRespuestaPersona = Int32.Parse(reader["idRespuestaPersona"].ToString());
                RespuestaPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                RespuestaPersona.DescTema = reader["DescTema"].ToString();
                RespuestaPersona.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                RespuestaPersona.DescCuestionario = reader["DescCuestionario"].ToString();
                RespuestaPersona.IdPregunta = Int32.Parse(reader["IdPregunta"].ToString());
                RespuestaPersona.DescPregunta = reader["DescPregunta"].ToString();
                RespuestaPersona.IdRespuesta = Int32.Parse(reader["IdRespuesta"].ToString());
                RespuestaPersona.DescRespuesta = reader["DescRespuesta"].ToString();
                RespuestaPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                RespuestaPersona.ApeNom = reader["ApeNom"].ToString();
                RespuestaPersona.FlagRespuesta = Boolean.Parse(reader["FlagRespuesta"].ToString());
                RespuestaPersona.DescSituacion = reader["DescSituacion"].ToString();
                RespuestaPersona.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                RespuestaPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                RespuestaPersonalist.Add(RespuestaPersona);
            }
            reader.Close();
            reader.Dispose();
            return RespuestaPersonalist;
        }
    }
}
