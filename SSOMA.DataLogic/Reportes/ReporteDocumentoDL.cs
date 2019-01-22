using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteDocumentoDL
    {
        public List<ReporteDocumentoBE> ListadoResponsable(int IdEmpresa, int IdCarpeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, IdCarpeta);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoBE> ReporteDocumentolist = new List<ReporteDocumentoBE>();
            ReporteDocumentoBE ReporteDocumento;
            while (reader.Read())
            {
                ReporteDocumento = new ReporteDocumentoBE();
                ReporteDocumento.RazonSocial = reader["RazonSocial"].ToString();
                ReporteDocumento.DescCarpeta = reader["DescCarpeta"].ToString();
                ReporteDocumento.Codigo = reader["Codigo"].ToString();
                ReporteDocumento.NombreArchivo = reader["NombreArchivo"].ToString();
                ReporteDocumento.Revision = reader["Revision"].ToString();
                ReporteDocumento.FechaAprobacion = reader["FechaAprobacion"].ToString().Substring(0,10);
                ReporteDocumentolist.Add(ReporteDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentolist;
        }
    }
}
