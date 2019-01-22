using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteDocumentoDL
    {
        public AccidenteDocumentoDL() { }

        public void Inserta(AccidenteDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteDocumento_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteDocumento", DbType.Int32, pItem.IdAccidenteDocumento);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pDescripcionDocumento", DbType.String, pItem.DescripcionDocumento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteDocumento_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteDocumento", DbType.Int32, pItem.IdAccidenteDocumento);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pDescripcionDocumento", DbType.String, pItem.DescripcionDocumento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteDocumento_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteDocumento", DbType.Int32, pItem.IdAccidenteDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteDocumentoBE Selecciona(int IdAccidenteDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteDocumento_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteDocumento", DbType.Int32, IdAccidenteDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteDocumentoBE AccidenteDocumento = null;
            while (reader.Read())
            {
                AccidenteDocumento = new AccidenteDocumentoBE();
                AccidenteDocumento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteDocumento.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteDocumento.IdAccidenteDocumento = Int32.Parse(reader["idAccidenteDocumento"].ToString());
                AccidenteDocumento.Foto = (byte[])reader["Foto"];
                AccidenteDocumento.DescripcionDocumento = reader["DescripcionDocumento"].ToString();
                AccidenteDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteDocumento;
        }

        public List<AccidenteDocumentoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteDocumento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteDocumentoBE> AccidenteDocumentolist = new List<AccidenteDocumentoBE>();
            AccidenteDocumentoBE AccidenteDocumento;
            while (reader.Read())
            {
                AccidenteDocumento = new AccidenteDocumentoBE();
                AccidenteDocumento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteDocumento.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteDocumento.IdAccidenteDocumento = Int32.Parse(reader["idAccidenteDocumento"].ToString());
                AccidenteDocumento.Foto = (byte[])reader["Foto"];
                AccidenteDocumento.DescripcionDocumento = reader["DescripcionDocumento"].ToString();
                AccidenteDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteDocumento.TipoOper = 4; //CONSULTAR
                AccidenteDocumentolist.Add(AccidenteDocumento);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteDocumentolist;
        }
    }
}
