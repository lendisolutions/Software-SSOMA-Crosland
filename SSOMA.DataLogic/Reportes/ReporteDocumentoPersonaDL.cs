using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteDocumentoPersonaDL
    {
        public List<ReporteDocumentoPersonaBE> ListadoResponsable(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDocumentoPersona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoPersonaBE> ReporteDocumentoPersonalist = new List<ReporteDocumentoPersonaBE>();
            ReporteDocumentoPersonaBE ReporteDocumentoPersona;
            while (reader.Read())
            {
                ReporteDocumentoPersona = new ReporteDocumentoPersonaBE();
                ReporteDocumentoPersona.RazonSocial = reader["RazonSocial"].ToString();
                ReporteDocumentoPersona.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteDocumentoPersona.DescArea = reader["DescArea"].ToString();
                ReporteDocumentoPersona.ApeNom = reader["ApeNom"].ToString();
                ReporteDocumentoPersona.DescCarpeta = reader["DescCarpeta"].ToString();
                ReporteDocumentoPersona.Codigo = reader["Codigo"].ToString();
                ReporteDocumentoPersona.NombreArchivo = reader["NombreArchivo"].ToString();
                ReporteDocumentoPersona.Lectura = Int32.Parse(reader["Lectura"].ToString());
                ReporteDocumentoPersonalist.Add(ReporteDocumentoPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoPersonalist;
        }
    }
}
