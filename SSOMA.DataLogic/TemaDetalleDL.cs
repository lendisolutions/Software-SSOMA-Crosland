using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TemaDetalleDL
    {
        public TemaDetalleDL() { }

        public void Inserta(TemaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdTemaDetalle", DbType.Int32, pItem.IdTemaDetalle);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
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

        public void Actualiza(TemaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdTemaDetalle", DbType.Int32, pItem.IdTemaDetalle);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
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

        public void Elimina(TemaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdTemaDetalle", DbType.Int32, pItem.IdTemaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TemaDetalleBE Selecciona(int IdTemaDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidTemaDetalle", DbType.Int32, IdTemaDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaDetalleBE TemaDetalle = null;
            while (reader.Read())
            {
                TemaDetalle = new TemaDetalleBE();
                TemaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaDetalle.IdTemaDetalle = Int32.Parse(reader["idTemaDetalle"].ToString());
                TemaDetalle.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaDetalle.Archivo = (byte[])reader["Archivo"];
                TemaDetalle.NombreArchivo = reader["NombreArchivo"].ToString();
                TemaDetalle.Extension = reader["Extension"].ToString();
                TemaDetalle.Descripcion = reader["Descripcion"].ToString();
                TemaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TemaDetalle;
        }

        public List<TemaDetalleBE> ListaTodosActivo(int IdTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaDetalleBE> TemaDetallelist = new List<TemaDetalleBE>();
            TemaDetalleBE TemaDetalle;
            while (reader.Read())
            {
                TemaDetalle = new TemaDetalleBE();
                TemaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaDetalle.IdTemaDetalle = Int32.Parse(reader["idTemaDetalle"].ToString());
                TemaDetalle.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaDetalle.Archivo = (byte[])reader["Archivo"];
                TemaDetalle.NombreArchivo = reader["NombreArchivo"].ToString();
                TemaDetalle.Extension = reader["Extension"].ToString();
                TemaDetalle.Descripcion = reader["Descripcion"].ToString();
                TemaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TemaDetalle.TipoOper = 4; //CONSULTAR
                TemaDetallelist.Add(TemaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return TemaDetallelist;
        }
    }
}
