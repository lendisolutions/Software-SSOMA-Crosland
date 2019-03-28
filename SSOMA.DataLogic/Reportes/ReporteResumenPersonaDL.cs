using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteResumenPersonaDL
    {
        public List<ReporteResumenPersonaBE> Listado(int IdEmpresa, int IdTema, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptResumenPersona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteResumenPersonaBE> ReporteResumenPersonalist = new List<ReporteResumenPersonaBE>();
            ReporteResumenPersonaBE ReporteResumenPersona;
            while (reader.Read())
            {
                ReporteResumenPersona = new ReporteResumenPersonaBE();
                ReporteResumenPersona.RazonSocial = reader["RazonSocial"].ToString();
                ReporteResumenPersona.Logo = (byte[])reader["Logo"];
                ReporteResumenPersona.DescTema = reader["DescTema"].ToString();
                ReporteResumenPersona.ApeNom = reader["ApeNom"].ToString();
                ReporteResumenPersona.Fecha = reader["Fecha"].ToString().Substring(0, 10);
                ReporteResumenPersona.NotaFinal = Int32.Parse(reader["NotaFinal"].ToString());
                ReporteResumenPersona.Situacion = reader["Situacion"].ToString();
                ReporteResumenPersona.Firma1 = (byte[])reader["Firma1"];
                ReporteResumenPersona.Firma2 = (byte[])reader["Firma2"];
                ReporteResumenPersonalist.Add(ReporteResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ReporteResumenPersonalist;
        }
    }
}
