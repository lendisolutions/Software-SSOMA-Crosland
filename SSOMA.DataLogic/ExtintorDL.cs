using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ExtintorDL
    {
        public ExtintorDL() { }

        public Int32 Inserta(ExtintorBE pItem)
        {
            Int32 intIdExtintor = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_Inserta");

            db.AddOutParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pIdClasificacionExtintor", DbType.Int32, pItem.IdClasificacionExtintor);
            db.AddInParameter(dbCommand, "pIdTipoExtintor", DbType.Int32, pItem.IdTipoExtintor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pMarca", DbType.String, pItem.Marca);
            db.AddInParameter(dbCommand, "pCapacidad", DbType.String, pItem.Capacidad);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaVencimientoPruebaHidrostatica", DbType.DateTime, pItem.FechaVencimientoPruebaHidrostatica);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pIdRealizadoPor", DbType.Int32, pItem.IdRealizadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdExtintor = (int)db.GetParameterValue(dbCommand, "pIdExtintor");

            return intIdExtintor;

        }

        public void Actualiza(ExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_Actualiza");

            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pIdClasificacionExtintor", DbType.Int32, pItem.IdClasificacionExtintor);
            db.AddInParameter(dbCommand, "pIdTipoExtintor", DbType.Int32, pItem.IdTipoExtintor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pMarca", DbType.String, pItem.Marca);
            db.AddInParameter(dbCommand, "pCapacidad", DbType.String, pItem.Capacidad);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaVencimientoPruebaHidrostatica", DbType.DateTime, pItem.FechaVencimientoPruebaHidrostatica);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pIdRealizadoPor", DbType.Int32, pItem.IdRealizadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_Elimina");

            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ExtintorBE Selecciona(int idExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_Selecciona");
            db.AddInParameter(dbCommand, "pidExtintor", DbType.Int32, idExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExtintorBE Extintor = null;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.Ubicacion = reader["Observacion"].ToString();
                Extintor.IdRealizadoPor = Int32.Parse(reader["IdRealizadoPor"].ToString());
                Extintor.RealizadoPor = reader["RealizadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Extintor;
        }

        public ExtintorBE SeleccionaCodigo(string Codigo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_SeleccionaCodigo");
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, Codigo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExtintorBE Extintor = null;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.IdRealizadoPor = Int32.Parse(reader["IdRealizadoPor"].ToString());
                Extintor.RealizadoPor = reader["RealizadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Extintor;
        }

        public List<ExtintorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.IdRealizadoPor = Int32.Parse(reader["IdRealizadoPor"].ToString());
                Extintor.RealizadoPor = reader["RealizadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.IdRealizadoPor = Int32.Parse(reader["IdRealizadoPor"].ToString());
                Extintor.RealizadoPor = reader["RealizadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaCodigo(string Codigo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaCodigo");
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, Codigo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.IdRealizadoPor = Int32.Parse(reader["IdRealizadoPor"].ToString());
                Extintor.RealizadoPor = reader["RealizadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int Dias)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaPorVencer");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, Dias);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.Dias = Int32.Parse(reader["Dias"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaVencido(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.Dias = Int32.Parse(reader["Dias"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaTipoServicio(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaTipoServicio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.RazonSocial = reader["RazonSocial"].ToString();
                Extintor.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Extintor.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.IdClasificacionExtintor = Int32.Parse(reader["IdClasificacionExtintor"].ToString());
                Extintor.AbreviaturaClasificacion = reader["AbreviaturaClasificacion"].ToString();
                Extintor.IdTipoExtintor = Int32.Parse(reader["IdTipoExtintor"].ToString());
                Extintor.AbreviaturaTipo = reader["AbreviaturaTipo"].ToString();
                Extintor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Extintor.Proveedor = reader["Proveedor"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                Extintor.DescServicioExtintor = reader["DescServicioExtintor"].ToString();
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaCombo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.DescExtintor = reader["DescExtintor"].ToString();
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }

        public List<ExtintorBE> ListaInspeccionDetalle(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Extintor_ListaInspeccionDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorBE> Extintorlist = new List<ExtintorBE>();
            ExtintorBE Extintor;
            while (reader.Read())
            {
                Extintor = new ExtintorBE();
                Extintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Extintor.Codigo = reader["Codigo"].ToString();
                Extintor.Serie = reader["Serie"].ToString();
                Extintor.Abreviatura = reader["Abreviatura"].ToString();
                Extintor.Capacidad = reader["Capacidad"].ToString();
                Extintor.Ubicacion = reader["Ubicacion"].ToString();
                Extintor.Marca = reader["Marca"].ToString();
                Extintor.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                Extintor.IdExtintorInspeccion = Int32.Parse(reader["IdExtintorInspeccion"].ToString());
                Extintor.IdExtintorInspeccionDetalle = Int32.Parse(reader["IdExtintorInspeccionDetalle"].ToString());
                Extintor.Uno = Boolean.Parse(reader["Uno"].ToString());
                Extintor.Dos = Boolean.Parse(reader["Dos"].ToString());
                Extintor.Tres = Boolean.Parse(reader["Tres"].ToString());
                Extintor.Cuatro = Boolean.Parse(reader["Cuatro"].ToString());
                Extintor.Cinco = Boolean.Parse(reader["Cinco"].ToString());
                Extintor.Seis = Boolean.Parse(reader["Seis"].ToString());
                Extintor.Siete = Boolean.Parse(reader["Siete"].ToString());
                Extintor.Ocho = Boolean.Parse(reader["Ocho"].ToString());
                Extintor.Nueve = Boolean.Parse(reader["Nueve"].ToString());
                Extintor.Diez = Boolean.Parse(reader["Diez"].ToString());
                Extintor.Once = Boolean.Parse(reader["Once"].ToString());
                Extintor.Doce = Boolean.Parse(reader["Doce"].ToString());
                Extintor.Trece = Boolean.Parse(reader["Trece"].ToString());
                Extintor.Quince = Boolean.Parse(reader["Quince"].ToString());
                Extintor.Diecisies = Boolean.Parse(reader["Diecisies"].ToString());
                Extintor.Diecisiete = Boolean.Parse(reader["Diecisiete"].ToString());
                Extintor.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Extintor.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                Extintor.RecargadoPor = reader["RecargadoPor"].ToString();
                Extintor.Observacion = reader["Observacion"].ToString();
                Extintor.TipoOper = Int32.Parse(reader["TipoOper"].ToString());
                Extintorlist.Add(Extintor);
            }
            reader.Close();
            reader.Dispose();
            return Extintorlist;
        }
    }
}
