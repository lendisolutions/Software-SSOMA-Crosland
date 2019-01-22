using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class MovimientoExtintorDL
    {
        public MovimientoExtintorDL() { }

        public Int32 Inserta(MovimientoExtintorBE pItem)
        {
            Int32 intIdMovimientoExtintor = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_Inserta");

            db.AddInParameter(dbCommand, "pIdMovimientoExtintor", DbType.Int32, pItem.IdMovimientoExtintor);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pHechoPor", DbType.String, pItem.HechoPor);
            db.AddInParameter(dbCommand, "pAutorizadoPor", DbType.String, pItem.AutorizadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

            intIdMovimientoExtintor = (int)db.GetParameterValue(dbCommand, "pIdMovimientoExtintor");

            return intIdMovimientoExtintor;

        }

        public void Actualiza(MovimientoExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoExtintor", DbType.Int32, pItem.IdMovimientoExtintor);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pHechoPor", DbType.String, pItem.HechoPor);
            db.AddInParameter(dbCommand, "pAutorizadoPor", DbType.String, pItem.AutorizadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(MovimientoExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoExtintor", DbType.Int32, pItem.IdMovimientoExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public MovimientoExtintorBE Selecciona(int idMovimientoExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_Selecciona");
            db.AddInParameter(dbCommand, "pidMovimientoExtintor", DbType.Int32, idMovimientoExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoExtintorBE MovimientoExtintor = null;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintor;
        }

        public MovimientoExtintorBE SeleccionaCodigo(string Codigo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_SeleccionaCodigo");
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, Codigo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoExtintorBE MovimientoExtintor = null;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintor;
        }

        public List<MovimientoExtintorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoExtintorBE> MovimientoExtintorlist = new List<MovimientoExtintorBE>();
            MovimientoExtintorBE MovimientoExtintor;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoExtintorlist.Add(MovimientoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintorlist;
        }

        public List<MovimientoExtintorBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoExtintorBE> MovimientoExtintorlist = new List<MovimientoExtintorBE>();
            MovimientoExtintorBE MovimientoExtintor;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoExtintorlist.Add(MovimientoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintorlist;
        }

        public List<MovimientoExtintorBE> ListaCodigo(string Codigo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_ListaCodigo");
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, Codigo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoExtintorBE> MovimientoExtintorlist = new List<MovimientoExtintorBE>();
            MovimientoExtintorBE MovimientoExtintor;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoExtintorlist.Add(MovimientoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintorlist;
        }

        public List<MovimientoExtintorBE> ListaArea(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoExtintor_ListaArea");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoExtintorBE> MovimientoExtintorlist = new List<MovimientoExtintorBE>();
            MovimientoExtintorBE MovimientoExtintor;
            while (reader.Read())
            {
                MovimientoExtintor = new MovimientoExtintorBE();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.IdMovimientoExtintor = Int32.Parse(reader["idMovimientoExtintor"].ToString());
                MovimientoExtintor.IdExtintor = Int32.Parse(reader["IdExtintor"].ToString());
                MovimientoExtintor.Codigo = reader["Codigo"].ToString();
                MovimientoExtintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                MovimientoExtintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                MovimientoExtintor.Capacidad = reader["Capacidad"].ToString();
                MovimientoExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoExtintor.RazonSocial = reader["RazonSocial"].ToString();
                MovimientoExtintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                MovimientoExtintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                MovimientoExtintor.IdArea = Int32.Parse(reader["IdArea"].ToString());
                MovimientoExtintor.DescArea = reader["DescArea"].ToString();
                MovimientoExtintor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoExtintor.Ubicacion = reader["Ubicacion"].ToString();
                MovimientoExtintor.HechoPor = reader["HechoPor"].ToString();
                MovimientoExtintor.AutorizadoPor = reader["AutorizadoPor"].ToString();
                MovimientoExtintor.Observacion = reader["Observacion"].ToString();
                MovimientoExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoExtintorlist.Add(MovimientoExtintor);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoExtintorlist;
        }
    }
}
