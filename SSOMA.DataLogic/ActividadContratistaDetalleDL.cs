using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ActividadContratistaDetalleDL
    {
        public ActividadContratistaDetalleDL() { }

        public void Inserta(ActividadContratistaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratistaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdActividadContratistaDetalle", DbType.Int32, pItem.IdActividadContratistaDetalle);
            db.AddInParameter(dbCommand, "pIdActividadContratista", DbType.Int32, pItem.IdActividadContratista);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pExtension", DbType.String, pItem.Extension);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ActividadContratistaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratistaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdActividadContratistaDetalle", DbType.Int32, pItem.IdActividadContratistaDetalle);
            db.AddInParameter(dbCommand, "pIdActividadContratista", DbType.Int32, pItem.IdActividadContratista);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pExtension", DbType.String, pItem.Extension);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ActividadContratistaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratistaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdActividadContratistaDetalle", DbType.Int32, pItem.IdActividadContratistaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ActividadContratistaDetalleBE Selecciona(int IdActividadContratistaDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratistaDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidActividadContratistaDetalle", DbType.Int32, IdActividadContratistaDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ActividadContratistaDetalleBE ActividadContratistaDetalle = null;
            while (reader.Read())
            {
                ActividadContratistaDetalle = new ActividadContratistaDetalleBE();
                ActividadContratistaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActividadContratistaDetalle.IdActividadContratistaDetalle = Int32.Parse(reader["idActividadContratistaDetalle"].ToString());
                ActividadContratistaDetalle.IdActividadContratista = Int32.Parse(reader["IdActividadContratista"].ToString());
                ActividadContratistaDetalle.Archivo = (byte[])reader["Archivo"];
                ActividadContratistaDetalle.NombreArchivo = reader["NombreArchivo"].ToString();
                ActividadContratistaDetalle.Extension = reader["Extension"].ToString();
                ActividadContratistaDetalle.Descripcion = reader["Descripcion"].ToString();
                ActividadContratistaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ActividadContratistaDetalle;
        }

        public List<ActividadContratistaDetalleBE> ListaTodosActivo(int IdActividadContratista)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ActividadContratistaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdActividadContratista", DbType.Int32, IdActividadContratista);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ActividadContratistaDetalleBE> ActividadContratistaDetallelist = new List<ActividadContratistaDetalleBE>();
            ActividadContratistaDetalleBE ActividadContratistaDetalle;
            while (reader.Read())
            {
                ActividadContratistaDetalle = new ActividadContratistaDetalleBE();
                ActividadContratistaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ActividadContratistaDetalle.IdActividadContratistaDetalle = Int32.Parse(reader["idActividadContratistaDetalle"].ToString());
                ActividadContratistaDetalle.IdActividadContratista = Int32.Parse(reader["IdActividadContratista"].ToString());
                ActividadContratistaDetalle.Archivo = (byte[])reader["Archivo"];
                ActividadContratistaDetalle.NombreArchivo = reader["NombreArchivo"].ToString();
                ActividadContratistaDetalle.Extension = reader["Extension"].ToString();
                ActividadContratistaDetalle.Descripcion = reader["Descripcion"].ToString();
                ActividadContratistaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ActividadContratistaDetalle.TipoOper = 4; //CONSULTAR
                ActividadContratistaDetallelist.Add(ActividadContratistaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ActividadContratistaDetallelist;
        }
    }
}
