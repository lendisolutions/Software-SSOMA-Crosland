using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteSeguroViajeDL
    {
        public List<ReporteSeguroViajeBE> ListaFecha(int IdEmpresa, int IdPersona, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSeguroViajeListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSeguroViajeBE> ReporteSeguroViajelist = new List<ReporteSeguroViajeBE>();
            ReporteSeguroViajeBE ReporteSeguroViaje;
            while (reader.Read())
            {
                ReporteSeguroViaje = new ReporteSeguroViajeBE();
                ReporteSeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                ReporteSeguroViaje.Numero = reader["Numero"].ToString();
                ReporteSeguroViaje.FechaSalida = reader["FechaSalida"].ToString().Substring(0,10);
                ReporteSeguroViaje.FechaLlegada = reader["FechaLlegada"].ToString().Substring(0,10);
                ReporteSeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                ReporteSeguroViaje.Pais = reader["Pais"].ToString();
                ReporteSeguroViaje.Dni = reader["Dni"].ToString();
                ReporteSeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                ReporteSeguroViaje.Solicitante = reader["Solicitante"].ToString();
                ReporteSeguroViaje.FechaNacimiento = reader["FechaNacimiento"].ToString().Substring(0,10);
                ReporteSeguroViaje.Direccion = reader["Direccion"].ToString();
                ReporteSeguroViaje.Distrito = reader["Distrito"].ToString();
                ReporteSeguroViaje.Telefono = reader["Telefono"].ToString();
                ReporteSeguroViaje.Email = reader["Email"].ToString();
                ReporteSeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                ReporteSeguroViaje.Cargo = reader["Cargo"].ToString();
                ReporteSeguroViaje.Contacto = reader["Contacto"].ToString();
                ReporteSeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                ReporteSeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                ReporteSeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                ReporteSeguroViaje.Ruc = reader["Ruc"].ToString();
                ReporteSeguroViaje.Autoriza = reader["Autoriza"].ToString();
                ReporteSeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                ReporteSeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                ReporteSeguroViajelist.Add(ReporteSeguroViaje);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSeguroViajelist;
        }
    }
}
