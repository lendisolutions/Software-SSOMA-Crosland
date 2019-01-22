using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EmailDL
    {
        public EmailDL() { }

        public void EnviarEmail(string Destino, string Titulo, string Mensaje)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SendMail");

            db.AddInParameter(dbCommand, "pDestino", DbType.String, Destino);
            db.AddInParameter(dbCommand, "pTitulo", DbType.String, Titulo);
            db.AddInParameter(dbCommand, "pMensaje", DbType.String, Mensaje);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
