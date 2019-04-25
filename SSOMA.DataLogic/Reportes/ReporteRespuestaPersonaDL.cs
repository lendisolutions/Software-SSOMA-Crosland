using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteRespuestaPersonaDL
    {
        public List<ReporteRespuestaPersonaBE> Listado(int IdTema, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptRespuestaPersona");
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteRespuestaPersonaBE> ReporteRespuestaPersonalist = new List<ReporteRespuestaPersonaBE>();
            ReporteRespuestaPersonaBE ReporteRespuestaPersona;
            while (reader.Read())
            {
                ReporteRespuestaPersona = new ReporteRespuestaPersonaBE();
                ReporteRespuestaPersona.RazonSocial = reader["RazonSocial"].ToString();
                ReporteRespuestaPersona.Logo = (byte[])reader["Logo"];
                ReporteRespuestaPersona.DescTema = reader["DescTema"].ToString();
                ReporteRespuestaPersona.DescCuestionario = reader["DescCuestionario"].ToString();
                ReporteRespuestaPersona.DescPregunta = reader["DescPregunta"].ToString();
                ReporteRespuestaPersona.DescRespuesta = reader["DescRespuesta"].ToString();
                ReporteRespuestaPersona.ApeNom = reader["ApeNom"].ToString();
                ReporteRespuestaPersona.DescSituacion = reader["DescSituacion"].ToString();
                ReporteRespuestaPersona.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                ReporteRespuestaPersonalist.Add(ReporteRespuestaPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteRespuestaPersonalist;
        }
    }
}
