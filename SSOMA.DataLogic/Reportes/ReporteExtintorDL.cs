using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteExtintorDL
    {
        public List<ReporteExtintorBE> ListaVencido(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptExtintorVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteExtintorBE> ReporteExtintorlist = new List<ReporteExtintorBE>();
            ReporteExtintorBE ReporteExtintor;
            while (reader.Read())
            {
                ReporteExtintor = new ReporteExtintorBE();
                ReporteExtintor.RazonSocial = reader["RazonSocial"].ToString();
                ReporteExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteExtintor.Codigo = reader["Codigo"].ToString();
                ReporteExtintor.Serie = reader["Serie"].ToString();
                ReporteExtintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                ReporteExtintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                ReporteExtintor.Proveedor = reader["Proveedor"].ToString();
                ReporteExtintor.Marca = reader["Marca"].ToString();
                ReporteExtintor.Capacidad = reader["Capacidad"].ToString();
                ReporteExtintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                ReporteExtintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteExtintor.Ubicacion = reader["Ubicacion"].ToString();
                ReporteExtintor.Dias = Int32.Parse(reader["Dias"].ToString());
                ReporteExtintorlist.Add(ReporteExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ReporteExtintorlist;
        }

        public List<ReporteExtintorBE> ListaUbicacion(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptExtintorUbicacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteExtintorBE> ReporteExtintorlist = new List<ReporteExtintorBE>();
            ReporteExtintorBE ReporteExtintor;
            while (reader.Read())
            {
                ReporteExtintor = new ReporteExtintorBE();
                ReporteExtintor.RazonSocial = reader["RazonSocial"].ToString();
                ReporteExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ReporteExtintor.Codigo = reader["Codigo"].ToString();
                ReporteExtintor.Serie = reader["Serie"].ToString();
                ReporteExtintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                ReporteExtintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                ReporteExtintor.Proveedor = reader["Proveedor"].ToString();
                ReporteExtintor.Marca = reader["Marca"].ToString();
                ReporteExtintor.Capacidad = reader["Capacidad"].ToString();
                ReporteExtintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                ReporteExtintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteExtintor.Ubicacion = reader["Ubicacion"].ToString();
                ReporteExtintorlist.Add(ReporteExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ReporteExtintorlist;
        }
    }
}
