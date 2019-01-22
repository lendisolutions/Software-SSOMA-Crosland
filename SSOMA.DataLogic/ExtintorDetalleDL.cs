using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ExtintorDetalleDL
    {
        public ExtintorDetalleDL() { }

        public void Inserta(ExtintorDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdExtintorDetalle", DbType.Int32, pItem.IdExtintorDetalle);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, pItem.IdServicioExtintor);
            db.AddInParameter(dbCommand, "pDescServicioExtintor", DbType.String, pItem.DescServicioExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ExtintorDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdExtintorDetalle", DbType.Int32, pItem.IdExtintorDetalle);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, pItem.IdServicioExtintor);
            db.AddInParameter(dbCommand, "pDescServicioExtintor", DbType.String, pItem.DescServicioExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ExtintorDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdExtintorDetalle", DbType.Int32, pItem.IdExtintorDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ExtintorDetalleBE Selecciona(int IdExtintorDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidExtintorDetalle", DbType.Int32, IdExtintorDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExtintorDetalleBE ExtintorDetalle = null;
            while (reader.Read())
            {
                ExtintorDetalle = new ExtintorDetalleBE();
                ExtintorDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorDetalle.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                ExtintorDetalle.IdExtintorDetalle = Int32.Parse(reader["idExtintorDetalle"].ToString());
                ExtintorDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ExtintorDetalle.IdServicioExtintor = Int32.Parse(reader["IdServicioExtintor"].ToString());
                ExtintorDetalle.DescServicioExtintor = reader["DescServicioExtintor"].ToString();
                ExtintorDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ExtintorDetalle;
        }

        public List<ExtintorDetalleBE> ListaTodosActivo(int IdExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, IdExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorDetalleBE> ExtintorDetallelist = new List<ExtintorDetalleBE>();
            ExtintorDetalleBE ExtintorDetalle;
            while (reader.Read())
            {
                ExtintorDetalle = new ExtintorDetalleBE();
                ExtintorDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorDetalle.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                ExtintorDetalle.IdExtintorDetalle = Int32.Parse(reader["idExtintorDetalle"].ToString());
                ExtintorDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ExtintorDetalle.IdServicioExtintor = Int32.Parse(reader["IdServicioExtintor"].ToString());
                ExtintorDetalle.DescServicioExtintor = reader["DescServicioExtintor"].ToString();
                ExtintorDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ExtintorDetalle.TipoOper = 4; //CONSULTAR
                ExtintorDetallelist.Add(ExtintorDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ExtintorDetallelist;
        }
    }
}
