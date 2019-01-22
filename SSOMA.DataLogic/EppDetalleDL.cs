using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EppDetalleDL
    {
        public EppDetalleDL() { }

        public void Inserta(EppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EppDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdEppDetalle", DbType.Int32, pItem.IdEppDetalle);
            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, pItem.IdEpp);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, pItem.IdTipoEntrega);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(EppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EppDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdEppDetalle", DbType.Int32, pItem.IdEppDetalle);
            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, pItem.IdEpp);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pIdTipoEntrega", DbType.Int32, pItem.IdTipoEntrega);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(EppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EppDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdEppDetalle", DbType.Int32, pItem.IdEppDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public EppDetalleBE Selecciona(int IdEppDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EppDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidEppDetalle", DbType.Int32, IdEppDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EppDetalleBE EppDetalle = null;
            while (reader.Read())
            {
                EppDetalle = new EppDetalleBE();
                EppDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EppDetalle.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                EppDetalle.IdEppDetalle = Int32.Parse(reader["idEppDetalle"].ToString());
                EppDetalle.Item = Int32.Parse(reader["Item"].ToString());
                EppDetalle.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                EppDetalle.Codigo = reader["Codigo"].ToString();
                EppDetalle.DescEquipo = reader["DescEquipo"].ToString();
                EppDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                EppDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                EppDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                EppDetalle.Total = Decimal.Parse(reader["Total"].ToString());
                EppDetalle.IdTipoEntrega = Int32.Parse(reader["IdTipoEntrega"].ToString());
                EppDetalle.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                EppDetalle.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                EppDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EppDetalle;
        }

        public List<EppDetalleBE> ListaTodosActivo(int IdEpp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EppDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEpp", DbType.Int32, IdEpp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EppDetalleBE> EppDetallelist = new List<EppDetalleBE>();
            EppDetalleBE EppDetalle;
            while (reader.Read())
            {
                EppDetalle = new EppDetalleBE();
                EppDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EppDetalle.IdEpp = Int32.Parse(reader["idEpp"].ToString());
                EppDetalle.IdEppDetalle = Int32.Parse(reader["idEppDetalle"].ToString());
                EppDetalle.Item = Int32.Parse(reader["Item"].ToString());
                EppDetalle.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                EppDetalle.Codigo = reader["Codigo"].ToString();
                EppDetalle.DescEquipo = reader["DescEquipo"].ToString();
                EppDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                EppDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                EppDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                EppDetalle.Total = Decimal.Parse(reader["Total"].ToString());
                EppDetalle.IdTipoEntrega = Int32.Parse(reader["IdTipoEntrega"].ToString());
                EppDetalle.DescTipoEntrega = reader["DescTipoEntrega"].ToString();
                EppDetalle.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                EppDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                EppDetalle.TipoOper = 4; //CONSULTAR
                EppDetallelist.Add(EppDetalle);
            }
            reader.Close();
            reader.Dispose();
            return EppDetallelist;
        }
    }
}
