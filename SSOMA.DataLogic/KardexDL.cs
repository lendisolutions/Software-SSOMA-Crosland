using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class KardexDL
    {
        public KardexDL() { }

        public Int32 Inserta(KardexBE pItem)
        {
            Int32 intIdKardex = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Inserta");

            db.AddOutParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Decimal, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdKardex = (int)db.GetParameterValue(dbCommand, "pIdKardex");

            return intIdKardex;
        }

        public void Actualiza(KardexBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Actualiza");

            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Decimal, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(KardexBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Elimina");

            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<KardexBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, DescOrdenInterna);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdKardex = Int32.Parse(reader["idKardex"].ToString());
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.RazonSocial = reader["RazonSocial"].ToString();
                Kardex.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Kardex.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Kardex.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Kardex.Codigo = reader["Codigo"].ToString();
                Kardex.DescEquipo = reader["DescEquipo"].ToString();
                Kardex.Cantidad = Decimal.Parse(reader["Cantidad"].ToString());
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public KardexBE Selecciona(int IdKardex)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Selecciona");
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, IdKardex);

            IDataReader reader = db.ExecuteReader(dbCommand);
            KardexBE Kardex = null;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdKardex = Int32.Parse(reader["idKardex"].ToString());
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.RazonSocial = reader["RazonSocial"].ToString();
                Kardex.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Kardex.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Kardex.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Kardex.Codigo = reader["Codigo"].ToString();
                Kardex.DescEquipo = reader["DescEquipo"].ToString();
                Kardex.Cantidad = Decimal.Parse(reader["Cantidad"].ToString());
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
               
            }
            reader.Close();
            reader.Dispose();
            return Kardex;
        }

        public List<KardexBE> ListaInventario(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, int IdEquipo, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaInventario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, DescOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.RazonSocial = reader["RazonSocial"].ToString();
                Kardex.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Kardex.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Kardex.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Kardex.Codigo = reader["Codigo"].ToString();
                Kardex.DescEquipo = reader["DescEquipo"].ToString();
                Kardex.Stock = decimal.Parse(reader["Stock"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> ListaInventarioDetalle(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna, int IdEquipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaInventarioDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, DescOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.RazonSocial = reader["RazonSocial"].ToString();
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Kardex.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Kardex.DescOrdenInterna = reader["DescOrdenInterna"].ToString();
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Kardex.Codigo = reader["Codigo"].ToString();
                Kardex.DescEquipo = reader["DescEquipo"].ToString();
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Ingresos = Decimal.Parse(reader["Ingresos"].ToString());
                Kardex.Salidas = Decimal.Parse(reader["Salidas"].ToString());
                Kardex.Stock = Decimal.Parse(reader["Stock"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }
    }
}
