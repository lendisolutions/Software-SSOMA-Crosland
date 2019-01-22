using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EmpresaArchivoDL
    {
        public EmpresaArchivoDL() { }

        public void Inserta(EmpresaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EmpresaArchivo_Inserta");

            db.AddInParameter(dbCommand, "pIdEmpresaArchivo", DbType.Int32, pItem.IdEmpresaArchivo);
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

        public void Actualiza(EmpresaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EmpresaArchivo_Actualiza");

            db.AddInParameter(dbCommand, "pIdEmpresaArchivo", DbType.Int32, pItem.IdEmpresaArchivo);
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

        public void Elimina(EmpresaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EmpresaArchivo_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresaArchivo", DbType.Int32, pItem.IdEmpresaArchivo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public EmpresaArchivoBE Selecciona(int IdEmpresaArchivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EmpresaArchivo_Selecciona");
            db.AddInParameter(dbCommand, "pidEmpresaArchivo", DbType.Int32, IdEmpresaArchivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmpresaArchivoBE EmpresaArchivo = null;
            while (reader.Read())
            {
                EmpresaArchivo = new EmpresaArchivoBE();
                EmpresaArchivo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EmpresaArchivo.IdEmpresaArchivo = Int32.Parse(reader["idEmpresaArchivo"].ToString());
                EmpresaArchivo.Archivo = (byte[])reader["Archivo"];
                EmpresaArchivo.NombreArchivo = reader["NombreArchivo"].ToString();
                EmpresaArchivo.Extension = reader["Extension"].ToString();
                EmpresaArchivo.Descripcion = reader["Descripcion"].ToString();
                EmpresaArchivo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EmpresaArchivo;
        }

        public List<EmpresaArchivoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EmpresaArchivo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaArchivoBE> EmpresaArchivolist = new List<EmpresaArchivoBE>();
            EmpresaArchivoBE EmpresaArchivo;
            while (reader.Read())
            {
                EmpresaArchivo = new EmpresaArchivoBE();
                EmpresaArchivo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EmpresaArchivo.IdEmpresaArchivo = Int32.Parse(reader["idEmpresaArchivo"].ToString());
                EmpresaArchivo.Archivo = (byte[])reader["Archivo"];
                EmpresaArchivo.NombreArchivo = reader["NombreArchivo"].ToString();
                EmpresaArchivo.Extension = reader["Extension"].ToString();
                EmpresaArchivo.Descripcion = reader["Descripcion"].ToString();
                EmpresaArchivo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                EmpresaArchivo.TipoOper = 4; //CONSULTAR
                EmpresaArchivolist.Add(EmpresaArchivo);
            }
            reader.Close();
            reader.Dispose();
            return EmpresaArchivolist;
        }
    }
}
