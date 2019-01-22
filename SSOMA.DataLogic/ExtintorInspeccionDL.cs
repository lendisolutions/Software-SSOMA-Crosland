using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ExtintorInspeccionDL
    {
        public ExtintorInspeccionDL() { }

        public Int32 Inserta(ExtintorInspeccionBE pItem)
        {
            Int32 intIdExtintorInspeccion = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_Inserta");

            db.AddOutParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, pItem.IdExtintorInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pFechaInspeccion", DbType.DateTime, pItem.FechaInspeccion);
            db.AddInParameter(dbCommand, "pInspeccionadoPor", DbType.String, pItem.InspeccionadoPor);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdExtintorInspeccion = (int)db.GetParameterValue(dbCommand, "pIdExtintorInspeccion");

            return intIdExtintorInspeccion;

        }

        public void Actualiza(ExtintorInspeccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_Actualiza");

            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, pItem.IdExtintorInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdTipoInspeccion", DbType.Int32, pItem.IdTipoInspeccion);
            db.AddInParameter(dbCommand, "pFechaInspeccion", DbType.DateTime, pItem.FechaInspeccion);
            db.AddInParameter(dbCommand, "pInspeccionadoPor", DbType.String, pItem.InspeccionadoPor);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ExtintorInspeccionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_Elimina");

            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, pItem.IdExtintorInspeccion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ExtintorInspeccionBE Selecciona(int idExtintorInspeccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_Selecciona");
            db.AddInParameter(dbCommand, "pidExtintorInspeccion", DbType.Int32, idExtintorInspeccion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExtintorInspeccionBE ExtintorInspeccion = null;
            while (reader.Read())
            {
                ExtintorInspeccion = new ExtintorInspeccionBE();
                ExtintorInspeccion.IdExtintorInspeccion = Int32.Parse(reader["idExtintorInspeccion"].ToString());
                ExtintorInspeccion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorInspeccion.RazonSocial = reader["RazonSocial"].ToString();
                ExtintorInspeccion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                ExtintorInspeccion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ExtintorInspeccion.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                ExtintorInspeccion.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ExtintorInspeccion.FechaInspeccion = DateTime.Parse(reader["FechaInspeccion"].ToString());
                ExtintorInspeccion.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ExtintorInspeccion.Cargo = reader["Cargo"].ToString();
                ExtintorInspeccion.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccion;
        }

        public List<ExtintorInspeccionBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorInspeccionBE> ExtintorInspeccionlist = new List<ExtintorInspeccionBE>();
            ExtintorInspeccionBE ExtintorInspeccion;
            while (reader.Read())
            {
                ExtintorInspeccion = new ExtintorInspeccionBE();
                ExtintorInspeccion.IdExtintorInspeccion = Int32.Parse(reader["idExtintorInspeccion"].ToString());
                ExtintorInspeccion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorInspeccion.RazonSocial = reader["RazonSocial"].ToString();
                ExtintorInspeccion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                ExtintorInspeccion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ExtintorInspeccion.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                ExtintorInspeccion.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ExtintorInspeccion.FechaInspeccion = DateTime.Parse(reader["FechaInspeccion"].ToString());
                ExtintorInspeccion.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ExtintorInspeccion.Cargo = reader["Cargo"].ToString();
                ExtintorInspeccion.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ExtintorInspeccionlist.Add(ExtintorInspeccion);
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccionlist;
        }

        public List<ExtintorInspeccionBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccion_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorInspeccionBE> ExtintorInspeccionlist = new List<ExtintorInspeccionBE>();
            ExtintorInspeccionBE ExtintorInspeccion;
            while (reader.Read())
            {
                ExtintorInspeccion = new ExtintorInspeccionBE();
                ExtintorInspeccion.IdExtintorInspeccion = Int32.Parse(reader["idExtintorInspeccion"].ToString());
                ExtintorInspeccion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorInspeccion.RazonSocial = reader["RazonSocial"].ToString();
                ExtintorInspeccion.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                ExtintorInspeccion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ExtintorInspeccion.IdTipoInspeccion = Int32.Parse(reader["IdTipoInspeccion"].ToString());
                ExtintorInspeccion.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ExtintorInspeccion.FechaInspeccion = DateTime.Parse(reader["FechaInspeccion"].ToString());
                ExtintorInspeccion.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ExtintorInspeccion.Cargo = reader["Cargo"].ToString();
                ExtintorInspeccion.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ExtintorInspeccionlist.Add(ExtintorInspeccion);
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccionlist;
        }

        public List<ExtintorInspeccionBE> ListaReporte(int IdExtintorInspeccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptExtintorInspeccion");
            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, IdExtintorInspeccion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorInspeccionBE> ExtintorInspeccionlist = new List<ExtintorInspeccionBE>();
            ExtintorInspeccionBE ExtintorInspeccion;
            while (reader.Read())
            {
                ExtintorInspeccion = new ExtintorInspeccionBE();
                ExtintorInspeccion.RazonSocial = reader["RazonSocial"].ToString();
                ExtintorInspeccion.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                ExtintorInspeccion.DescTipoInspeccion = reader["DescTipoInspeccion"].ToString();
                ExtintorInspeccion.FechaInspeccion = DateTime.Parse(reader["FechaInspeccion"].ToString());
                ExtintorInspeccion.InspeccionadoPor = reader["InspeccionadoPor"].ToString();
                ExtintorInspeccion.Cargo = reader["Cargo"].ToString();
                ExtintorInspeccion.Codigo = reader["Codigo"].ToString();
                ExtintorInspeccion.Serie = reader["Serie"].ToString();
                ExtintorInspeccion.Abreviatura = reader["Abreviatura"].ToString();
                ExtintorInspeccion.Capacidad = reader["Capacidad"].ToString();
                ExtintorInspeccion.Ubicacion = reader["Ubicacion"].ToString();
                ExtintorInspeccion.Marca = reader["Marca"].ToString();
                ExtintorInspeccion.Uno = Boolean.Parse(reader["Uno"].ToString());
                ExtintorInspeccion.Dos = Boolean.Parse(reader["Dos"].ToString());
                ExtintorInspeccion.Tres = Boolean.Parse(reader["Tres"].ToString());
                ExtintorInspeccion.Cuatro = Boolean.Parse(reader["Cuatro"].ToString());
                ExtintorInspeccion.Cinco = Boolean.Parse(reader["Cinco"].ToString());
                ExtintorInspeccion.Seis = Boolean.Parse(reader["Seis"].ToString());
                ExtintorInspeccion.Siete = Boolean.Parse(reader["Siete"].ToString());
                ExtintorInspeccion.Ocho = Boolean.Parse(reader["Ocho"].ToString());
                ExtintorInspeccion.Nueve = Boolean.Parse(reader["Nueve"].ToString());
                ExtintorInspeccion.Diez = Boolean.Parse(reader["Diez"].ToString());
                ExtintorInspeccion.Once = Boolean.Parse(reader["Once"].ToString());
                ExtintorInspeccion.Doce = Boolean.Parse(reader["Doce"].ToString());
                ExtintorInspeccion.Trece = Boolean.Parse(reader["Trece"].ToString());
                ExtintorInspeccion.Quince = Boolean.Parse(reader["Quince"].ToString());
                ExtintorInspeccion.Diecisies = Boolean.Parse(reader["Diecisies"].ToString());
                ExtintorInspeccion.Diecisiete = Boolean.Parse(reader["Diecisiete"].ToString());
                ExtintorInspeccion.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ExtintorInspeccion.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                ExtintorInspeccion.RecargadoPor = reader["RecargadoPor"].ToString();
                ExtintorInspeccion.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccionlist.Add(ExtintorInspeccion);
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccionlist;
        }

    }
}
