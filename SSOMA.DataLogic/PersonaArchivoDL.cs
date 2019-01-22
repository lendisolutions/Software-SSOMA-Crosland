using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PersonaArchivoDL
    {
        public PersonaArchivoDL() { }

        public void Inserta(PersonaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaArchivo_Inserta");

            db.AddInParameter(dbCommand, "pIdPersonaArchivo", DbType.Int32, pItem.IdPersonaArchivo);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
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

        public void Actualiza(PersonaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaArchivo_Actualiza");

            db.AddInParameter(dbCommand, "pIdPersonaArchivo", DbType.Int32, pItem.IdPersonaArchivo);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pExtension", DbType.String, pItem.Extension);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.Int32, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PersonaArchivoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaArchivo_Elimina");

            db.AddInParameter(dbCommand, "pIdPersonaArchivo", DbType.Int32, pItem.IdPersonaArchivo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public PersonaArchivoBE Selecciona(int IdPersonaArchivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaArchivo_Selecciona");
            db.AddInParameter(dbCommand, "pidPersonaArchivo", DbType.Int32, IdPersonaArchivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaArchivoBE PersonaArchivo = null;
            while (reader.Read())
            {
                PersonaArchivo = new PersonaArchivoBE();
                PersonaArchivo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PersonaArchivo.IdPersonaArchivo = Int32.Parse(reader["idPersonaArchivo"].ToString());
                PersonaArchivo.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                PersonaArchivo.Archivo = (byte[])reader["Archivo"];
                PersonaArchivo.NombreArchivo = reader["NombreArchivo"].ToString();
                PersonaArchivo.Extension = reader["Extension"].ToString();
                PersonaArchivo.Descripcion = reader["Descripcion"].ToString();
                PersonaArchivo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PersonaArchivo;
        }

        public List<PersonaArchivoBE> ListaTodosActivo(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaArchivo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaArchivoBE> PersonaArchivolist = new List<PersonaArchivoBE>();
            PersonaArchivoBE PersonaArchivo;
            while (reader.Read())
            {
                PersonaArchivo = new PersonaArchivoBE();
                PersonaArchivo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PersonaArchivo.IdPersonaArchivo = Int32.Parse(reader["idPersonaArchivo"].ToString());
                PersonaArchivo.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                PersonaArchivo.Archivo = (byte[])reader["Archivo"];
                PersonaArchivo.NombreArchivo = reader["NombreArchivo"].ToString();
                PersonaArchivo.Extension = reader["Extension"].ToString();
                PersonaArchivo.Descripcion = reader["Descripcion"].ToString();
                PersonaArchivo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PersonaArchivo.TipoOper = 4; //CONSULTAR
                PersonaArchivolist.Add(PersonaArchivo);
            }
            reader.Close();
            reader.Dispose();
            return PersonaArchivolist;
        }
    }
}
