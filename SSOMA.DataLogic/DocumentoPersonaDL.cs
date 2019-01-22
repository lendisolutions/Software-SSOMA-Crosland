using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class DocumentoPersonaDL
    {
        public DocumentoPersonaDL() { }

        public void Inserta(DocumentoPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_Inserta");

            db.AddInParameter(dbCommand, "pIdDocumentoPersona", DbType.Int32, pItem.IdDocumentoPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, pItem.IdDocumento);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pLectura", DbType.Int32, pItem.Lectura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(DocumentoPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumentoPersona", DbType.Int32, pItem.IdDocumentoPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, pItem.IdDocumento);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pLectura", DbType.Int32, pItem.Lectura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaLectura(int IdPersona, int IdDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_ActualizaLectura");
          
            db.AddInParameter(dbCommand, "pIdPersona", DbType.String, IdPersona);
            db.AddInParameter(dbCommand, "pIdDocumento", DbType.String, IdDocumento);
           

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(DocumentoPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumentoPersona", DbType.Int32, pItem.IdDocumentoPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public DocumentoPersonaBE Selecciona(int idDocumentoPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_Selecciona");
            db.AddInParameter(dbCommand, "pidDocumentoPersona", DbType.Int32, idDocumentoPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoPersonaBE DocumentoPersona = null;
            while (reader.Read())
            {
                DocumentoPersona = new DocumentoPersonaBE();
                DocumentoPersona.IdDocumentoPersona = Int32.Parse(reader["idDocumentoPersona"].ToString());
                DocumentoPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DocumentoPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
               
                DocumentoPersona.ApeNom = reader["ApeNom"].ToString();
                DocumentoPersona.IdDocumento = Int32.Parse(reader["IdDocumento"].ToString());
                DocumentoPersona.Codigo = reader["Codigo"].ToString();
                DocumentoPersona.NombreArchivo = reader["NombreArchivo"].ToString();
                DocumentoPersona.Revision = reader["Revision"].ToString();
                DocumentoPersona.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                DocumentoPersona.Lectura = Int32.Parse(reader["Lectura"].ToString());
                DocumentoPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoPersona;
        }

        public List<DocumentoPersonaBE> ListaTodosActivo(int IdEmpresa, int IdPersona, int IdDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, IdDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoPersonaBE> DocumentoPersonalist = new List<DocumentoPersonaBE>();
            DocumentoPersonaBE DocumentoPersona;
            while (reader.Read())
            {
                DocumentoPersona = new DocumentoPersonaBE();
                DocumentoPersona.IdDocumentoPersona = Int32.Parse(reader["idDocumentoPersona"].ToString());
                DocumentoPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DocumentoPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DocumentoPersona.DescCarpeta = reader["DescCarpeta"].ToString();
                DocumentoPersona.ApeNom = reader["ApeNom"].ToString();
                DocumentoPersona.IdDocumento = Int32.Parse(reader["IdDocumento"].ToString());
                DocumentoPersona.Codigo = reader["Codigo"].ToString();
                DocumentoPersona.NombreArchivo = reader["NombreArchivo"].ToString();
                DocumentoPersona.Revision = reader["Revision"].ToString();
                DocumentoPersona.FlagAsigna = Boolean.Parse(reader["FlagAsigna"].ToString());
                DocumentoPersona.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                DocumentoPersona.Lectura = Int32.Parse(reader["Lectura"].ToString());
                DocumentoPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoPersona.TipoOper = 4; //CONSULTAR
                DocumentoPersonalist.Add(DocumentoPersona);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoPersonalist;
        }

        public List<DocumentoPersonaBE> ListaCarpeta(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_ListaCarpeta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoPersonaBE> DocumentoPersonalist = new List<DocumentoPersonaBE>();
            DocumentoPersonaBE DocumentoPersona;
            while (reader.Read())
            {
                DocumentoPersona = new DocumentoPersonaBE();
                DocumentoPersona.IdCarpeta = Int32.Parse(reader["IdCarpeta"].ToString());
                DocumentoPersona.DescCarpeta = reader["DescCarpeta"].ToString();
                DocumentoPersonalist.Add(DocumentoPersona);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoPersonalist;
        }

        public List<DocumentoPersonaBE> ListaCarpetaArchivo(int IdEmpresa, int IdPersona, int IdCarpeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoPersona_ListaCarpetaArchivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, IdCarpeta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoPersonaBE> DocumentoPersonalist = new List<DocumentoPersonaBE>();
            DocumentoPersonaBE DocumentoPersona;
            while (reader.Read())
            {
                DocumentoPersona = new DocumentoPersonaBE();
                DocumentoPersona.IdDocumento = Int32.Parse(reader["IdDocumento"].ToString());
                DocumentoPersona.NombreArchivo = reader["NombreArchivo"].ToString();
                DocumentoPersonalist.Add(DocumentoPersona);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoPersonalist;
        }

    }
}
