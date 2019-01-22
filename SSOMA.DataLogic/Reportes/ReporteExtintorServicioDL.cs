using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteExtintorServicioDL
    {
        public List<ReporteExtintorServicioBE> ListaServicio(int IdEmpresa, int IdUnidadMinera, int IdTipoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptExtintorTipoServicio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdTipoServicio", DbType.Int32, IdTipoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteExtintorServicioBE> ReporteExtintorServiciolist = new List<ReporteExtintorServicioBE>();
            ReporteExtintorServicioBE ReporteExtintorServicio;
            while (reader.Read())
            {
                ReporteExtintorServicio = new ReporteExtintorServicioBE();
                ReporteExtintorServicio.RazonSocial = reader["RazonSocial"].ToString();
                ReporteExtintorServicio.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteExtintorServicio.Codigo = reader["Codigo"].ToString();
                ReporteExtintorServicio.Serie = reader["Serie"].ToString();
                ReporteExtintorServicio.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                ReporteExtintorServicio.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                ReporteExtintorServicio.Proveedor = reader["Proveedor"].ToString();
                ReporteExtintorServicio.Marca = reader["Marca"].ToString();
                ReporteExtintorServicio.Capacidad = reader["Capacidad"].ToString();
                ReporteExtintorServicio.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                ReporteExtintorServicio.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteExtintorServicio.Ubicacion = reader["Ubicacion"].ToString();
                ReporteExtintorServicio.DescServicioExtintor = reader["DescServicioExtintor"].ToString();
                ReporteExtintorServiciolist.Add(ReporteExtintorServicio);
            }
            reader.Close();
            reader.Dispose();
            return ReporteExtintorServiciolist;
        }
    }
}
