using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SolicitudEppDetalleDL
    {
        public SolicitudEppDetalleDL() { }

        public void Inserta(SolicitudEppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEppDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdSolicitudEppDetalle", DbType.Int32, pItem.IdSolicitudEppDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SolicitudEppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEppDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudEppDetalle", DbType.Int32, pItem.IdSolicitudEppDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, pItem.IdSolicitudEpp);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SolicitudEppDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEppDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudEppDetalle", DbType.Int32, pItem.IdSolicitudEppDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SolicitudEppDetalleBE Selecciona(int IdSolicitudEppDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEppDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidSolicitudEppDetalle", DbType.Int32, IdSolicitudEppDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEppDetalleBE SolicitudEppDetalle = null;
            while (reader.Read())
            {
                SolicitudEppDetalle = new SolicitudEppDetalleBE();
                SolicitudEppDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEppDetalle.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                SolicitudEppDetalle.IdSolicitudEppDetalle = Int32.Parse(reader["idSolicitudEppDetalle"].ToString());
                SolicitudEppDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudEppDetalle.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                SolicitudEppDetalle.Codigo = reader["Codigo"].ToString();
                SolicitudEppDetalle.DescEquipo = reader["DescEquipo"].ToString();
                SolicitudEppDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudEppDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEppDetalle;
        }

        public List<SolicitudEppDetalleBE> ListaTodosActivo(int IdSolicitudEpp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEppDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdSolicitudEpp", DbType.Int32, IdSolicitudEpp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEppDetalleBE> SolicitudEppDetallelist = new List<SolicitudEppDetalleBE>();
            SolicitudEppDetalleBE SolicitudEppDetalle;
            while (reader.Read())
            {
                SolicitudEppDetalle = new SolicitudEppDetalleBE();
                SolicitudEppDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudEppDetalle.IdSolicitudEpp = Int32.Parse(reader["IdSolicitudEpp"].ToString());
                SolicitudEppDetalle.IdSolicitudEppDetalle = Int32.Parse(reader["idSolicitudEppDetalle"].ToString());
                SolicitudEppDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudEppDetalle.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                SolicitudEppDetalle.Codigo = reader["Codigo"].ToString();
                SolicitudEppDetalle.DescEquipo = reader["DescEquipo"].ToString();
                SolicitudEppDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudEppDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudEppDetalle.TipoOper = 4; //CONSULTAR
                SolicitudEppDetallelist.Add(SolicitudEppDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEppDetallelist;
        }
    }
}
