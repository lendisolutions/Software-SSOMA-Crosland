using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ValoracionRiesgoDL
    {
        public ValoracionRiesgoDL() { }

        public void Inserta(ValoracionRiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValoracionRiesgo_Inserta");

            db.AddInParameter(dbCommand, "pIdValoracionRiesgo", DbType.Int32, pItem.IdValoracionRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValoracion", DbType.String, pItem.Valoracion);
            db.AddInParameter(dbCommand, "pClasificacion", DbType.String, pItem.Clasificacion);
            db.AddInParameter(dbCommand, "pDescValoracionRiesgo", DbType.String, pItem.DescValoracionRiesgo);
            db.AddInParameter(dbCommand, "pCalificacion", DbType.String, pItem.Calificacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ValoracionRiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValoracionRiesgo_Actualiza");

            db.AddInParameter(dbCommand, "pIdValoracionRiesgo", DbType.Int32, pItem.IdValoracionRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pValoracion", DbType.String, pItem.Valoracion);
            db.AddInParameter(dbCommand, "pClasificacion", DbType.String, pItem.Clasificacion);
            db.AddInParameter(dbCommand, "pDescValoracionRiesgo", DbType.String, pItem.DescValoracionRiesgo);
            db.AddInParameter(dbCommand, "pCalificacion", DbType.String, pItem.Calificacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ValoracionRiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValoracionRiesgo_Elimina");

            db.AddInParameter(dbCommand, "pIdValoracionRiesgo", DbType.Int32, pItem.IdValoracionRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ValoracionRiesgoBE Selecciona(int idValoracionRiesgo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValoracionRiesgo_Selecciona");
            db.AddInParameter(dbCommand, "pidValoracionRiesgo", DbType.Int32, idValoracionRiesgo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ValoracionRiesgoBE ValoracionRiesgo = null;
            while (reader.Read())
            {
                ValoracionRiesgo = new ValoracionRiesgoBE();
                ValoracionRiesgo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ValoracionRiesgo.IdValoracionRiesgo = Int32.Parse(reader["idValoracionRiesgo"].ToString());
                ValoracionRiesgo.Valoracion = reader["Valoracion"].ToString();
                ValoracionRiesgo.Clasificacion = reader["Clasificacion"].ToString();
                ValoracionRiesgo.DescValoracionRiesgo = reader["DescValoracionRiesgo"].ToString();
                ValoracionRiesgo.Calificacion = reader["Calificacion"].ToString();
                ValoracionRiesgo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ValoracionRiesgo;
        }

        public List<ValoracionRiesgoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValoracionRiesgo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ValoracionRiesgoBE> ValoracionRiesgolist = new List<ValoracionRiesgoBE>();
            ValoracionRiesgoBE ValoracionRiesgo;
            while (reader.Read())
            {
                ValoracionRiesgo = new ValoracionRiesgoBE();
                ValoracionRiesgo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ValoracionRiesgo.IdValoracionRiesgo = Int32.Parse(reader["idValoracionRiesgo"].ToString());
                ValoracionRiesgo.Valoracion = reader["Valoracion"].ToString();
                ValoracionRiesgo.Clasificacion = reader["Clasificacion"].ToString();
                ValoracionRiesgo.DescValoracionRiesgo = reader["DescValoracionRiesgo"].ToString();
                ValoracionRiesgo.Calificacion = reader["Calificacion"].ToString();
                ValoracionRiesgo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ValoracionRiesgolist.Add(ValoracionRiesgo);
            }
            reader.Close();
            reader.Dispose();
            return ValoracionRiesgolist;
        }
    }
}
