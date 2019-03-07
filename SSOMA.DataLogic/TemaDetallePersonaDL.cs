using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TemaDetallePersonaDL
    {
        public TemaDetallePersonaDL() { }

        public void Inserta(TemaDetallePersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_Inserta");

            db.AddInParameter(dbCommand, "pIdTemaDetallePersona", DbType.Int32, pItem.IdTemaDetallePersona);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pImage", DbType.Binary, pItem.Image);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pExtension", DbType.String, pItem.Extension);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pDescSituacion", DbType.String, pItem.DescSituacion);
            db.AddInParameter(dbCommand, "pImageSituacion", DbType.Binary, pItem.ImageSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TemaDetallePersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdTemaDetallePersona", DbType.Int32, pItem.IdTemaDetallePersona);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pImage", DbType.Binary, pItem.Image);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pExtension", DbType.String, pItem.Extension);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pDescSituacion", DbType.String, pItem.DescSituacion);
            db.AddInParameter(dbCommand, "pImageSituacion", DbType.Binary, pItem.ImageSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(TemaDetallePersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdTemaDetallePersona", DbType.Int32, pItem.IdTemaDetallePersona);
            db.AddInParameter(dbCommand, "pDescSituacion", DbType.String, pItem.DescSituacion);
            db.AddInParameter(dbCommand, "pImageSituacion", DbType.Binary, pItem.ImageSituacion);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TemaDetallePersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_Elimina");

            db.AddInParameter(dbCommand, "pIdTemaDetallePersona", DbType.Int32, pItem.IdTemaDetallePersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TemaDetallePersonaBE Selecciona(int IdTemaDetallePersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_Selecciona");
            db.AddInParameter(dbCommand, "pidTemaDetallePersona", DbType.Int32, IdTemaDetallePersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaDetallePersonaBE TemaDetallePersona = null;
            while (reader.Read())
            {
                TemaDetallePersona = new TemaDetallePersonaBE();
                TemaDetallePersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaDetallePersona.IdTemaDetallePersona = Int32.Parse(reader["idTemaDetallePersona"].ToString());
                TemaDetallePersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaDetallePersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                TemaDetallePersona.Image = (byte[])reader["Image"];
                TemaDetallePersona.Archivo = (byte[])reader["Archivo"];
                TemaDetallePersona.NombreArchivo = reader["NombreArchivo"].ToString();
                TemaDetallePersona.Extension = reader["Extension"].ToString();
                TemaDetallePersona.Descripcion = reader["Descripcion"].ToString();
                TemaDetallePersona.DescSituacion = reader["DescSituacion"].ToString();
                TemaDetallePersona.ImageSituacion = (byte[])reader["ImageSituacion"];
                TemaDetallePersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TemaDetallePersona;
        }

        public List<TemaDetallePersonaBE> ListaTodosActivo(int IdTema, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaDetallePersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaDetallePersonaBE> TemaDetallePersonalist = new List<TemaDetallePersonaBE>();
            TemaDetallePersonaBE TemaDetallePersona;
            while (reader.Read())
            {
                TemaDetallePersona = new TemaDetallePersonaBE();
                TemaDetallePersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaDetallePersona.IdTemaDetallePersona = Int32.Parse(reader["idTemaDetallePersona"].ToString());
                TemaDetallePersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaDetallePersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                TemaDetallePersona.Image = (byte[])reader["Image"];
                TemaDetallePersona.Archivo = (byte[])reader["Archivo"];
                TemaDetallePersona.NombreArchivo = reader["NombreArchivo"].ToString();
                TemaDetallePersona.Extension = reader["Extension"].ToString();
                TemaDetallePersona.Descripcion = reader["Descripcion"].ToString();
                TemaDetallePersona.DescSituacion = reader["DescSituacion"].ToString();
                TemaDetallePersona.ImageSituacion = (byte[])reader["ImageSituacion"];
                TemaDetallePersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TemaDetallePersonalist.Add(TemaDetallePersona);
            }
            reader.Close();
            reader.Dispose();
            return TemaDetallePersonalist;
        }
    }
}
