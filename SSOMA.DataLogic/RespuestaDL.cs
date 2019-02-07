using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class RespuestaDL
    {
        public RespuestaDL() { }

        public void Inserta(RespuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Respuesta_Inserta");

            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, pItem.IdRespuesta);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pDescRespuesta", DbType.String, pItem.DescRespuesta);
            db.AddInParameter(dbCommand, "pFlagCorrecto", DbType.Boolean, pItem.FlagCorrecto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(RespuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Respuesta_Actualiza");

            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, pItem.IdRespuesta);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pDescRespuesta", DbType.String, pItem.DescRespuesta);
            db.AddInParameter(dbCommand, "pFlagCorrecto", DbType.Boolean, pItem.FlagCorrecto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(RespuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Respuesta_Elimina");

            db.AddInParameter(dbCommand, "pIdRespuesta", DbType.Int32, pItem.IdRespuesta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public RespuestaBE Selecciona(int IdRespuesta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Respuesta_Selecciona");
            db.AddInParameter(dbCommand, "pidRespuesta", DbType.Int32, IdRespuesta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RespuestaBE Respuesta = null;
            while (reader.Read())
            {
                Respuesta = new RespuestaBE();
                Respuesta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Respuesta.IdPregunta = Int32.Parse(reader["IdPregunta"].ToString());
                Respuesta.IdRespuesta = Int32.Parse(reader["idRespuesta"].ToString());
                Respuesta.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Respuesta.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                Respuesta.DescRespuesta = reader["DescRespuesta"].ToString();
                Respuesta.FlagCorrecto = Boolean.Parse(reader["FlagCorrecto"].ToString());
                Respuesta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Respuesta;
        }

        public List<RespuestaBE> ListaTodosActivo(int IdPregunta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Respuesta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, IdPregunta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RespuestaBE> Respuestalist = new List<RespuestaBE>();
            RespuestaBE Respuesta;
            while (reader.Read())
            {
                Respuesta = new RespuestaBE();
                Respuesta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Respuesta.IdPregunta = Int32.Parse(reader["IdPregunta"].ToString());
                Respuesta.IdRespuesta = Int32.Parse(reader["IdRespuesta"].ToString());
                Respuesta.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Respuesta.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                Respuesta.DescRespuesta = reader["DescRespuesta"].ToString();
                Respuesta.FlagCorrecto = Boolean.Parse(reader["FlagCorrecto"].ToString());
                Respuesta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Respuesta.TipoOper = 4; //CONSULTAR
                Respuestalist.Add(Respuesta);
            }
            reader.Close();
            reader.Dispose();
            return Respuestalist;
        }
    }
}
