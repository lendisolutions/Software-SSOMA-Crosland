using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PreguntaDL
    {
        public PreguntaDL() { }

        public Int32 Inserta(PreguntaBE pItem)
        {
            Int32 intPregunta = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pregunta_Inserta");

            db.AddOutParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pDescPregunta", DbType.String, pItem.DescPregunta);
            db.AddInParameter(dbCommand, "pPuntaje", DbType.Int32, pItem.Puntaje);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intPregunta = (int)db.GetParameterValue(dbCommand, "pIdPregunta");

            return intPregunta;

        }

        public void Actualiza(PreguntaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pregunta_Actualiza");

            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pDescPregunta", DbType.String, pItem.DescPregunta);
            db.AddInParameter(dbCommand, "pPuntaje", DbType.Int32, pItem.Puntaje);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(PreguntaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pregunta_Elimina");

            db.AddInParameter(dbCommand, "pIdPregunta", DbType.Int32, pItem.IdPregunta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PreguntaBE Selecciona(int IdEmpresa, int idPregunta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pregunta_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidPregunta", DbType.Int32, idPregunta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PreguntaBE Pregunta = null;
            while (reader.Read())
            {
                Pregunta = new PreguntaBE();
                Pregunta.IdPregunta = Int32.Parse(reader["idPregunta"].ToString());
                Pregunta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pregunta.RazonSocial = reader["RazonSocial"].ToString();
                Pregunta.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Pregunta.DescTema = reader["DescTema"].ToString();
                Pregunta.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                Pregunta.DescCuestionario = reader["DescCuestionario"].ToString();
                Pregunta.DescPregunta = reader["DescPregunta"].ToString();
                Pregunta.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                Pregunta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pregunta;
        }

        public List<PreguntaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdCuestionario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pregunta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, IdCuestionario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PreguntaBE> Preguntalist = new List<PreguntaBE>();
            PreguntaBE Pregunta;
            while (reader.Read())
            {
                Pregunta = new PreguntaBE();
                Pregunta.IdPregunta = Int32.Parse(reader["idPregunta"].ToString());
                Pregunta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pregunta.RazonSocial = reader["RazonSocial"].ToString();
                Pregunta.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Pregunta.DescTema = reader["DescTema"].ToString();
                Pregunta.IdCuestionario = Int32.Parse(reader["IdCuestionario"].ToString());
                Pregunta.DescCuestionario = reader["DescCuestionario"].ToString();
                Pregunta.DescPregunta = reader["DescPregunta"].ToString();
                Pregunta.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                Pregunta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Preguntalist.Add(Pregunta);
            }
            reader.Close();
            reader.Dispose();
            return Preguntalist;
        }
    }
}
