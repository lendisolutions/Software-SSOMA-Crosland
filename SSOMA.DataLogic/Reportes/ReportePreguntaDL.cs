using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReportePreguntaDL
    {
        public List<ReportePreguntaBE> Listado(int IdCuestionario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPregunta");
            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, IdCuestionario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePreguntaBE> ReportePreguntalist = new List<ReportePreguntaBE>();
            ReportePreguntaBE ReportePregunta;
            while (reader.Read())
            {
                ReportePregunta = new ReportePreguntaBE();
                ReportePregunta.RazonSocial = reader["RazonSocial"].ToString();
                ReportePregunta.Logo = (byte[])reader["Logo"];
                ReportePregunta.DescTema = reader["DescTema"].ToString();
                ReportePregunta.DescCuestionario = reader["DescCuestionario"].ToString();
                ReportePregunta.DescPregunta = reader["DescPregunta"].ToString();
                ReportePregunta.Puntaje = Int32.Parse(reader["Puntaje"].ToString());
                ReportePregunta.DescRespuesta = reader["DescRespuesta"].ToString();
                ReportePregunta.FlagCorrecto = bool.Parse(reader["FlagCorrecto"].ToString());
                ReportePreguntalist.Add(ReportePregunta);
            }
            reader.Close();
            reader.Dispose();
            return ReportePreguntalist;
        }
    }
}
